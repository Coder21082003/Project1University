using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("coupon")]
    public class Coupon : BaseModel
    {
        [Key]
        [Column("CouponId")]
        public int CouponId { get; set; }

        [Required]
        [Column("coupon_name")]
        [MaxLength(191)]
        public string coupon_name { get; set; }

        [Required]
        [Column("coupon_code")]
        [MaxLength(191)]
        public string coupon_code { get; set; }

        [Required]
        [Column("coupon_money")]
        [MaxLength(191)]
        public string coupon_money { get; set; }

        [Required]
        [Column("coupon_qty")]
        [MaxLength(191)]
        public string coupon_qty { get; set; }

        [Required]
        [Column("status")]
        public int status { get; set; } = 0;

        //// Quan hệ với bảng `CouponRooms`
        //public ICollection<CouponRoom> CouponRooms { get; set; }
    }
}
