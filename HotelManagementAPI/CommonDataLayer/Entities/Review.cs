using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        [Column("review_id")]
        public int ReviewId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("room_id")]
        public int? RoomId { get; set; }

        [Column("rating")]
        public int? Rating { get; set; }

        [Column("comment")]
        [MaxLength(255)]
        public string? Comment { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Quan hệ với bảng `Users` và `Rooms`
        public User User { get; set; }
        public Room Room { get; set; }
    }
}
