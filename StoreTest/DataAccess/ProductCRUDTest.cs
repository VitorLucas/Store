using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using NUnit.Framework;
using Repository.EFCore;
using Repository.Insterface;
using Assert = NUnit.Framework.Assert;

namespace StoreTest
{
    [TestClass]
    public class ProductCRUDTest
    {
        IUriService mokUri;

        [SetUp]
        public void Setup()
        {
            mokUri = new Mock<IUriService>().Object;
        }

        [Test]
        public void InsertProductInDB()
        {
            ILogger<Product> mokLogger = new Mock<ILogger<Product>>().Object;

            var options = new DbContextOptionsBuilder<MainContext>()
           .UseInMemoryDatabase(databaseName: "Store")
           .Options;

            using (var context = new MainContext(options))
            {
                context.Product.Add(new Product
                {
                    Id = 1,
                    Code = "12345",
                    Dimension = "1m",
                    Description = "best drink ever",
                    Active = true,
                    Price = 12,
                    Reference = "Water",
                    StockBalance = 10,
                    CategoryId = 1
                });

                context.SaveChanges();
            }
            
            using (var context = new MainContext(options))
            {
                ProductRepository productRepository = new ProductRepository(context, mokUri, mokLogger);
                Product product = productRepository.Get(1).Result;

                Assert.AreEqual(1, product.Id);
            }
        }

        [Test]
        public void DeleteProductInDB()
        {
            ILogger<Product> mokLogger = new Mock<ILogger<Product>>().Object;

            var options = new DbContextOptionsBuilder<MainContext>()
           .UseInMemoryDatabase(databaseName: "Store")
           .Options;

            using (var context = new MainContext(options))
            {
                context.Category.Add(new Category { Description = "Food" });
                context.SaveChanges();
            }

            using (var context = new MainContext(options))
            {
                context.Product.Add(new Product
                {
                    Code = "12345",
                    Dimension = "1m",
                    Description = "best drink ever",
                    Active = true,
                    Price = 12,
                    Reference = "Water",
                    StockBalance = 10,
                    CategoryId = 1
                });

                context.SaveChanges();
            }

            using (var context = new MainContext(options))
            {
                ProductRepository productRepository = new ProductRepository(context, mokUri, mokLogger);
                Product product = productRepository.Delete(1).Result;

                Product productDeleted = productRepository.Get(1).Result;
                Assert.IsNull(productDeleted);
            }
        }

        [Test]
        public void UpdateProductInDB()
        {
            ILogger<Product> mokLogger = new Mock<ILogger<Product>>().Object;

            var options = new DbContextOptionsBuilder<MainContext>()
           .UseInMemoryDatabase(databaseName: "Store")
           .Options;

            using (var context = new MainContext(options))
            {
                context.Category.Add(new Category { Description = "Food" });
                context.SaveChanges();
            }

            using (var context = new MainContext(options))
            {
                context.Product.Add(new Product
                {
                    Code = "12345",
                    Dimension = "1m",
                    Description = "best drink ever",
                    Active = true,
                    Price = 12,
                    Reference = "Water",
                    StockBalance = 10,
                    CategoryId = 1
                });

                context.SaveChanges();
            }

            using (var context = new MainContext(options))
            {
                ProductRepository productRepository = new ProductRepository(context, mokUri, mokLogger);
                Product product = productRepository.Get(1).Result;
                product.Active = false;

                Product productUpdated = productRepository.Update(product).Result;

                Assert.IsFalse(productUpdated.Active);
            }
        }
    }
}