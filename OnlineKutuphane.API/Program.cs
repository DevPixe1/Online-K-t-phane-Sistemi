using OnlineKutuphane.API.Extensions;
using OnlineKutuphane.Core;
using OnlineKutuphane.Data;
using OnlineKutuphane.Service;
using OnlineKutuphane.Core.Services;

namespace OnlineKutuphane.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddProjectServices(builder.Configuration);
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
