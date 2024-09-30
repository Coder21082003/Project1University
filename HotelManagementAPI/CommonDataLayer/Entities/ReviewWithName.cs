using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    public class ReviewWithName : BaseModel
    {
        [Key]
        [Column("ReviewId")]
        public long ReviewId { get; set; }

        [Required]
        [Column("UserName")]
        public string UserName { get; set; }

        [Required]
        [Column("RoomName")]
        public string RoomName { get; set; }

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
