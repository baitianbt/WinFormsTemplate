using Microsoft.Extensions.DependencyInjection;
using YourSolution.BLL;
using YourSolution.BLL.Interfaces;
using YourSolution.BLL.Services;
using YourSolution.DAL;
using YourSolution.DAL.Interfaces;
using YourSolution.Model;
using YourSolution.WinForm.Forms;


namespace YourSolution.WinForm
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static void Main()
        {
           

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // 全局异常处理
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<ILogQueryService, LogQueryService>();
            services.AddScoped<LoginForm>();
            services.AddScoped<MainForm>();
            services.AddScoped<UserManagementForm>();
            services.AddScoped<LogViewerForm>();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var logService = ServiceProvider.GetRequiredService<ILogService>();
            logService.LogError(e.Exception, "Unhandled Thread Exception");
            MessageBox.Show("An error occurred. Please contact administrator.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var logService = ServiceProvider.GetRequiredService<ILogService>();
            if (e.ExceptionObject is Exception ex)
            {
                logService.LogError(ex, "Unhandled Application Exception");
            }
            MessageBox.Show("A fatal error occurred. Application will be terminated.", "Fatal Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
} 