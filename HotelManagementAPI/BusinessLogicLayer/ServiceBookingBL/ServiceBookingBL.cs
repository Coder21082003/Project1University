using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.RoomDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.ServiceBL
{
    public class ServiceBookingBL : BaseBL<ServiceBooking>, IServiceBookingBL
    {
        #region Field

        private readonly IServiceBookingDL _serviceBookingDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public ServiceBookingBL(IServiceBookingDL serviceBookingDL) : base(serviceBookingDL)
        {
            _serviceBookingDL = serviceBookingDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for Service here
        // For example:
        // public void SomeServiceMethod() { ... }

        #endregion
    }
}
