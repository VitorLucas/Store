using DataAccess;
using Microsoft.Extensions.Logging;
using Model;
using Repository.Insterface;

namespace Repository.EFCore
{
    public class RoleRepository : EfCoreRepository<Role, MainContext>
    {
        public RoleRepository(MainContext context, 
                              IUriService uriService, 
                              ILogger<Role> log) : base(context, uriService, log) { }
    }
}
