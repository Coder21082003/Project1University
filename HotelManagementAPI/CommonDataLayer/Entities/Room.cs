using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("rooms")]
    public class Room : BaseModel
    {
        [Key]
        [Column("RoomId")]
        public int RoomId { get; set; }

        [Required]
        [Column("room_type")]
        [MaxLength(191)]
        public string room_type { get; set; }

        [Required]
        [Column("description", TypeName = "text")]
        public string description { get; set; }

        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? price { get; set; }

        [Required]
        [Column("image_url", TypeName = "varchar(max)")]
        public string image_url { get; set; }

        [Required]
        [Column("status")]
        public byte? status { get; set; }

        [Column("rating")]
        public float? rating { get; set; }

        [Required]
        [Column("bed_type", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string bed_type { get; set; } = "Single bed";

        [Required]
        [Column("size", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string size { get; set; } = "0m2";

        [Required]
        [Column("facilities")]
        public string facilities { get; set; } = "None";

        //// Quan hệ với bảng `Bookings`, `CouponRooms` và `Reviews`
        //public ICollection<Booking> Bookings { get; set; }  // Navigation property
        //public ICollection<CouponRoom> CouponRooms { get; set; }  // Navigation property
        //public ICollection<Review> Reviews { get; set; }  // Navigation property
    }
}
