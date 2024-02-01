﻿using Microsoft.Extensions.DependencyInjection;
using Parser.BLL.Services;
using Parser.BLL.Services.Contracts;

namespace Parser.BLL.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBllServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
