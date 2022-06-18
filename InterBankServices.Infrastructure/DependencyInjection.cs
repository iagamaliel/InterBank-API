using InterBankServices.Application.UseCases;
using InterBankServices.Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using InterBankServices.Application.Interfaces.Commands;
using InterBankServices.Infrastructure.Command;
using System.Data.Common;
using InterBankServices.Application.Interfaces.Query;
using InterBankServices.Infrastructure.Query;

namespace InterBankServices.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(IServiceCollection services)
        {

            services.AddScoped<ICertificateUseCase, CertificateUseCase>();
            services.AddScoped<ICertificateCommand, CertificateCommand>();
            services.AddScoped<ICertificateQuery, CertificateQuery>();

            services.AddScoped<IFinancialUseCase, FinancialUseCase>();
            services.AddScoped<IFinancialCommand, FinancialCommand>();
            services.AddScoped<IFinancialQuery, FinancialQuery>();

        }
            public static void Register(this ServiceCollection serviceCollection, IConfiguration configuration)
        {


        }

    }
}
