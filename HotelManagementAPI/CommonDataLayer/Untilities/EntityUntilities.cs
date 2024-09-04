using CommonDataLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonDataLayer.Untilities
{
    public static class EntityUntilities
    {
        /// <summary>
        /// Lấy tên bảng của entity
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của entity</typeparam>
        /// <returns>Tên bảng</returns>
        /// LHNAM (25/08/2022)
        public static string GetTableName<T>()
        {
            string tableName = typeof(T).Name;
            var tableAttr = typeof(T).GetTypeInfo().GetCustomAttributes<TableAttribute>();

            if (tableAttr.Count() > 0)
            {
                tableName = tableAttr.First().Name;
            }

            return tableName;

        }

        /// <summary>
        /// Hàm lấy giá trị timestamp hiện tại
        /// Author: LHNAM (6/7/2023)
        /// </summary>
        /// <returns></returns>
        public static int GetNowTimestamp()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static bool IsnotSqlInjection(string str)
        {
            if(String.IsNullOrEmpty(str)) return true;

            return !Regex.IsMatch(str, @"[\-]");
        }
    }
}
