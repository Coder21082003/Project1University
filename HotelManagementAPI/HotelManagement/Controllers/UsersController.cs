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


        #region Method
        // Add additional endpoints specific to User if needed
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login loginRequest)
        {
            try
            {
                // Call the Business Logic Layer to handle the login
                var loginResult = _userBL.Login(loginRequest.email, loginRequest.password);

                if (loginResult.Value.status == 0)
                {
                    return Unauthorized("This account has been unactive");
                }

                // If login successful, return the user data or token (as needed)
                return Ok(new
                {
                    level = loginResult.Value.level,
                    status = loginResult.Value.status
                });
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpPost("sendEmailCode")]
        public IActionResult SendEmailCode([FromBody] string email)
        {
            try
            {

                // Call the Business Logic Layer to handle the login
                var sendEmailCodeResult = _userBL.SendEmailCode(email);

                if (sendEmailCodeResult.Value.code > 0)
                {
                    return Ok(new
                    {
                        code = sendEmailCodeResult.Value.code,
                        exprided = sendEmailCodeResult.Value.exprided
                    });
                }
                else if(email == null){
                    return StatusCode(404, "bad request");
                }    
                {
                    return StatusCode(404, "Cant send code to email");
                }
                
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register ([FromBody] Register register)
        {
            try
            {

                // Call the Business Logic Layer to handle the login
                 var registerResult = _userBL.Register(register.name, register.email, register.password);

                if (registerResult.Value.email != "")
                {
                    return Ok(new
                    {
                        name = registerResult.Value.name,
                        email = registerResult.Value.email,
                        password = registerResult.Value.password
                    });
                }
                else
                {
                    return StatusCode(404, "Bad request");
                }

            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        #endregion
    }
}
