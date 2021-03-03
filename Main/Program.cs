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
using Main.Controllers.EmployeeManagementControllers.Validator;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.EmployeeManagementControllers;
using AutoMapper;
using Main.Forms.EmployeeManagementForms;

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
                //var loginFrm = serviceProvider.GetRequiredService<LoginFrm>();
                var mainFrm = serviceProvider.GetRequiredService<MainFrm>();

                Application.Run(mainFrm);
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           
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
            services.AddTransient<IGovernmentAgencyData, GovernmentAgencyData>();
            services.AddTransient<IEmployeeGovtIdCardData, EmployeeGovtIdCardData>();
            services.AddTransient<IEmployeeGovtContributionData, EmployeeGovtContributionData>();


            // Employee Management validators (Fluent validation)
            services.AddTransient<LeaveTypeAddUpdateValidator>();
            services.AddTransient<EmployeeAddUpdateValidator>();
            services.AddTransient<EmployeeSalaryRateAddUpdateValidator>();


            // Employee Management Controllers
            services.AddTransient<ILeaveTypeController, LeaveTypeController>();
            services.AddTransient<IEmployeeController, EmployeeController>();


            // Business logic controllers/services
            services.AddTransient<IUserController, UserController>();


            // forms
            services.AddTransient<MainFrm>();
            services.AddTransient<MainUserMgnFrm>();
            services.AddTransient<LoginFrm>();

            // Employee Management forms
            services.AddTransient<FrmMainEmployeeManagement>();


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
