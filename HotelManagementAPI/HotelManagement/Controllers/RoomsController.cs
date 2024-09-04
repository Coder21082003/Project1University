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
    public class RoomsController : ControllerBase
    {
        #region Field

        private IRoomBL _roomsBL;

        #endregion

        #region Constructor

        public RoomsController(IRoomBL roomsBL)
        {
            _roomsBL = roomsBL;
        }

        #endregion

        #region Method

        // Get all rooms
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllRooms()
        {
            try
            {
                var getAllRooms = _roomsBL.GetAllRooms();
                if (getAllRooms != null)
                {
                    return StatusCode(200, getAllRooms);
                }
                else
                {
                    return StatusCode(404, "No rooms found.");
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

        // Filter rooms
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterRooms([FromBody] FilterRoom filterRoom)
        {
            try
            {
                var filteredRooms = _roomsBL.GetFilteredRooms(filterRoom);
                if (filteredRooms != null)
                {
                    return StatusCode(200, filteredRooms);
                }
                else
                {
                    return StatusCode(404, "No rooms found.");
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

        // Insert new room
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertRoom([FromBody] Room record)
        {
            try
            {
                int insertedId = _roomsBL.InsertRoom(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting room.");
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

        // Update room by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] Room record)
        {
            try
            {
                bool updated = _roomsBL.UpdateRoom(id, record);

                if (updated)
                {
                    return StatusCode(200, "Room updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Room not found.");
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

        // Delete room by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                bool deleted = _roomsBL.DeleteRoom(id);

                if (deleted)
                {
                    return StatusCode(200, "Room deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Room not found.");
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
