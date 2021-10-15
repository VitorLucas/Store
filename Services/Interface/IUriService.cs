using Repository.Filter;
using System;

namespace Repository.Insterface
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
