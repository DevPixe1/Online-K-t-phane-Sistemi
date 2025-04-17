using Microsoft.EntityFrameworkCore;
using OnlineKutuphane.Data;
using OnlineKutuphane.Service;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Repositories;
using OnlineKutuphane.Data.Repositories;

namespace OnlineKutuphane.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controller ve Swagger servisleri
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection – SOLID prensiplerine uygun þekilde
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IBookService, BookService>(); // BookManager yerine BookService

            var app = builder.Build();

            // Swagger ve diðer middleware'lar
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
