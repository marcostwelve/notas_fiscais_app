using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotaFiscal.Application.Services;
using NotaFiscal.Application.Services.Interfaces;
using NotaFiscal.Infra.Data;
using NotaFiscal.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaFiscal.Infra.IoC
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IDataAccess, DataAccess>();
            services.AddScoped<IBuscaNotaService, BuscaNotaService>();
            return services;
        }
    }
}
