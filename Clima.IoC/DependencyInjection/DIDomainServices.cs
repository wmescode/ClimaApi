using Clima.Application.UseCases;
using Clima.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clima.IoC.DependencyInjection
{
    public static class DIDomainServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IPrevisaoClimaCidadeService, PrevisaoClimaCidadeService>();
            services.AddScoped<IPrevisaoClimaAeroportoService, PrevisaoClimaAeroportoService>();

            return services;
        }
    }
}
