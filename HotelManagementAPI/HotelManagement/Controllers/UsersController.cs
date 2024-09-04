using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Field

        private IUserBL _usersBL;

        #endregion

        #region Constructor

        public UsersController(IUserBL usersBL)
        {
            _usersBL = usersBL;
        }

        #endregion

        #region Method

        // Get all users
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var getAllUsers = _usersBL.GetAllUsers();
                if (getAllUsers != null)
                {
                    return StatusCode(200, getAllUsers);
                }
                else
                {
                    return StatusCode(404, "No users found.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Filter users
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterUsers([FromBody] FilterUser filterUser)
        {
            try
            {
                var filteredUsers = _usersBL.GetFilteredUsers(filterUser);
                if (filteredUsers != null)
                {
                    return StatusCode(200, filteredUsers);
                }
                else
                {
                    return StatusCode(404, "No users found.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Insert new user
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertUser([FromBody] User record)
        {
            try
            {
                int insertedId = _usersBL.InsertUser(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting user.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Update user by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User record)
        {
            try
            {
                bool updated = _usersBL.UpdateUser(id, record);

                if (updated)
                {
                    return StatusCode(200, "User updated successfully.");
                }
                else
                {
                    return StatusCode(404, "User not found.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Delete user by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                bool deleted = _usersBL.DeleteUser(id);

                if (deleted)
                {
                    return StatusCode(200, "User deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "User not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion
    }
}
