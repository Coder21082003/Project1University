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
    public class CouponsController : ControllerBase
    {
        #region Field

        private ICouponBL _couponBL;

        #endregion

        #region Constructor

        public CouponsController(ICouponBL couponBL)
        {
            _couponBL = couponBL;
        }

        #endregion

        #region Method

        // Get all coupons
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllCoupons()
        {
            try
            {
                var getAllCoupons = _couponBL.GetAllCoupons();
                if (getAllCoupons != null)
                {
                    return StatusCode(200, getAllCoupons);
                }
                else
                {
                    return StatusCode(404, "No coupons found.");
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

        // Filter coupons
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterCoupons([FromBody] FilterCoupon filterCoupon)
        {
            try
            {
                var filteredCoupons = _couponBL.GetFilteredCoupons(filterCoupon);
                if (filteredCoupons != null)
                {
                    return StatusCode(200, filteredCoupons);
                }
                else
                {
                    return StatusCode(404, "No coupons found.");
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

        // Insert new coupon
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertCoupon([FromBody] Coupon record)
        {
            try
            {
                int insertedId = _couponBL.InsertCoupon(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting coupon.");
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

        // Update coupon by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateCoupon(int id, [FromBody] Coupon record)
        {
            try
            {
                bool updated = _couponBL.UpdateCoupon(id, record);

                if (updated)
                {
                    return StatusCode(200, "Coupon updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Coupon not found.");
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

        // Delete coupon by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCoupon(int id)
        {
            try
            {
                bool deleted = _couponBL.DeleteCoupon(id);

                if (deleted)
                {
                    return StatusCode(200, "Coupon deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Coupon not found.");
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
