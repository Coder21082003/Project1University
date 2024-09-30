using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using CommonDataLayer.Untilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BookingDL
{
    public class BookingDL : BaseDL<Booking>, IBookingDL
    {
        public IEnumerable<BookingWithName> GetAllBooking()
        {
            // Tên bảng cho các booking, user, và room
            string bookingTableName = EntityUntilities.GetTableName<Booking>();
            string userTableName = EntityUntilities.GetTableName<User>();
            string roomTableName = EntityUntilities.GetTableName<Room>();

            // Câu query để join bảng bookings, users, và rooms
            var query = new StringBuilder()
                .AppendLine($"SELECT b.BookingId, u.name AS UserName, r.room_type AS RoomName,")
                .AppendLine($"b.check_in_date, b.check_out_date, b.booking_date, b.total_price, b.discount_amount, b.created_at, b.updated_at")
                .AppendLine($"FROM {bookingTableName} b")
                .AppendLine($"JOIN {userTableName} u ON b.UserId = u.UserId")
                .AppendLine($"JOIN {roomTableName} r ON b.RoomId = r.RoomId");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                // Fetch all booking records with user names and room names
                var bookingsWithName = sqlConnection.Query<BookingWithName>(query.ToString());
                return bookingsWithName;
            }
        }

    }
}