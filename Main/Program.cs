using DapperGenericDataManager;
using DataAccess;
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
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.EmployeeManagement.Implementations;
using Main.Controllers.UserManagementControllers;
using DataAccess.Data.UserManagement.Contracts;
using DataAccess.Data.UserManagement.Implementations;
using Shared.Helpers;

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
            // settings
            services.Configure<DBConnectionSettings>(confBuilder.GetSection(nameof(DBConnectionSettings)));
            services.AddTransient<IDbConnectionFactory, MySQLConnection>(); // database settings, including connection string

            services.AddSingleton<Sessions>(); // application state or session
            services.AddSingleton<Hashing>();

            // Data Access services
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IRoleData, RoleData>();
            services.AddTransient<IUserRoleData, UserRoleData>();

            // Employee Management module: services:
            services.AddTransient<IEmployeeAttendanceData, EmployeeAttendanceData>();
            services.AddTransient<IEmployeeBenefitData, EmployeeBenefitData>();
            services.AddTransient<IEmployeeData, EmployeeData>();
            services.AddTransient<IEmployeeDeductionData, EmployeeDeductionData>();
            services.AddTransient<IEmployeeLeaveData, EmployeeLeaveData>();
            services.AddTransient<IEmployeePayslipBenefitData, EmployeePayslipBenefitData>();
            services.AddTransient<IEmployeePayslipData, EmployeePayslipData>();
            services.AddTransient<IEmployeePayslipDeductionData, EmployeePayslipDeductionData>();
            services.AddTransient<IEmployeeSalaryRateData, EmployeeSalaryRateData>();
            services.AddTransient<IEmployeeShiftData, EmployeeShiftData>();
            services.AddTransient<IEmployeeShiftScheduleData, EmployeeShiftScheduleData>();
            services.AddTransient<ILeaveTypeData, LeaveTypeData>();


            // Business logic controllers/services
            services.AddTransient<IUserController, UserController>();


            // forms
            services.AddScoped<MainFrm>();
            services.AddScoped<MainUserMgnFrm>();
            services.AddScoped<LoginFrm>();

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
