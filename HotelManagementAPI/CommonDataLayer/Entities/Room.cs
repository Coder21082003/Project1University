using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("rooms")]
    public class Room
    {
        [Key]
        [Column("room_id")]
        public int RoomId { get; set; }

        [Required]
        [Column("room_type")]
        public string RoomType { get; set; }

        [Required]
        [Column("description", TypeName = "text")]
        public string Description { get; set; }

        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; }

        [Required]
        [Column("amenities")]
        public string Amenities { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //key
        public ICollection<Booking> Bookings { get; set; }  // Navigation property
        public ICollection<CouponRoom> CouponRooms { get; set; }  // Navigation property
        public ICollection<Review> Reviews { get; set; }  // Navigation property
    }
}
