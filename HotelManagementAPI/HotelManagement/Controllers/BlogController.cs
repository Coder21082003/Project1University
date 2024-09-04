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
    public class BlogController : ControllerBase
    {
        #region Field

        private IBlogBL _blogBL;

        #endregion

        #region Constructor

        public BlogController(IBlogBL blogBL)
        {
            _blogBL = blogBL;
        }

        #endregion

        #region Method

        // Filter blogs
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllBlogs()
        {
            try
            {
                var getAllBlogs = _blogBL.GetAllBlogs();
                if (getAllBlogs != null)
                {
                    return StatusCode(200, getAllBlogs);
                }
                else
                {
                    return StatusCode(404, "No blogs found.");
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


        // Filter blogs
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterBlogs([FromBody] FilterBlog filterBlog)
        {
            try
            {
                var filteredBlogs = _blogBL.GetFilteredBlogs(filterBlog);
                if (filteredBlogs != null)
                {
                    return StatusCode(200, filteredBlogs);
                }
                else
                {
                    return StatusCode(404, "No blogs found.");
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

        // Insert new blog
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertBlog([FromBody] Blog record)
        {
            try
            {
                int insertedId = _blogBL.InsertBlog(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting blog.");
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

        // Update blog by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateBlog(int id, [FromBody] Blog record)
        {
            try
            {
                bool updated = _blogBL.UpdateBlog(id, record);

                if (updated)
                {
                    return StatusCode(200, "Blog updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Blog not found.");
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

        // Delete blog by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            try
            {
                bool deleted = _blogBL.DeleteBlog(id);

                if (deleted)
                {
                    return StatusCode(200, "Blog deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Blog not found.");
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
