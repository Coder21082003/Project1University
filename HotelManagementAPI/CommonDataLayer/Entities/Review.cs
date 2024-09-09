using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("reviews")]
    public class Review : BaseModel
    {
        [Key]
        [Column("ReviewId")]
        public long ReviewId { get; set; }

        [Required]
        [Column("UserId")]
        public long UserId { get; set; }

        [Required]
        [Column("RoomId")]
        public int RoomId { get; set; }

        [Required]
        [Column("rating")]
        [Range(1, 5)]
        public int rating { get; set; }

        [Column("comment")]
        [MaxLength(1000)] // Adjusted length for comments
        public string? comment { get; set; }

        //// Quan hệ với bảng `Users` và `Rooms`
        //[ForeignKey("UserId")]
        //public User User { get; set; }

        //[ForeignKey("RoomId")]
        //public Room Room { get; set; }
    }
}
