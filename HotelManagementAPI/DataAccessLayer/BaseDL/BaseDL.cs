using CommonDataLayer.DTO;
using CommonDataLayer.Untilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Methods

        public IEnumerable<T> GetAll()
        {
            string tableName = EntityUntilities.GetTableName<T>();

            var query = new StringBuilder()
                .AppendLine($"SELECT * FROM {tableName}");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                // Fetch all records
                var records = sqlConnection.Query<T>(query.ToString());
                return records;
            }
        }
        public int DeleteOneRecord(int id)
        {
            // Lấy tên bảng từ entity
            string tableName = EntityUntilities.GetTableName<T>();

            // Lấy khóa chính của bảng
            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            string tableKey = primaryKeyProp?.Name ?? "";

            // Kiểm tra nếu không tìm thấy khóa chính thì không thể thực hiện xóa
            if (string.IsNullOrEmpty(tableKey))
            {
                throw new InvalidOperationException("Unable to determine the primary key for the entity.");
            }

            // Xây dựng câu truy vấn DELETE
            var query = new StringBuilder()
                .AppendLine($"DELETE FROM {tableName}")
                .AppendLine($"WHERE {tableKey} = @Id");

            // Khởi tạo tham số cho câu truy vấn
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                // Thực hiện câu truy vấn
                int affectedRows = sqlConnection.Execute(query.ToString(), parameters);
                return affectedRows;
            }
        }

        public int DeleteRecords(string ids)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            string tableKey = primaryKeyProp?.Name ?? "";

            var query = new StringBuilder()
                .AppendLine($"DELETE FROM {tableName}")
                .AppendLine($" WHERE {tableKey} IN ({ids})");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                int affectedRows = sqlConnection.Execute(query.ToString());
                return affectedRows;
            }
        }

        public T GetRecordById(int id)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            string tableKey = primaryKeyProp?.Name ?? "";

            var query = new StringBuilder()
                .AppendLine($"SELECT * FROM {tableName}")
                .AppendLine($" WHERE {tableKey} = @Id");

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                // Fetch the record
                T record = sqlConnection.QueryFirstOrDefault<T>(query.ToString(), parameters);
                return record;
            }
        }

        public PagingData<T> FilterRecord(FilterData filterData)
        {
            string tableName = EntityUntilities.GetTableName<T>();

            // Xây dựng câu lệnh SELECT
            var query = new StringBuilder()
                .AppendLine($"SELECT * FROM {tableName}")
                .AppendLine($"WHERE {filterData.Condition}") // Đảm bảo điều kiện WHERE hợp lệ
                .AppendLine($"ORDER BY {filterData.Sort}") // Đảm bảo cột trong ORDER BY là hợp lệ
                .AppendLine($"OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY");

            var parameters = new DynamicParameters();
            parameters.Add("@Offset", (filterData.Page - 1) * filterData.Limit);
            parameters.Add("@Limit", filterData.Limit);

            // Xây dựng câu lệnh COUNT
            var countQuery = new StringBuilder()
                .AppendLine($"SELECT COUNT(1) FROM {tableName}")
                .AppendLine($"WHERE {filterData.Condition}");

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                try
                {
                    // Thực hiện câu lệnh SELECT và COUNT
                    var result = sqlConnection.QueryMultiple(query.ToString(), parameters);
                    long totalCount = sqlConnection.ExecuteScalar<long>(countQuery.ToString(), parameters);

                    return new PagingData<T>()
                    {
                        Data = result.Read<T>().ToList(),
                        TotalCount = totalCount
                    };
                }
                catch (SqlException ex)
                {
                    // Log lỗi SQL
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    // Log lỗi chung
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }


        public int InsertOneRecord(T record)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            var props = typeof(T).GetProperties();
            var columns = new StringBuilder();
            var values = new StringBuilder();
            var parameters = new DynamicParameters();

            foreach (var prop in props)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(record);

                // Skip the IDENTITY column
                if (prop.GetCustomAttributes(typeof(KeyAttribute), true).Any())
                    continue;

                if (propValue != null)
                {
                    columns.Append($"{propName}, ");
                    values.Append($"@{propName}, ");
                    parameters.Add($"@{propName}", propValue);
                }
            }

            columns.Length -= 2; // Remove trailing comma
            values.Length -= 2; // Remove trailing comma

            var query = new StringBuilder()
                .AppendLine($"INSERT INTO {tableName} ({columns})")
                .AppendLine($" VALUES ({values})")
                .AppendLine($" SELECT SCOPE_IDENTITY()"); // Get the new ID

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                int newId = sqlConnection.QuerySingle<int>(query.ToString(), parameters);
                return newId;
            }
        }


        public int UpdateOneRecord(T record)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            var props = typeof(T).GetProperties();
            var setClause = new StringBuilder();
            var parameters = new DynamicParameters();
            int id = 0;

            foreach (var prop in props)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(record);

                if (propValue != null)
                {
                    if (prop.GetCustomAttributes(typeof(KeyAttribute), true).Any())
                    {
                        id = (int)propValue;
                    }
                    else
                    {
                        setClause.Append($"{propName} = @{propName}, ");
                        parameters.Add($"@{propName}", propValue);
                    }
                }
            }

            setClause.Length -= 2; // Remove trailing comma

            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            string tableKey = primaryKeyProp?.Name ?? "";

            var query = new StringBuilder()
                .AppendLine($" UPDATE {tableName}")
                .AppendLine($" SET {setClause}")
                .AppendLine($" WHERE {tableKey} = @Id");

            parameters.Add("@Id", id);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString))
            {
                int affectedRows = sqlConnection.Execute(query.ToString(), parameters);
                return id;
            }
        }
        #endregion
    }
}
