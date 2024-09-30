using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserDL
{
    public interface IUserDL : IBaseDL<User>
    {
        public (int level, int status)? Login(string email, string password);

        public (string name, string email, string password)? Register(string name, string email, string password);

        public (int code, DateTime exprided)? SendEmailCode(string email);

    }
}
