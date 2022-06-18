using InterBankServices.WebApi.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace InterBankServices.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(a => a.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    var response = new ListResponse<string>
                    {
                        Code = 0,
                        Message = "Error: Los parámetros enviados no son válidos.",
                        Items = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
