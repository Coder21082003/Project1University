using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BaseController(IBaseBL<T> baseBl)
        {
            _baseBL = baseBl;
        }

        #endregion

        #region Methods

        [HttpGet("all")]
        public IActionResult GetAllRecords()
        {
            try
            {
                var records = _baseBL.GetAll();
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

        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertRecord([FromBody] T record)
        {
            try
            {
                int insertedId = _baseBL.InsertOneRecord(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "e001");
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

        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterRecords([FromBody] FilterBase filterData)
        {
            try
            {
                var multiResult = _baseBL.FilterRecord(filterData);
                if (multiResult != null)
                {
                    return StatusCode(200, multiResult);
                }
                else
                {
                    return StatusCode(500, "e001");
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

        //[Authorize]
        [HttpGet("{Id}")]
        public IActionResult GetRecordById([FromRoute] string Id)
        {
            try
            {
                int id = int.Parse(Id);
                T record = _baseBL.GetRecordById(id);
                if (record != null)
                {
                    return StatusCode(200, record);
                }
                else
                {
                    return StatusCode(404, "Không tồn tại");
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

        [HttpDelete("{Id}")]
        public IActionResult DeleteOneRecord([FromRoute] int Id)
        {
            try
            {
                int deletedCount = _baseBL.DeleteOneRecord(Id);

                if (deletedCount > 0)
                {
                    return StatusCode(200, new
                    {
                        DeletedId = Id,
                        DeletedCount = deletedCount
                    });
                }
                else
                {
                    return StatusCode(404, "Không tìm thấy bản ghi để xóa.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        //[Authorize]
        [HttpPost("multiDelete")]
        public IActionResult MultiDeleteRecords([FromBody] List<int> ids)
        {
            try
            {
                int deletedCount = _baseBL.DeleteRecords(ids);
                if (deletedCount > 0)
                {
                    return StatusCode(200, new
                    {
                        TotalId = ids.Count(),
                        DeletedIds = deletedCount
                    });
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[Authorize]
        [HttpPost("update/{Id}")]
        public IActionResult UpdateRecord(int Id, [FromBody] T record)
        {
            try
            {
                int updateId = _baseBL.UpdateOneRecord(Id, record);

                if (updateId > 0)
                {
                    return StatusCode(201, updateId);
                }
                else
                {
                    return StatusCode(500, "e001");
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
        #endregion
    }
}