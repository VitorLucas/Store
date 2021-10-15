using Model.Interface;
using Repository.Filter;
using Repository.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<PagedResponse<List<T>>> GetAll(PaginationFilter filter, string route);
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
