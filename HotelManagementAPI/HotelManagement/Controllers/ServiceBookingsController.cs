using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBookingController : BaseController<ServiceBooking>
    {
        #region Field

        private IServiceBookingBL _serviceBookingBL;

        #endregion

        #region Constructor

        public ServiceBookingController(IServiceBookingBL serviceBookingBL) : base(serviceBookingBL)
        {
            _serviceBookingBL = serviceBookingBL;
        }

        #endregion

        // Add additional endpoints specific to ServiceBooking if needed
    }
}
