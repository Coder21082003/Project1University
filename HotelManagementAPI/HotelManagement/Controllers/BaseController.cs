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

        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertRecord([FromBody] T record)
        {
            try
            {
                Guid insertedId = _baseBL.InsertOneRecord(record);

                if (insertedId != Guid.Empty)
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

        [Authorize]
        [HttpGet("{Id}")]
        public IActionResult GetRecordById([FromRoute] Guid id)
        {
            try
            {
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

        [Authorize]
        [HttpPost("delete")]
        public IActionResult MultiDeleteRecords([FromBody] List<Guid> ids)
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
        public IActionResult UpdateRecord(Guid Id, [FromBody] T record)
        {
            try
            {
                Guid updateId = _baseBL.UpdateOneRecord(Id, record);

                if (updateId != Guid.Empty)
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