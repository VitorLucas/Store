using DataAccess;
using Microsoft.Extensions.Logging;
using Model;
using Repository.Insterface;

namespace Repository.EFCore
{
    public class ProductRepository : EfCoreRepository<Product, MainContext>
    {
        public ProductRepository(MainContext context, IUriService uriService, ILogger<Product> log) : base(context, uriService, log)
        {
        }
    }
}
