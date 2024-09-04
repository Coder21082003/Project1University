using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Enum;
using CommonDataLayer.Untilities;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Methods

        public int DeleteRecords(List<Guid> ids)
        {
            string listIds = $"'{string.Join("', '", ids)}'"; 
            return _baseDL.DeleteRecords(listIds);
        }

        public T GetRecordById(Guid id)
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

            if(!String.IsNullOrEmpty(filterData.Name))
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

        public Guid InsertOneRecord(T record)
        {
            CheckSqlInjection(record);
            Validate(record, Method.Insert);
            return _baseDL.InsertOneRecord(record);
        }

        public Guid UpdateOneRecord(Guid id, T record)
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
        /// Author: LHNAM (15/06/2022)
        public static bool IsEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static bool IsPhoneNo(string phonNo)
        {
            if(String.IsNullOrEmpty(phonNo))
            {
                return false;
            }
            return Regex.IsMatch(phonNo, @"^[0-9]{9,15}$");
        }

        #endregion
    }
}
