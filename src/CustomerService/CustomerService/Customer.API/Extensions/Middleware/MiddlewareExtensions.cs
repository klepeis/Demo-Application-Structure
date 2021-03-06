﻿using Customer.API.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Customer.API.Extensions.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
