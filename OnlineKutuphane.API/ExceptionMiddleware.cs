using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace OnlineKutuphane.API.Middlewares
{
    //Tüm hataları yakalayıp düzenli JSON yanıtı döner
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError; // 500 default
            var message = "Bir hata oluştu.";

            switch (exception)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound; // 404
                    message = exception.Message;
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest; // 400
                    message = exception.Message;
                    break;

                    //İstersen daha fazla case ekleyebilirsin
            }

            var response = new
            {
                success = false,
                error = message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
