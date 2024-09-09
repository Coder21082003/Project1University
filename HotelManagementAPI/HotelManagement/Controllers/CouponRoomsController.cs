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
    public class CouponRoomController : BaseController<CouponRoom>
    {
        #region Field

        private ICouponRoomBL _couponRoomBL;

        #endregion

        #region Constructor

        public CouponRoomController(ICouponRoomBL couponRoomBL) : base(couponRoomBL)
        {
            _couponRoomBL = couponRoomBL;
        }

        #endregion

        // Add additional endpoints specific to CouponRoom if needed
    }
}