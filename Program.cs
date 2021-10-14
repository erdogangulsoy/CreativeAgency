using CreativeAgency.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Exceptions;

namespace CreativeAgency
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }
        private static LogConfig _logConfig;
        public static void Main(string[] args)
        {
            try
            {
                // _logConfig = Configuration.GetSection(LogConfig.ENTRY_NAME).Get<LogConfig>();


                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "Uygulama beklenmedik şekilde sonlandı");

            }
            finally
            {
                //Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, configuration) => configuration
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(@"logs\log.txt", rollingInterval: RollingInterval.Day))
                //.UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
                //                                                                        .MinimumLevel.Verbose()

                //                                                                        // Konsol logları
                //                                                                        .WriteTo.Logger(lc => lc
                //                                                                              .MinimumLevel.Is(_logConfig.MinimumLevel)
                //                                                                             .Enrich.FromLogContext()
                //                                                                             //.Enrich.WithThreadId()
                //                                                                             .Enrich.WithExceptionDetails()
                //                                                                             .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                //                                                                             )

                //                                                                          // Uygulama logları
                //                                                                          .WriteTo.Logger(lc => lc
                //                                                                              .MinimumLevel.Is(_logConfig.MinimumLevel)
                //                                                                             .Enrich.FromLogContext()
                //                                                                             //.Enrich.WithThreadId()
                //                                                                             .Enrich.WithExceptionDetails()
                //                                                                             .WriteTo.File(_logConfig.ApplicationLog.PathFormat,
                //                                                                                  rollingInterval: RollingInterval.Day,
                //                                                                                  fileSizeLimitBytes: _logConfig.ApplicationLog.FileSizeLimitBytes,
                //                                                                                  retainedFileCountLimit: _logConfig.ApplicationLog.RetainedFileCountLimit ?? 31)
                //                                                                             )

                //                                                                          // Denetim logları
                //                                                                          .AuditTo.Logger(lc => lc
                //                                                                             .MinimumLevel.Verbose()
                //                                                                             //.Filter.ByIncludingOnly("LogType = 'Audit'")
                //                                                                             .Enrich.FromLogContext()
                //                                                                             .WriteTo.File(_logConfig.AuditLog.PathFormat,
                //                                                                                  rollingInterval: RollingInterval.Day,
                //                                                                                  fileSizeLimitBytes: _logConfig.AuditLog.FileSizeLimitBytes,
                //                                                                                  retainedFileCountLimit: _logConfig.AuditLog.RetainedFileCountLimit,
                //                                                                                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} - {Message:lj} {Properties:j}{NewLine}")
                //                                                                             )
                //      )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
