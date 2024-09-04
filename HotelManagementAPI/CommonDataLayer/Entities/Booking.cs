using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("bookings")]
    public class Booking
    {
        [Key]
        [Column("booking_id")]
        public int BookingId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("room_id")]
        public int? RoomId { get; set; }

        [Column("check_in_date")]
        public DateTime? CheckInDate { get; set; }

        [Column("check_out_date")]
        public DateTime? CheckOutDate { get; set; }

        [Column("booking_date")]
        public DateTime? BookingDate { get; set; }

        [Column("status")]
        public byte? Status { get; set; }

        [Column("total_price", TypeName = "decimal(18, 2)")]
        public decimal? TotalPrice { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Quan hệ với bảng `Users` và `Rooms`
        public User User { get; set; }
        public Room Room { get; set; }

        // Quan hệ với bảng `Payments`
        public ICollection<Payment> Payments { get; set; }
    }
}
