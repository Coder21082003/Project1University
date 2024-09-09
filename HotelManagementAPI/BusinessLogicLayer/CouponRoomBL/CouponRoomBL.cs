using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.CouponRoomDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.CouponRoomBL
{
    public class CouponRoomBL : BaseBL<CouponRoom>, ICouponRoomBL
    {
        #region Field

        private readonly ICouponRoomDL _couponRoomDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public CouponRoomBL(ICouponRoomDL couponRoomDL) : base(couponRoomDL)
        {
            _couponRoomDL = couponRoomDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for CouponRoom here
        // For example:
        // public IEnumerable<CouponRoom> GetCouponRoomsByCouponId(int couponId)
        // {
        //     return _couponRoomDL.GetCouponRoomsByCouponId(couponId);
        // }

        #endregion
    }
}
