using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IUserBL : IBaseBL<User>
    {
        public (int level, int status)? Login(string email, string password);

        public (string name, string email, string password)? Register(string name, string email, string password);

        public (int code, DateTime exprided)? SendEmailCode(string email);
    }
}
