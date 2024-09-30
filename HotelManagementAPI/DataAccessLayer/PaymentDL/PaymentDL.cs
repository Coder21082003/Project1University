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

namespace DataAccessLayer.PaymentDL
{
    public class PaymentDL : BaseDL<Payment>, IPaymentDL
    {
        public IEnumerable<PaymentWithName> GetAllPayment()
        {
            // Tên bảng cho payment, booking, user và room
            string paymentTableName = EntityUntilities.GetTableName<Payment>();
            string bookingTableName = EntityUntilities.GetTableName<Booking>();
            string userTableName = EntityUntilities.GetTableName<User>();
            string roomTableName = EntityUntilities.GetTableName<Room>();

            var query = new StringBuilder()
                .AppendLine($"SELECT p.PaymentId, ")
                .AppendLine($"CONCAT(b.BookingId, ' (', u.Name, ')') AS BookingName,") // Ghép BookingId với UserName
                .AppendLine($"r.room_type AS RoomName,")
                .AppendLine($"p.payment_method, p.payment_status, p.amount, p.payment_date, p.created_at, p.updated_at")
                .AppendLine($"FROM {paymentTableName} p")
                .AppendLine($"JOIN {bookingTableName} b ON p.BookingId = b.BookingId")
                .AppendLine($"JOIN {userTableName} u ON b.UserId = u.UserId")
                .AppendLine($"JOIN {roomTableName} r ON b.RoomId = r.RoomId");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                // Fetch all payment records with user names and room names
                var paymentsWithName = sqlConnection.Query<PaymentWithName>(query.ToString());
                return paymentsWithName;
            }
        }


    }
}
