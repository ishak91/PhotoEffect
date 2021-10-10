using ApplicationCore.Abstraction;
using ApplicationCore.Abstraction.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DIExtentions
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Uncomment Below line to use  Sql Server 
            services.AddDbContext<IApplicationDbContext, DatabaseContext>(s => s.UseSqlServer(configuration.GetConnectionString("Connection"),s=> {

                s.MigrationsAssembly("Persistence");
            
            }));

            //services.AddDbContext<IApplicationDbContext, DatabaseContext>(s => s.UseInMemoryDatabase("photoEffect"));

            return services;
        }
    }
}
