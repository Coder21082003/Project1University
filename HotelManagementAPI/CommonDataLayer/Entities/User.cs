using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Column("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("level")]
        public byte Level { get; set; } = 0;

        [Column("status")]
        public byte Status { get; set; } = 0;

        [Column("remember_token")]
        public string RememberToken { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Column("image")]
        public string Image { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("contact")]
        public string Contact { get; set; }

        // Quan hệ với bảng `Bookings`, `Contacts` và `Reviews`
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
