using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("coupon")]
    public class Coupon
    {
        [Key]
        [Column("coupon_id")]
        public int CouponId { get; set; }

        [Required]
        [Column("coupon_name")]
        [MaxLength(191)]
        public string CouponName { get; set; }

        [Required]
        [Column("coupon_code")]
        [MaxLength(191)]
        public string CouponCode { get; set; }

        [Required]
        [Column("coupon_money")]
        [MaxLength(191)]
        public string CouponMoney { get; set; }

        [Required]
        [Column("coupon_qty")]
        [MaxLength(191)]
        public string CouponQty { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; } = 0;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Quan hệ với bảng `CouponRooms`
        public ICollection<CouponRoom> CouponRooms { get; set; }
    }
}

