using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataLayer.Enum
{
    public enum Gender
    {
        // Nam
        Male = 1,
        // Nữ
        Female = 2,
        // Khác
        Othor = 3,
    }

    public enum Method
    {
        // Phương thức thêm mới
        Insert = 1,

        // Phương thức sửa
        Update = 2
    }

    public enum Level
    {
        //quan tri vien
        Admin =0,

        //quan ly 
        Management = 1,

        //Le tan
        Servicer = 2,

        //Nguoi dung
        User = 3,

    }
}
