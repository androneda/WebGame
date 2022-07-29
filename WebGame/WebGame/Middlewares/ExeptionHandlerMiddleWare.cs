using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebGame.Api.Middlewares
{
    public class ExeptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        public ExeptionHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
        }

    }
}
