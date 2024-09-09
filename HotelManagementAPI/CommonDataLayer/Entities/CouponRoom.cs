using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("coupon_rooms")]
    public class CouponRoom : BaseModel
    {
        [Key]
        [Column("CouponId")]
        public int CouponId { get; set; }

        [Key]
        [Column("RoomId")]
        public int RoomId { get; set; }

        //// Quan hệ với bảng `Coupon` và `Room`
        //[ForeignKey("CouponId")]
        //public Coupon Coupon { get; set; }

        //[ForeignKey("RoomId")]
        //public Room Room { get; set; }
    }
}
