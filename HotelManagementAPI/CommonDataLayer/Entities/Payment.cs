using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("booking_id")]
        public int? BookingId { get; set; }

        [Required]
        [Column("payment_method")]
        public string PaymentMethod { get; set; }

        [Column("payment_status")]
        public byte? PaymentStatus { get; set; }

        [Column("amount", TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }

        [Column("payment_date")]
        public DateTime? PaymentDate { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Quan hệ với bảng `Bookings`
        public Booking Booking { get; set; }
    }
}
