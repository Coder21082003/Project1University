using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.PaymentDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.PaymentBL
{
    public class PaymentBL : BaseBL<Payment>, IPaymentBL
    {
        #region Field

        private readonly IPaymentDL _paymentDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public PaymentBL(IPaymentDL paymentDL) : base(paymentDL)
        {
            _paymentDL = paymentDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for Payment here
        // For example:
        // public void SomePaymentMethod() { ... }

        #endregion
    }
}
