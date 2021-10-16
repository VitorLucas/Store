using Microsoft.Extensions.DependencyInjection;
using Repository.EFCore;

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
