using OnlineKutuphane.API.Extensions;
using OnlineKutuphane.Core;
using OnlineKutuphane.Service;
using OnlineKutuphane.Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace OnlineKutuphane.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //FluentValidation middleware�lerini ekle
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateBookDtoValidator>();

            //Kontroller
            builder.Services.AddControllers();

            //Swagger kullan
            builder.Services.AddEndpointsApiExplorer();
            //Swagger kullan
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations(); //Swagger'a a��klama ekler
            });

            //Custom service registrations (Db, Repos, Services, UoW)
            builder.Services.AddProjectServices(builder.Configuration);

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
