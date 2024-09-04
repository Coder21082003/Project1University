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
    public class BookingController : ControllerBase
    {
        #region Field

        private IBookingBL _bookingBL;

        #endregion

        #region Constructor

        public BookingController(IBookingBL bookingBL)
        {
            _bookingBL = bookingBL;
        }

        #endregion

        #region Method

        // Get all bookings
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllBookings()
        {
            try
            {
                var getAllBookings = _bookingBL.GetAllBookings();
                if (getAllBookings != null)
                {
                    return StatusCode(200, getAllBookings);
                }
                else
                {
                    return StatusCode(404, "No bookings found.");
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

        // Filter bookings
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterBookings([FromBody] FilterBooking filterBooking)
        {
            try
            {
                var filteredBookings = _bookingBL.GetFilteredBookings(filterBooking);
                if (filteredBookings != null)
                {
                    return StatusCode(200, filteredBookings);
                }
                else
                {
                    return StatusCode(404, "No bookings found.");
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

        // Insert new booking
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertBooking([FromBody] Booking record)
        {
            try
            {
                int insertedId = _bookingBL.InsertBooking(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting booking.");
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

        // Update booking by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] Booking record)
        {
            try
            {
                bool updated = _bookingBL.UpdateBooking(id, record);

                if (updated)
                {
                    return StatusCode(200, "Booking updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Booking not found.");
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

        // Delete booking by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            try
            {
                bool deleted = _bookingBL.DeleteBooking(id);

                if (deleted)
                {
                    return StatusCode(200, "Booking deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Booking not found.");
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
