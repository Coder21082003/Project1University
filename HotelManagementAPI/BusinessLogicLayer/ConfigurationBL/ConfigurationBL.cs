using BusinessLogicLayer.Exceptions;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ConfigurationBL : BaseBL<Configuration>, IConfigurationBL
    {
        #region Field

        List<string> Errors = new List<string>();

        #endregion
        public ConfigurationBL(IBaseDL<Configuration> baseDL) : base(baseDL)
        {
        }

        protected override void Validate(Configuration record, Method method)
        {
            if (string.IsNullOrEmpty(record.ConfigName))
            {
                Errors.Add("Thiếu tên");
            };

            if (string.IsNullOrEmpty(record.ConfigValue))
            {
                Errors.Add("Thiếu nội dung");
            };

            if (Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }
    }
}
