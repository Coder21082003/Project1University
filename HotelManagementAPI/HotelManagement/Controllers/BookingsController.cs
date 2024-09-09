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
    public class BookingController : BaseController<Booking>
    {
        #region Field

        private IBookingBL _bookingBL;

        #endregion

        #region Constructor

        public BookingController(IBookingBL bookingBL) : base(bookingBL) 
        {
            _bookingBL = bookingBL;
        }

        #endregion


    }
}
