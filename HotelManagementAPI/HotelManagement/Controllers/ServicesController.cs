using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.ServiceBL;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseController<Service>
    {
        #region Field

        private IServiceBL _serviceBL;

        #endregion

        #region Constructor

        public ServiceController(IServiceBL serviceBL) : base(serviceBL)
        {
            _serviceBL = serviceBL;
        }

        #endregion

        // Add additional endpoints specific to Service if needed
    }
}
