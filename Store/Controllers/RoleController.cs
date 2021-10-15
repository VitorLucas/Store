using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.EFCore;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : MyMDBController<Role, RoleRepository>
    {
        public RoleController(RoleRepository repository) : base(repository)
        {
        }
    }
}

