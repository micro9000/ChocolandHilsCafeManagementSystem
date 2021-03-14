using DapperGenericDataManager;
using DataAccess;
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
using Main.Forms.OtherDataForms;
using Main.Forms.PayrollForms;
using Main.Controllers.OtherDataController.Validator;
using Main.Controllers.OtherDataController;
using Main.Controllers.OtherDataController.ControllerInterface;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Implementations;
using Main.Forms.UserManagementForms;
using Main.Controllers.UserManagementControllers.Validator;
using Main.Forms.AttendanceTerminal;

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
                //var mainFrm = serviceProvider.GetRequiredService<MainFrm>();
                var logger = serviceProvider.GetRequiredService<ILogger<MainFrm>>();

                try
                {
                    Application.Run(loginFrm);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unexpected application error, kindly visit system logs and report this error to developer: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logger.LogError($"{ex.Message} {ex.StackTrace}");
                }
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


        private static void UnhandleExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show($"Unhandle exception caught: { e.Message } - Runtime terminating: {args.IsTerminating}");
        }


        private static void ConfigureServices (ServiceCollection services, IConfigurationRoot confBuilder)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandleExceptionHandler);
            services.AddAutoMapper(currentDomain.GetAssemblies());
           
            // settings
            services.Configure<DBConnectionSettings>(confBuilder.GetSection(nameof(DBConnectionSettings)));
            services.AddTransient<IDbConnectionFactory, MySQLConnection>(); // database settings, including connection string

            services.AddSingleton<Sessions>(); // application state or session
            services.AddSingleton<Hashing>();
            services.AddSingleton<DecimalMinutesToHrsConverter>();

            // Data Access services
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IRoleData, RoleData>();
            services.AddTransient<IUserRoleData, UserRoleData>();

            // Employee Management module: services:
            services.AddTransient<IHolidayData, HolidayData>();
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
            services.AddTransient<IEmployeeShiftDayData, EmployeeShiftDayData>();
            services.AddTransient<IEmployeeGovtIdCardData, EmployeeGovtIdCardData>();

            // Other data management
            services.AddTransient<ILeaveTypeData, LeaveTypeData>();
            services.AddTransient<IGovernmentAgencyData, GovernmentAgencyData>();


            // Employee Management
            // validator
            services.AddTransient<EmployeeAddUpdateValidator>();
            services.AddTransient<EmployeeSalaryRateAddUpdateValidator>();
            services.AddTransient<EmployeeShiftAddUpdateValidator>();
            services.AddTransient<EmployeeLeaveAddUpdateValidator>();
            services.AddTransient<HolidayAddUpdateValidator>();
            // controllers
            services.AddTransient<IEmployeeController, EmployeeController>();
            services.AddTransient<IWorkShiftController, WorkShiftController>();
            services.AddTransient<IEmployeeLeaveController, EmployeeLeaveController>();
            services.AddTransient<IHolidayController, HolidayController>();


            // Other Data:
            // validator
            services.AddTransient<LeaveTypeAddUpdateValidator>();
            services.AddTransient<UserAddUpdateValidator>();
            services.AddTransient<GovernmentAgencyAddUpdateValidator>();
            // Controllers
            services.AddTransient<ILeaveTypeController, LeaveTypeController>();
            services.AddTransient<IGovernmentController, GovernmentController>();

            // Business logic controllers/services
            services.AddTransient<IUserController, UserController>();


            // forms
            services.AddTransient<MainFrm>();
            services.AddTransient<FrmUserManagement>();
            services.AddTransient<LoginFrm>();
            services.AddTransient<FrmMainEmployeeManagement>();
            services.AddTransient<FrmOtherData>();
            services.AddTransient<FrmPayroll>();
            services.AddTransient<AttendanceTerminalForm>();


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
