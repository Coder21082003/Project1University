using CommonDataLayer.DTO;
using CommonDataLayer.Untilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient; // Thay đổi từ MySqlConnector
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Methods

        public int DeleteRecords(string ids)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            string storedProc = $"Proc_Base_MultiDelete";

            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
            string tableKey = "";
            if (primaryKeyProp != null)
            {
                tableKey = primaryKeyProp.Name;
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Ids", ids); // Thay đổi dấu $ thành @ cho SQL Server
            parameters.Add("@TableName", tableName);
            parameters.Add("@TableKey", tableKey);
            parameters.Add("@DeletedDate", EntityUntilities.GetNowTimestamp());

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString)) // Thay đổi từ MySqlConnection thành SqlConnection
            {
                int affectedRows = sqlConnection.Execute(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return affectedRows;
            }
        }

        public T GetRecordById(Guid id)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            string storedProc = $"Proc_{tableName}_GetDetail";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id); // Thay đổi dấu $ thành @ cho SQL Server

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString)) // Thay đổi từ MySqlConnection thành SqlConnection
            {
                T record = sqlConnection.QueryFirstOrDefault<T>(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return record;
            }
        }

        public PagingData<T> FilterRecord(FilterData filterData)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            string storedProc = $"Proc_{tableName}_FilterRecord";

            var parameters = new DynamicParameters();

            parameters.Add("@Where", filterData.Condition); // Thay đổi dấu $ thành @ cho SQL Server
            parameters.Add("@Sort", filterData.Sort);
            parameters.Add("@Offset", (filterData.Page - 1) * filterData.Limit);
            parameters.Add("@Limit", filterData.Limit);

            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString)) // Thay đổi từ MySqlConnection thành SqlConnection
            {
                var result = sqlConnection.QueryMultiple(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return new PagingData<T>()
                {
                    Data = result.Read<T>().ToList(),
                    TotalCount = result.Read<long>().Single()
                };
            }
        }

        public Guid InsertOneRecord(T record)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            string storedProc = $"Proc_{tableName}_InsertOne";

            // Chuẩn bị tham số
            var parameters = new DynamicParameters();

            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var propName = $"@{prop.Name}"; // Thay đổi dấu $ thành @ cho SQL Server
                var propValue = prop.GetValue(record);
                parameters.Add(propName, propValue);
            }

            // Thực hiện lệnh với tham số đầu vào
            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString)) // Thay đổi từ MySqlConnection thành SqlConnection
            {
                int affectedRow = sqlConnection.Execute(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var result = Guid.Empty;
                if (affectedRow > 0)
                {
                    var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
                    var newID = primaryKeyProp?.GetValue(record);

                    if (newID != null)
                    {
                        result = (Guid)newID;
                    }
                }
                return result;
            }
        }

        public Guid UpdateOneRecord(T record)
        {
            string tableName = EntityUntilities.GetTableName<T>();
            string storedProc = $"Proc_{tableName}_UpdateOne";

            // Chuẩn bị tham số
            var parameters = new DynamicParameters();

            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var propName = $"@{prop.Name}"; // Thay đổi dấu $ thành @ cho SQL Server
                var propValue = prop.GetValue(record);
                parameters.Add(propName, propValue);
            }

            // Thực hiện lệnh với tham số đầu vào
            using (var sqlConnection = new SqlConnection(DatabaseContext.ConnectionString)) // Thay đổi từ MySqlConnection thành SqlConnection
            {
                int affectedRow = sqlConnection.Execute(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var result = Guid.Empty;
                if (affectedRow > 0)
                {
                    var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
                    var updatedID = primaryKeyProp?.GetValue(record);

                    if (updatedID != null)
                    {
                        result = (Guid)updatedID;
                    }
                }
                return result;
            }
        }

        #endregion
    }
}
