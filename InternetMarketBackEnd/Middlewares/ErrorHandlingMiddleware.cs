using InternetMarketBackEnd.Application.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Middlewares
{
    public static class CustomExceptionMiddleware
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exp)
            {
                _logger.LogError(exp.Message);
                await HandleExceptionAsync(httpContext, exp);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var error = new Result
            {
                Code = 500,
                Message = "500 Error"
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = error.Code;
            return httpContext.Response.WriteAsync(error.Message);
        }
    }
}