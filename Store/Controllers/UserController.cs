using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.EFCore;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MyMDBController<User, UserRepository>
    {
        public UserController(UserRepository repository) : base(repository)
        {
        }
    }
}

