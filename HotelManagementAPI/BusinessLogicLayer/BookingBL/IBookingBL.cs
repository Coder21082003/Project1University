using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public interface IBookingBL : IBaseBL<Booking>
    {
        public IEnumerable<BookingWithName> GetAllBooking();
    }
}
