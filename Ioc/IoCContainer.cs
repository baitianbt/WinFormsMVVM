using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using WinFormsMVVM.Services;
using WinFormsMVVM.ViewModels;

namespace WinFormsMVVM.Ioc
{
    public static class IoCContainer
    {

        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDbConnection>(sp =>
                new SqliteConnection("Data Source=./database.db"));
            services.AddSingleton<DatabaseInitializer>();
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<LoginViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
