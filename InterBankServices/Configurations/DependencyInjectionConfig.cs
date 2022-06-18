using InterBankServices.Infrastructure;

namespace InterBankServices.WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            DependencyInjection.AddInfrastructure(services);
        }
    }
}
