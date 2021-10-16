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
    public class CategoryCRUDTest
    {
        IUriService mokUri;

        [SetUp]
        public void Setup()
        {
            mokUri = new Mock<IUriService>().Object;
        }

        [Test]
        public void InsertCategoryInDB()
        {
            ILogger<Category> mokLogger = new Mock<ILogger<Category>>().Object;
            var options = new DbContextOptionsBuilder<MainContext>()
           .UseInMemoryDatabase(databaseName: "Store")
           .Options;

            using (var context = new MainContext(options))
            {
                context.Category.Add(new Category { Id = 1, Description = "Food" });
                context.SaveChanges();
            }
            
            using (var context = new MainContext(options))
            {
                CategoryRepository categoryRepository = new CategoryRepository(context, mokUri, mokLogger);
                Category category = categoryRepository.Get(1).Result;

                Assert.AreEqual(1, category.Id);
            }
        }

        [Test]
        public void DeleteCategoryInDB()
        {
            ILogger<Category> mokLogger = new Mock<ILogger<Category>>().Object;
            var options = new DbContextOptionsBuilder<MainContext>()
           .UseInMemoryDatabase(databaseName: "Store")
           .Options;

            using (var context = new MainContext(options))
            {
                context.Category.Add(new Category { Id = 1, Description = "Food" });
                context.SaveChanges();
            }

            using (var context = new MainContext(options))
            {
                CategoryRepository categoryRepository = new CategoryRepository(context, mokUri, mokLogger);
                Category category = categoryRepository.Get(1).Result;

                Assert.AreEqual(1, category.Id);
            }

            using (var context = new MainContext(options))
            {
                CategoryRepository categoryRepository = new CategoryRepository(context, mokUri, mokLogger);
                Category category = categoryRepository.Delete(1).Result;

                Category categoryDeleted = categoryRepository.Get(1).Result;

                Assert.Null(categoryDeleted);
            }
        }

        [Test]
        public void UpdatingCategoryInDB()
        {
            ILogger<Category> mokLogger = new Mock<ILogger<Category>>().Object;
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
                CategoryRepository categoryRepository = new CategoryRepository(context, mokUri, mokLogger);
                Category category = categoryRepository.Get(1).Result;

                Assert.AreEqual(1, category.Id);
            }

            using (var context = new MainContext(options))
            {
                CategoryRepository categoryRepository = new CategoryRepository(context, mokUri, mokLogger);
              
                Category category = categoryRepository.Update(new Category { Id = 1, Description = "Drink" }).Result;

                Assert.AreNotEqual("Food", category.Description);
                Assert.AreEqual("Drink", category.Description);
            }
        }
    }
}