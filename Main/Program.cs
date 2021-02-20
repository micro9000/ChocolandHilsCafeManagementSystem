using Main.UserManagementForms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            var ConfBuilder = GetConfigurationBuilder();

            ConfigureServices(services, ConfBuilder);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
                Application.Run(loginFrm);
            }
        }

        static IConfigurationRoot GetConfigurationBuilder()
        {
            var Confbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            return Confbuilder;
        }

        private static void ConfigureServices (ServiceCollection services, IConfigurationRoot confBuilder)
        {
            // forms
            services.AddScoped<LoginFrm>();

            services.AddScoped<MainUserMgnFrm>();

            // Business logic services
            //services.AddTransient<IUserBO, UserBO>();

            // settings
            services.Configure<DBConnectionSettings>(confBuilder.GetSection(nameof(DBConnectionSettings)));


            //Add Serilog
            var log = new LoggerConfiguration()
                .ReadFrom.Configuration(confBuilder)
                 .CreateLogger();

            services.AddLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Information);
                x.AddSerilog(logger: log, dispose: true);
            });
        }
    }
}
