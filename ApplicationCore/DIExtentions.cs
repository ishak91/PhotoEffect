using ApplicationCore.Abstraction;
using ApplicationCore.Abstraction.Services;
using ApplicationCore.Effects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public static class DIExtentions
    {

        public static IServiceCollection AddCoreServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped<IAuthorizationContext, AuthorizationContext>();
            services.AddScoped<IDateTime, AppDateTime>();
            services.AddScoped<IEffectRegistry, EffectRegistry>();
            services.AddScoped<IEffectProcessService, EffectProcessService>();
            services.AddTransient<IImageService, ImageService>();
            return services;
        }
    }
}
