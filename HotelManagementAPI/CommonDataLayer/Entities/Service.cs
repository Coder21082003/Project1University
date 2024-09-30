using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("services")]
    public class Service : BaseModel
    {
        [Key]
        [Column("ServiceId")]
        public long ServiceId { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(255)]
        public string name { get; set; }

        [Column("description", TypeName = "text")]
        public string? description { get; set; }

        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? price { get; set; }

        [Column("status")]
        public byte? status { get; set; }

        [Column("image_url", TypeName = "varchar(max)")]
        public string image_url { get; set; }
        //// Quan hệ với bảng `ServiceBooking`
        //public ICollection<ServiceBooking> ServiceBookings { get; set; }
    }
}
