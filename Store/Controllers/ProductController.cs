using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.EFCore;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : MyMDBController<Product, ProductRepository>
    {
        public ProductController(ProductRepository repository) : base(repository)
        {
        }
    }
}

