using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WinFormsMVVM.Models;

namespace WinFormsMVVM.Services
{
    public interface IUserService
    {
        public User GetUserByUserName(string userName);
    }

    public class UserService : IUserService
    {
        private readonly IDbConnection _dbConnection;

        public UserService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public User GetUserByUserName(string userName)
        {
            string sql = "SELECT * FROM Users WHERE UserName = @UserName";
            return _dbConnection.QueryFirstOrDefault<User>(sql, new { UserName = userName });
        }
    }
}
