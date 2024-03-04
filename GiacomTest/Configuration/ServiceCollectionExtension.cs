using Application.Configuration;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiacomTest
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Initial DI for Giacom API
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<IDataService, CrdDataService>();

            return services;
        }
    }
}
