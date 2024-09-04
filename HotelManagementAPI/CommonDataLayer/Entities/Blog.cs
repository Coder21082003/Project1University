using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("blog")]
    public class Blog
    {
        [Key]
        [Column("blog_id")]
        public int BlogId { get; set; }

        [Required]
        [Column("image")]
        public string Image { get; set; }

        [Column("blog_title")]
        public string BlogTitle { get; set; }

        [Column("blog_author")]
        public string BlogAuthor { get; set; }

        [Column("blog_time")]
        public DateTime? BlogTime { get; set; }

        [Column("blog_description")]
        public string BlogDescription { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
