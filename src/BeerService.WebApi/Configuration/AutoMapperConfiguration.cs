using AutoMapper;
using BeerService.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BeerService.WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToApplicationProfile), typeof(ApplicationToDomainProfile));
        }
    }
}