using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebAPI.Extensions 
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) {
        services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy", builder => builder
                        .AllowAnyOrigin() // WithOrigins("http://www.something.com")
                        .AllowAnyMethod() // WithMethods("POST", "GET")
                        .AllowAnyHeader() // WithHeaders("accept", "content-type")
                );
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }       
    }
}
