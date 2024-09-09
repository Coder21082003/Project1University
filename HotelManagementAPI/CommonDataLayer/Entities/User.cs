using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("users")]
    public class User : BaseModel
    {
        [Key]
        [Column("UserId")]
        public long UserId { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(191)]
        public string name { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(191)]
        public string email { get; set; }

        [Column("email_verified_at")]
        public DateTime? email_verified_at { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(191)]
        public string password { get; set; }

        [Column("level")]
        public byte level { get; set; } = 0;

        [Column("status")]
        public byte status { get; set; } = 0;

        [Column("remember_token")]
        [MaxLength(100)]
        public string? remember_token { get; set; }

        [Column("image")]
        [MaxLength(191)]
        public string? image { get; set; }

        [Column("title")]
        public string? title { get; set; }

        [Column("phone")]
        [MaxLength(191)]
        public string? phone { get; set; }

        [Column("address")]
        [MaxLength(191)]
        public string? address { get; set; }

        [Column("contact")]
        [MaxLength(191)]
        public string? contact { get; set; }

        //// Quan hệ với bảng `Bookings` và `Reviews`
        //public ICollection<Booking> Bookings { get; set; }
        //public ICollection<Review> Reviews { get; set; }
    }
}
