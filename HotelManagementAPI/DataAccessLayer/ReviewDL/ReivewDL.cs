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

namespace DataAccessLayer.ReviewDL
{
    public class ReivewDL : BaseDL<Review>, IReviewDL
    {
        public IEnumerable<ReviewWithName> GetAllReview()
        {
            // Tên bảng cho review, user và room
            string reviewTableName = EntityUntilities.GetTableName<Review>();
            string userTableName = EntityUntilities.GetTableName<User>();
            string roomTableName = EntityUntilities.GetTableName<Room>();

            // Câu query để join bảng reviews, users và rooms
            var query = new StringBuilder()
                .AppendLine($"SELECT r.ReviewId, u.Name AS UserName, ro.room_type AS RoomName,")
                .AppendLine($"r.rating, r.comment, r.created_at, r.updated_at")
                .AppendLine($"FROM {reviewTableName} r")
                .AppendLine($"JOIN {userTableName} u ON r.UserId = u.UserId")
                .AppendLine($"JOIN {roomTableName} ro ON r.RoomId = ro.RoomId");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                // Fetch all review records with user names and room names
                var reviewsWithName = sqlConnection.Query<ReviewWithName>(query.ToString());
                return reviewsWithName;
            }
        }

    }
}
