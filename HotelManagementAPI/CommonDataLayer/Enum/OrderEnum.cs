using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataLayer.Enum
{
    public enum OrderStatus
    {
        NotOrdered = 1,         // chưa đặt hàng
        PinkingUp = 2,          // đang lấy hàng
        Packed = 3,             // đã đóng gói
        OngoingDeliveries = 4,  // đang vận chuyển
        Delivered = 5           // đã nhận hàng
    }

    public enum OrderIsPaid
    {
        NotPaid = 1, // chưa thanh toán
        Paid = 2,   // đã thanh toán
    }
}
