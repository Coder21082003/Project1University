using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using CommonDataLayer.Untilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DataAccessLayer.UserDL
{
    public class UserDL : BaseDL<User>, IUserDL
    {
        #region Login
        public (int level, int status)? Login(string email, string password)
        {
            string TableName = EntityUntilities.GetTableName<User>();

            var query = new StringBuilder()
                .AppendLine($"SELECT level, status FROM {TableName} WHERE")
                .AppendLine("email = @Email AND password = @Password");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                var result = sqlConnection.QueryFirstOrDefault<(int level, int status)>(
                    query.ToString(),
                    new { Email = email, Password = password }
                );

                return result;
            }
        }
        #endregion


        #region Register
        //Lấy thông tin email, password
        public (string name, string email, string password)? Register(string name, string email, string password)
        {
            string TableName = EntityUntilities.GetTableName<User>();

            var query = new StringBuilder()
                .AppendLine($"SELECT email FROM {TableName} WHERE")
                .AppendLine("email = @Email");

            try
            {
                using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
                {
                    // Mở kết nối SQL
                    sqlConnection.Open();

                    // Thực hiện truy vấn (giả sử query logic ở đây)
                    using (var command = new SqlCommand(query.ToString(), sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // Email đã tồn tại
                            throw new Exception("Email already exists.");
                        }
                    }

                    // Nếu không có lỗi, trả về email và password
                    return (name, email, password);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error: {ex.Message}");
                return null;  // Trả về null nếu có lỗi
            }
        }




        #region gửi và lưu mã
        //Xác thực mã
        public (int code, DateTime exprided)? SendEmailCode(string email)
        {
            // Bước 1: Tạo mã số ngẫu nhiên gồm 6 chữ số
            Random random = new Random();
            int code = random.Next(100000, 999999);

            // Bước 2: Nội dung email
            string subject = "Your Verification Code";
            string body = $"Your verification code is: {code}" +
                $"\n It will exprided after 10 minutes";

            // Bước 3: Cấu hình thông tin email (SMTP)
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("luxuryhotel211242321@gmail.com");  // Địa chỉ email của bạn (đã sửa)
                    mail.To.Add(email);  // Địa chỉ email người nhận
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))  // Cấu hình SMTP của bạn
                    {
                        smtp.Credentials = new NetworkCredential("luxuryhotel211242321@gmail.com", "iqku mewf vnnf nilp");  // Email và mật khẩu của bạn
                        smtp.EnableSsl = true;  // Bật SSL để bảo mật

                        smtp.Send(mail);  // Gửi email
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return (-1, DateTime.Now.AddMinutes(10));  // Trả về -1 nếu gửi email thất bại
            }

            // Bước 4: Trả về mã code
            return (code, DateTime.Now.AddMinutes(10));
        }

        #endregion
        #endregion
    }
}
