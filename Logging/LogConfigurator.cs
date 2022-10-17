using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Logging
{
    public static class LogConfigurator
    {
        public static void Configure()
        {
            /* var log = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                 .WriteTo.Trace()
                 .CreateLogger();*/

            /*var log = new LoggerConfiguration()
               .MinimumLevel.Information()
               .WriteTo.Trace()
               .WriteTo.File("logs/application_log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();*/

            var log = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Trace()
               .WriteTo.File("logs/application_log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            Log.Logger = log;

            Log.Information("Log configured");
        }
    }
}
