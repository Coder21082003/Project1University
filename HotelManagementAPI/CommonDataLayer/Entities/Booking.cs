using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("bookings")]
    public class Booking : BaseModel
    {
        [Key]
        [Column("BookingId")]
        public int BookingId { get; set; }

        [Required]
        [Column("UserId")]
        public long UserId { get; set; }

        [Required]
        [Column("RoomId")]
        public int RoomId { get; set; }

        [Required]
        [Column("check_in_date")]
        public DateTime check_in_date { get; set; }

        [Required]
        [Column("check_out_date")]
        public DateTime check_out_date { get; set; }

        [Required]
        [Column("booking_date")]
        public DateTime booking_date { get; set; }

        [Column("status")]
        public byte? status { get; set; }

        [Column("total_price", TypeName = "decimal(18, 2)")]
        public decimal? total_price { get; set; }

        [Column("discount_amount", TypeName = "decimal(18, 2)")]
        public decimal? discount_amount { get; set; }

        //// Quan hệ với bảng `Users` và `Rooms`
        //[ForeignKey("UserId")]
        //public User User { get; set; }

        //[ForeignKey("RoomId")]
        //public Room Room { get; set; }

        //// Quan hệ với bảng `Payments`
        //public ICollection<Payment> Payments { get; set; }

        //// Quan hệ với bảng `ServiceBooking`
        //public ICollection<ServiceBooking> ServiceBookings { get; set; }
    }
}
