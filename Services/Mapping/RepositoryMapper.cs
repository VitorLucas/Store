using Microsoft.Extensions.DependencyInjection;
using Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public static class RepositoryMapper
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            services.AddScoped<ProductRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<RoleRepository>();
        }
    }
}
