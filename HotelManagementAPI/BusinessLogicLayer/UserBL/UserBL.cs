using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.UserDL;
using System;
using System.Collections.Generic;

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

        #endregion

        #region Methods

        // Implement specific business logic methods for User here
        // For example:
        // public void SomeUserMethod() { ... }

        #endregion
    }
}
