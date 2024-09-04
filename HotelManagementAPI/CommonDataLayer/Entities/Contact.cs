using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("contacts")]
    public class Contact
    {
        [Key]
        [Column("contacts_id")]
        public int ContactsId { get; set; }

        [Required]
        [Column("contacts_name")]
        public string ContactsName { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Required]
        [Column("contacts_email")]
        public string ContactsEmail { get; set; }

        [Required]
        [Column("contacts_title")]
        public string ContactsTitle { get; set; }

        [Required]
        [Column("contacts_comment")]
        public string ContactsComment { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Quan hệ với bảng `Users`
        public User User { get; set; }
    }
}
