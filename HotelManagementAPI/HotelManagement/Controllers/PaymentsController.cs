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
    public class PaymentsController : ControllerBase
    {
        #region Field

        private IPaymentBL _paymentsBL;

        #endregion

        #region Constructor

        public PaymentsController(IPaymentBL paymentsBL)
        {
            _paymentsBL = paymentsBL;
        }

        #endregion

        #region Method

        // Get all payments
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllPayments()
        {
            try
            {
                var getAllPayments = _paymentsBL.GetAllPayments();
                if (getAllPayments != null)
                {
                    return StatusCode(200, getAllPayments);
                }
                else
                {
                    return StatusCode(404, "No payments found.");
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

        // Filter payments
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterPayments([FromBody] FilterPayment filterPayment)
        {
            try
            {
                var filteredPayments = _paymentsBL.GetFilteredPayments(filterPayment);
                if (filteredPayments != null)
                {
                    return StatusCode(200, filteredPayments);
                }
                else
                {
                    return StatusCode(404, "No payments found.");
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

        // Insert new payment
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertPayment([FromBody] Payment record)
        {
            try
            {
                int insertedId = _paymentsBL.InsertPayment(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting payment.");
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

        // Update payment by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdatePayment(int id, [FromBody] Payment record)
        {
            try
            {
                bool updated = _paymentsBL.UpdatePayment(id, record);

                if (updated)
                {
                    return StatusCode(200, "Payment updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Payment not found.");
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

        // Delete payment by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeletePayment(int id)
        {
            try
            {
                bool deleted = _paymentsBL.DeletePayment(id);

                if (deleted)
                {
                    return StatusCode(200, "Payment deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Payment not found.");
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
