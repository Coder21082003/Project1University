using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogDL : BaseDL<Blog>, IBlogDL
    {
        // Kiểm tra tên blog có bị trùng lặp không
        public bool CheckDuplicateName(Method method, int id, string title)
        {
            string query = method == Method.Insert
                ? "SELECT COUNT(1) FROM [blog] WHERE [blog_title] = @Title"
                : "SELECT COUNT(1) FROM [blog] WHERE [blog_title] = @Title AND [blog_id] != @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Title", title);
            parameters.Add("@Id", id);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    int count = sqlConnection.ExecuteScalar<int>(query, parameters);
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking for duplicate blog name: " + ex.Message, ex);
                }
            }
        }

        //Lấy tất cả blog 
        public IEnumerable<Blog> GetAllBlogs()
        {
            // Câu truy vấn SQL để lấy tất cả blog từ bảng "blog"
            string query = "SELECT * FROM [blog]";

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    // Thực hiện câu truy vấn và trả về danh sách các blog
                    return sqlConnection.Query<Blog>(query);
                }
                catch (Exception ex)
                {
                    // Ném ngoại lệ nếu có lỗi xảy ra
                    throw new Exception("Error fetching all blogs: " + ex.Message, ex);
                }
            }
        }




        // Lấy danh sách blog theo điều kiện
        public IEnumerable<Blog> GetFilteredBlogs(FilterBlog filterBlog)
        {
            // Query để lấy tất cả blog nếu không có điều kiện lọc
            string query = @"
                SELECT * FROM [blog]
                WHERE (@Title IS NULL OR [blog_title] LIKE '%' + @Title + '%')
                ORDER BY [blog_time] DESC
                OFFSET @Offset ROWS
                FETCH NEXT @Limit ROWS ONLY";

            var parameters = new DynamicParameters();
            parameters.Add("@Title", filterBlog.BlogTitle);
            parameters.Add("@Offset", (filterBlog.Page - 1) * filterBlog.Limit);
            parameters.Add("@Limit", filterBlog.Limit);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    return sqlConnection.Query<Blog>(query, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching filtered blogs: " + ex.Message, ex);
                }
            }
        }

        // Thêm blog mới
        public int Insert(Blog blog)
        {
            string query = @"
                INSERT INTO [blog] ([image], [blog_title], [blog_author], [blog_time], [blog_description], [created_at], [updated_at])
                VALUES (@Image, @BlogTitle, @BlogAuthor, @BlogTime, @BlogDescription, @CreatedAt, @UpdatedAt);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parameters = new DynamicParameters();
            parameters.Add("@Image", blog.Image);
            parameters.Add("@BlogTitle", blog.BlogTitle);
            parameters.Add("@BlogAuthor", blog.BlogAuthor);
            parameters.Add("@BlogTime", blog.BlogTime);
            parameters.Add("@BlogDescription", blog.BlogDescription);
            parameters.Add("@CreatedAt", blog.CreatedAt ?? DateTime.UtcNow);
            parameters.Add("@UpdatedAt", blog.UpdatedAt ?? DateTime.UtcNow);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    return sqlConnection.ExecuteScalar<int>(query, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inserting blog: " + ex.Message, ex);
                }
            }
        }

        // Cập nhật blog theo ID
        public bool Update(int id, Blog blog)
        {
            string query = @"
                UPDATE [blog]
                SET [image] = @Image,
                    [blog_title] = @BlogTitle,
                    [blog_author] = @BlogAuthor,
                    [blog_time] = @BlogTime,
                    [blog_description] = @BlogDescription,
                    [updated_at] = @UpdatedAt
                WHERE [blog_id] = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);  // ID vẫn cần để cập nhật đúng bản ghi
            parameters.Add("@Image", blog.Image);
            parameters.Add("@BlogTitle", blog.BlogTitle);
            parameters.Add("@BlogAuthor", blog.BlogAuthor);
            parameters.Add("@BlogTime", blog.BlogTime);
            parameters.Add("@BlogDescription", blog.BlogDescription);
            parameters.Add("@UpdatedAt", blog.UpdatedAt ?? DateTime.UtcNow);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    int rowsAffected = sqlConnection.Execute(query, parameters);
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating blog: " + ex.Message, ex);
                }
            }
        }

        // Xóa blog theo ID
        public bool Delete(int id)
        {
            string query = "DELETE FROM [blog] WHERE [blog_id] = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    int rowsAffected = sqlConnection.Execute(query, parameters);
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting blog: " + ex.Message, ex);
                }
            }
        }

        public bool CheckDuplicateTitle(Guid id, string title)
        {
            throw new NotImplementedException();
        }

        public bool CheckDuplicateTitle(int blogId, string blogTitle)
        {
            throw new NotImplementedException();
        }
    }
}
