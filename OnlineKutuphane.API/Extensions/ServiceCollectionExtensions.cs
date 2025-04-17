using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineKutuphane.Data;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Data.Repositories;
using OnlineKutuphane.Core;
using OnlineKutuphane.Service;

namespace OnlineKutuphane.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repository ve Service kayıtları
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
