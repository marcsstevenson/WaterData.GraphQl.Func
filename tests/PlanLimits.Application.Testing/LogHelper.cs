using Microsoft.Extensions.Logging;

namespace PlanLimits.Application.Testing
{
    public static class LogHelper
    {
        public static ILogger BuildLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
            });
            ILogger logger = loggerFactory.CreateLogger("Testing");

            return logger;
        }
    }
}
