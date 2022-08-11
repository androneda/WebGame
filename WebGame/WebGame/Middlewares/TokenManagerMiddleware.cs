using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using WebGame.Common.Exeptions;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Middlewares
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly ITokenHelper _tokenHelper;

        public TokenManagerMiddleware(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await _tokenHelper.IsCurrentActiveToken())
            {
                await next(context);

                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
