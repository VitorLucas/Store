using DataAccess;
using Microsoft.Extensions.Logging;
using Model;
using Repository.Insterface;
namespace Repository.EFCore
{
    public class UserRepository : EfCoreRepository<User, MainContext>
    {
        public UserRepository(MainContext context, 
                              IUriService uriService, 
                              ILogger<User> log) : 
                              base(context, uriService, log) { }

    }
}
