using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Enum;
using CommonDataLayer.Untilities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace BusinessLogicLayer
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private readonly IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Methods

        public int DeleteRecords(List<int> ids)
        {
            // Chuyển danh sách ID thành chuỗi các ID cách nhau bằng dấu phẩy
            string idsString = string.Join(",", ids);
            return _baseDL.DeleteRecords(idsString);
        }

        public int DeleteOneRecord(int id)
        {
            return _baseDL.DeleteOneRecord(id);
        }

        public T GetRecordById(int id)
        {
            return _baseDL.GetRecordById(id);
        }

        public PagingData<T> FilterRecord(FilterBase filterData)
        {
            FilterData filter = new()
            {
                Limit = filterData.Limit,
                Page = filterData.Page
            };

            var descAttr = typeof(T).GetProperties().FirstOrDefault(prop =>
            {
                if (prop.GetCustomAttributes(typeof(DescAttribute), true).Count() < 0) return false;
                bool isAttr = false;
                var attributes = prop.GetCustomAttributes(typeof(DescAttribute), true);
                foreach (DescAttribute attr in attributes)
                {
                    if (attr.Description == "Name")
                    {
                        isAttr = true;
                        break;
                    }
                }
                         
                return isAttr;
            });

            if (!String.IsNullOrEmpty(filterData.Name))
            {
                filter.Condition = $"{descAttr?.Name} = '{filterData.Name}'";
            }
            else
            {
                filter.Condition = "";
            }
            CheckSqlInjectionFilter(filter);
            return _baseDL.FilterRecord(filter);
        }

        public int InsertOneRecord(T record)
        {
            CheckSqlInjection(record);
            Validate(record, Method.Insert);
            return _baseDL.InsertOneRecord(record);
        }

        public int UpdateOneRecord(int id, T record)
        {
            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);

            if (primaryKeyProp != null)
            {
                primaryKeyProp.SetValue(record, id);
            }

            CheckSqlInjection(record);
            Validate(record, Method.Update);
            return _baseDL.UpdateOneRecord(record);
        }

        protected virtual void Validate(T record, Method method)
        {
            // Thực hiện các kiểm tra hợp lệ cho bản ghi tùy thuộc vào phương thức
        }

        /// <summary>
        /// Hàm check SqlInjection các trường đẩy lên từ client
        /// </summary>
        /// <param name="record"></param>
        /// <exception cref="ValidateException"></exception>
        protected void CheckSqlInjection(T record)
        {
            var props = typeof(T).GetProperties();
            var descAttr = props.FirstOrDefault(prop =>
            {
                if (prop.GetCustomAttributes(typeof(DescAttribute), true).Count() < 0) return false;
                bool isAttr = false;
                var attributes = prop.GetCustomAttributes(typeof(DescAttribute), true);
                foreach (DescAttribute attr in attributes)
                {
                    if (attr.Description == "AllowMinus")
                    {
                        isAttr = true;
                        break;
                    }
                }

                return isAttr;
            });
            var primaryKeyProp = props.FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(record);

                if (descAttr != null && descAttr.GetValue(record) == propValue) break;
                if (primaryKeyProp != null && primaryKeyProp.GetValue(record).Equals(propValue)) break;
                if (propValue is String)
                {
                    if (!EntityUntilities.IsnotSqlInjection((String)propValue))
                    {
                        List<string> Error = new List<string>();
                        Error.Add("Các trường điền vào có ký tự không phù hợp");
                        throw new ValidateException(Error);
                    }
                }
            }
        }

        /// <summary>
        /// Hàm check SqlInjection các trường filter
        /// </summary>
        /// <param name="record"></param>
        /// <exception cref="ValidateException"></exception>
        protected void CheckSqlInjectionFilter(FilterData record) 
        {
            var props = typeof(FilterData).GetProperties();
            foreach (var prop in props)
            {
                var propValue = prop.GetValue(record);
                if (propValue is String)
                {
                    if (!EntityUntilities.IsnotSqlInjection((String)propValue))
                    {
                        List<string> Error = new List<string>();
                        Error.Add("Các trường điền vào có ký tự không phù hợp");
                        throw new ValidateException(Error);
                    }
                }
            }
        }

        /// <summary>
        /// Hàm kiểm tra email đúng định dạng
        /// </summary>
        /// <param name="email">Email cần kiểm tra</param>
        /// <returns>true/false</returns>
        public static bool IsEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static bool IsPhoneNo(string phoneNo)
        {
            if (String.IsNullOrEmpty(phoneNo))
            {
                return false;
            }
            return Regex.IsMatch(phoneNo, @"^[0-9]{9,15}$");
        }

        public IEnumerable<T> GetAll()
        {
            return _baseDL.GetAll();
        }

        #endregion
    }
}
