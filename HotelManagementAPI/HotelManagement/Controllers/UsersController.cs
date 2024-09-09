using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.UserBL;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        #region Field

        private IUserBL _userBL;

        #endregion

        #region Constructor

        public UserController(IUserBL userBL) : base(userBL)
        {
            _userBL = userBL;
        }

        #endregion

        // Add additional endpoints specific to User if needed
    }
}
