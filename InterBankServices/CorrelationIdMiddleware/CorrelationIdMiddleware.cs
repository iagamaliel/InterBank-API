using InterBankServices.Core.Entities.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace InterBankServices.WebApi.CorrelationIdMiddleware
{
    public class CorrelationIdMiddleware : ActionFilterAttribute
    {
        private readonly CorrelationIdOptions _options;
        public CorrelationIdMiddleware(IOptions<CorrelationIdOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _options = options.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var header = context.HttpContext.Request.Headers[_options.Header];
            if (header.Count() > 0)
            {
                if (context.HttpContext.Request.Headers.TryGetValue(_options.Header, out StringValues correlationId))
                {
                    context.HttpContext.TraceIdentifier = correlationId;
                }
            }
            else
            {
                context.HttpContext.Request.Headers.Add(_options.Header, new[] { context.HttpContext.TraceIdentifier });
            }

            if (_options.IncludeInResponse)
            {
                context.HttpContext.Response.OnStarting(() =>
                {
                    context.HttpContext.Response.Headers.Add(_options.Header, new[] { context.HttpContext.TraceIdentifier });
                    return Task.CompletedTask;
                });
            }
        }
    }
}
