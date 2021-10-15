using Model;
using Repository.EFCore;

namespace Store.Controllers
{
    public class CategoryController : MyMDBController<Category, CategoryRepository>
    {
        public CategoryController(CategoryRepository repository) : base(repository)
        {
        }
    }
}
