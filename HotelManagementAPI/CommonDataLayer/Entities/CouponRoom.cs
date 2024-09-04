using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("coupon_rooms")]
    public class CouponRoom
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Key]
        [Column(Order = 0)]
        public int CouponId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int RoomId { get; set; }

        // Quan hệ với bảng `Coupons` và `Rooms`
        public Coupon Coupon { get; set; }
        public Room Room { get; set; }

    }
}
