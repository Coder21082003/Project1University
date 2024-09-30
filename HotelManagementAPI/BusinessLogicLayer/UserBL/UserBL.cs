using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.UserDL;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BusinessLogicLayer.UserBL
{
    public class UserBL : BaseBL<User>, IUserBL
    {
        #region Field

        private readonly IUserDL _userDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public UserBL(IUserDL userDL) : base(userDL)
        {
            _userDL = userDL;
        }

        public (int level, int status)? Login(string email, string password)
        {

            // Validate email
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            // Regular Expression để kiểm tra định dạng email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ArgumentException("Invalid email format.");
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            if (password.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters long.");
            }

            // Gọi tới phương thức Login của Data Access Layer
            return _userDL.Login(email, password);
        }

        public (string name, string email, string password)? Register(string name, string email, string password)
        {
            // Validate email
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            // Regular Expression để kiểm tra định dạng email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ArgumentException("Invalid email format.");
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            if (password.Length < 6)
            {
                throw new ArgumentException("Password must be at least 6 characters long.");
            }

            return _userDL.Register(name, email, password);
        }

        public (int code, DateTime exprided)? SendEmailCode(string email)
        {
            // Validate email
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            // Regular Expression để kiểm tra định dạng email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new ArgumentException("Invalid email format.");
            }

            return _userDL.SendEmailCode(email);
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for User here
        // For example:
        // public void SomeUserMethod() { ... }

        #endregion
    }
}
