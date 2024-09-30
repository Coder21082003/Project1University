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
    public class ReviewController : BaseController<Review>
    {
        #region Field

        private IReviewBL _reviewBL;

        #endregion

        #region Constructor

        public ReviewController(IReviewBL reviewBL) : base(reviewBL)
        {
            _reviewBL = reviewBL;
        }

        #endregion

        // Add additional endpoints specific to Review if needed
        [HttpGet("allReview")]
        public IActionResult GetAllBookings()
        {
            try
            {
                var records = _reviewBL.GetAllReview();
                if (records != null)
                {
                    return StatusCode(200, records);
                }
                else
                {
                    return StatusCode(404, "Không có dữ liệu");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}