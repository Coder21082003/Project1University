using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.RoomDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.ServiceBL
{
    public class ServiceBL : BaseBL<Service>, IServiceBL
    {
        #region Field

        private readonly IServiceDL _serviceDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public ServiceBL(IServiceDL serviceDL) : base(serviceDL)
        {
            _serviceDL = serviceDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for Service here
        // For example:
        // public void SomeServiceMethod() { ... }

        #endregion
    }
}
