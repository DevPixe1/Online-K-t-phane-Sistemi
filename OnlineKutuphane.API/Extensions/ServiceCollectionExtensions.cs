using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Data;
using OnlineKutuphane.Data.Repositories;
using OnlineKutuphane.Service.Services;
using OnlineKutuphane.Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace OnlineKutuphane.API.Extensions
{
    //Uygulama servislerini tek bir yerden merkezi olarak yapılandırmak için kullanılır
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Veritabanı bağlantısı ve DbContext konfigürasyonu
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //FluentValidation ayarları
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            //Generic repository'lerin DI (Dependency Injection) kaydı
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //Unit of Work deseninin DI kaydı
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Uygulama servislerinin DI kaydı / Servisler
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
