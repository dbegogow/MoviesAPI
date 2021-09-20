using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAPI.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<MyExceptionFilter> _logger;

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger)
        {
            this._logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            this._logger.LogError(context.Exception, context.Exception.Message);

            base.OnException(context);
        }
    }
}