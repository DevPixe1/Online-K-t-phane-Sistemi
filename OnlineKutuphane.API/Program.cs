using OnlineKutuphane.API.Extensions;
using OnlineKutuphane.Core;
using OnlineKutuphane.Service;
using OnlineKutuphane.Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using OnlineKutuphane.Service.Services;
using OnlineKutuphane.API.Middlewares;
using OnlineKutuphane.Core.Dtos;

namespace OnlineKutuphane.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(); // Sadece AddControllers
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
            });

            // FluentValidation servis kaydý (Doðrusu)
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateBookDtoValidator>();

            // Proje servisleri
            builder.Services.AddProjectServices(builder.Configuration);

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // CategoryService kaydý
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            var app = builder.Build();

            // Middleware pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
