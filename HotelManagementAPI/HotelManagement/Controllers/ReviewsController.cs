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
    public class ReviewsController : ControllerBase
    {
        #region Field

        private IReviewBL _reviewsBL;

        #endregion

        #region Constructor

        public ReviewsController(IReviewBL reviewsBL)
        {
            _reviewsBL = reviewsBL;
        }

        #endregion

        #region Method

        // Get all reviews
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllReviews()
        {
            try
            {
                var getAllReviews = _reviewsBL.GetAllReviews();
                if (getAllReviews != null)
                {
                    return StatusCode(200, getAllReviews);
                }
                else
                {
                    return StatusCode(404, "No reviews found.");
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

        // Filter reviews
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterReviews([FromBody] FilterReviews filterReview)
        {
            try
            {
                var filteredReviews = _reviewsBL.GetFilteredReviews(filterReview);
                if (filteredReviews != null)
                {
                    return StatusCode(200, filteredReviews);
                }
                else
                {
                    return StatusCode(404, "No reviews found.");
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

        // Insert new review
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertReview([FromBody] Review record)
        {
            try
            {
                int insertedId = _reviewsBL.InsertReview(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting review.");
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

        // Update review by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateReview(int id, [FromBody] Review record)
        {
            try
            {
                bool updated = _reviewsBL.UpdateReview(id, record);

                if (updated)
                {
                    return StatusCode(200, "Review updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Review not found.");
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

        // Delete review by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteReview(int id)
        {
            try
            {
                bool deleted = _reviewsBL.DeleteReview(id);

                if (deleted)
                {
                    return StatusCode(200, "Review deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Review not found.");
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
