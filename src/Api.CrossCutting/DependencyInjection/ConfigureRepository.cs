using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            var connectionString = "Server=localhost;Port=3306;Database=ContactsAPI;Uid=root;Pwd=root";
            
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }
    }
}