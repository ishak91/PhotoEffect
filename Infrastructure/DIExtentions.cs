using ApplicationCore.Abstraction;
using ApplicationCore.Abstraction.Infrastructure;
using ApplicationCore.Abstraction.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DIExtentions
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {          
            services.AddTransient<IStorageService,AzureStorageService>();   
            return services;
        }
    }
}
