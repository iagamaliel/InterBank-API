using InterBankServices.Application.UseCases;
using InterBankServices.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InterBankServices.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICertificateUseCase, CertificateUseCase>();

        }
        public static void Register(this ServiceCollection serviceCollection, IConfiguration configuration)
        {


        }

    }
}
