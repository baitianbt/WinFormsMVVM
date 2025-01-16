using System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using WinFormsMVVM.Ioc;
using WinFormsMVVM.Services;
using WinFormsMVVM.ViewModels;

namespace WinFormsMVVM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceProvider = IoCContainer.Configure();
            // 初始化数据库
            var dbInitializer = serviceProvider.GetService<DatabaseInitializer>();
            dbInitializer?.InitializeDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginViewModel = serviceProvider.GetService(typeof(LoginViewModel));
            var loginForm = new LoginForm((LoginViewModel)loginViewModel);
            Application.Run(loginForm);
        }
    }
}