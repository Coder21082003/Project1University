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

namespace DataAccessLayer.PaymentDL
{
    public interface IPaymentDL : IBaseDL<Payment>
    {
        public IEnumerable<PaymentWithName> GetAllPayment();
    }
}
