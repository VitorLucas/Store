using DataAccess;
using Microsoft.Extensions.Logging;
using Model;
using Repository.Insterface;

namespace Repository.EFCore
{
    public class CategoryRepository : EfCoreRepository<Category, MainContext>
    {
        public CategoryRepository(MainContext context, IUriService uriService, ILogger<Category> log) : base(context, uriService, log)
        {
        }
    }
}
