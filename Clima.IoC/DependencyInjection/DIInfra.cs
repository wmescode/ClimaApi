using Clima.Domain.Repositories;
using Clima.Infra.Data.Repositories;
using Clima.IoC.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima.IoC.DependencyInjection
{
    public static class DIInfra
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            services.AddTransient<SqlConnection>(serviceProvider =>
                     new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPrevisaoClimaCidadeRepository, PrevisaoClimaCidadeRepository>();
            services.AddScoped<IPrevisaoClimaAeroportoRepository, PrevisaoClimaAeroportoRepository>();

            return services;
        }
    }
}
