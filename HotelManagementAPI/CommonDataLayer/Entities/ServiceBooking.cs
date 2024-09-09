using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("service_booking")]
    public class ServiceBooking 
    {
        [Key]
        [Column("ServiceBookingId")]
        public long ServiceBookingId { get; set; }

        [Required]
        [Column("ServiceId")]
        public long ServiceId { get; set; }

        [Required]
        [Column("BookingId")]
        public int BookingId { get; set; }

        //// Quan hệ với bảng `Services` và `Bookings`
        //[ForeignKey("ServiceId")]
        //public Service Service { get; set; }

        //[ForeignKey("BookingId")]
        //public Booking Booking { get; set; }
    }
}
