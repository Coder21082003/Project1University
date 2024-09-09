using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("payments")]
    public class Payment : BaseModel
    {
        [Key]
        [Column("PaymentId")]
        public int PaymentId { get; set; }

        [Required]
        [Column("BookingId")]
        public int BookingId { get; set; }

        [Required]
        [Column("payment_method")]
        [MaxLength(191)]
        public string payment_method { get; set; }

        [Column("payment_status")]
        public byte? payment_status { get; set; }

        [Column("amount", TypeName = "decimal(18, 2)")]
        public decimal? amount { get; set; }

        [Column("payment_date")]
        public DateTime? payment_date { get; set; }

        //// Quan hệ với bảng `Bookings`
        //[ForeignKey("BookingId")]
        //public Booking Booking { get; set; }
    }
}
