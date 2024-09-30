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
    public class PaymentController : BaseController<Payment>
    {
        #region Field

        private IPaymentBL _paymentBL;

        #endregion

        #region Constructor

        public PaymentController(IPaymentBL paymentBL) : base(paymentBL)
        {
            _paymentBL = paymentBL;
        }

        #endregion

        // Add additional endpoints specific to Payment if needed

        [HttpGet("allPayment")]
        public IActionResult GetAllBookings()
        {
            try
            {
                var records = _paymentBL.GetAllPayment();
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