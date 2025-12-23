using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionPronia.Application.Interface.Repositories;
using OnionPronia.Application.Interface.Services;
using OnionPronia.Persistence.Contexts;
using OnionPronia.Persistence.Implementations.Repositories;
using OnionPronia.Persistence.Implementations.Services;


namespace OnionPronia.Persistence
{
    public static class ServiceRegistration
    {
        public static void  AddPersistenceServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("default")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICategoryServices, CategoryService>();
        }
    }
}
