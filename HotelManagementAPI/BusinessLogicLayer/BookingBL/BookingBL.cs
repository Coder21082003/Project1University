using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using DataAccessLayer;
using System;
using System.Collections.Generic;


namespace BusinessLogicLayer.BookingBL
{
    public class BookingBL : BaseBL<Booking>, IBookingBL
    {
        #region Field

        private readonly IBookingDL _blogDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public BookingBL(IBookingDL bookingDL) : base(bookingDL)
        {
            _blogDL = bookingDL;
        }

        #endregion
    }
}
