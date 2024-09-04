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
    public class CouponRoomsController : ControllerBase
    {
        #region Field

        private ICouponRoomBL _couponRoomsBL;

        #endregion

        #region Constructor

        public CouponRoomsController(ICouponRoomBL couponRoomsBL)
        {
            _couponRoomsBL = couponRoomsBL;
        }

        #endregion

        #region Method

        // Get all coupon-rooms
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllCouponRooms()
        {
            try
            {
                var getAllCouponRooms = _couponRoomsBL.GetAllCouponRooms();
                if (getAllCouponRooms != null)
                {
                    return StatusCode(200, getAllCouponRooms);
                }
                else
                {
                    return StatusCode(404, "No coupon-rooms found.");
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

        // Filter coupon-rooms
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterCouponRooms([FromBody] FilterCouponRooms filterCouponRooms)
        {
            try
            {
                var filteredCouponRooms = _couponRoomsBL.GetFilteredCouponRooms(filterCouponRooms);
                if (filteredCouponRooms != null)
                {
                    return StatusCode(200, filteredCouponRooms);
                }
                else
                {
                    return StatusCode(404, "No coupon-rooms found.");
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

        // Insert new coupon-room
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertCouponRoom([FromBody] CouponRoom record)
        {
            try
            {
                int insertedId = _couponRoomsBL.InsertCouponRoom(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting coupon-room.");
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

        // Update coupon-room by id
        //[Authorize]
        [HttpPut("update/{couponId}/{roomId}")]
        public IActionResult UpdateCouponRoom(int couponId, int roomId, [FromBody] CouponRoom record)
        {
            try
            {
                bool updated = _couponRoomsBL.UpdateCouponRoom(couponId, roomId, record);

                if (updated)
                {
                    return StatusCode(200, "Coupon-room updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Coupon-room not found.");
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

        // Delete coupon-room by id
        //[Authorize]
        [HttpDelete("delete/{couponId}/{roomId}")]
        public IActionResult DeleteCouponRoom(int couponId, int roomId)
        {
            try
            {
                bool deleted = _couponRoomsBL.DeleteCouponRoom(couponId, roomId);

                if (deleted)
                {
                    return StatusCode(200, "Coupon-room deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Coupon-room not found.");
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
