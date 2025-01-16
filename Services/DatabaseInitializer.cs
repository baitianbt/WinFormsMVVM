using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SQLitePCL;
using WinFormsMVVM.Models;

namespace WinFormsMVVM.Services
{
    internal class DatabaseInitializer
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseInitializer(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            
        }

        public void InitializeDatabase()
        {
            //
            Batteries.Init();
             const string createTableQuery = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, UserName TEXT, Password TEXT)";
            const string insertUserQuery = @"
                INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password)
            ";
            _dbConnection.Open();
            
            _dbConnection.Execute(createTableQuery);

            User user = _dbConnection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE UserName = 'Admin'");
            if (user is null)
            {
                _dbConnection.Execute(insertUserQuery, new User() { UserName = "Admin", Password = "Admin" });
            }

            _dbConnection.Close();
        }
    }
}
