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
    public class CouponController : BaseController<Coupon>
    {
        #region Field

        private ICouponBL _couponBL;

        #endregion

        #region Constructor

        public CouponController(ICouponBL couponBL) : base(couponBL)
        {
            _couponBL = couponBL;
        }

        #endregion

        // Add additional endpoints specific to Coupon if needed
    }
}