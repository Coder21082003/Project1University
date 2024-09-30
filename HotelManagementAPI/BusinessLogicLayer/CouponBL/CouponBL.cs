using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using DataAccessLayer;
using DataAccessLayer.CouponDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.CouponBL
{
    public class SerivceBL : BaseBL<Coupon>, ICouponBL
    {
        #region Field

        private readonly ICouponDL _couponDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public SerivceBL(ICouponDL couponDL) : base(couponDL)
        {
            _couponDL = couponDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for Coupon here
        // For example:
        // public void SomeCouponMethod() { ... }

        #endregion
    }
}
