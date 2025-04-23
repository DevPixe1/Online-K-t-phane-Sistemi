using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Data;
using OnlineKutuphane.Data.Repositories;
using OnlineKutuphane.Service;
using OnlineKutuphane.Core.Services;


namespace OnlineKutuphane.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
