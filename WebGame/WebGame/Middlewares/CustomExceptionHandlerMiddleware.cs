using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using WebGame.Common.Exeptions;

namespace WebGame.Api.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseException exception)
            {
                await HandleCustomExceptionAsync(context, exception);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }

        }

        private static Task HandleCustomExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new { error = exception.Message , code = context.Response.StatusCode = (int)HttpStatusCode.BadRequest };
            return context.Response.WriteAsJsonAsync(response);
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new { error = exception.Message, code = context.Response.StatusCode = (int)HttpStatusCode.InternalServerError };
            return context.Response.WriteAsJsonAsync(response);
        }

    }
}
