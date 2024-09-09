using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonDataLayer.Entities
{
    [Table("blog")]
    public class Blog : BaseModel
    {
        [Key]
        [Column("BlogId")]
        public int BlogId { get; set; }

        [Required]
        [Column("image")]
        public string image { get; set; } // Lưu trữ mảng JSON dưới dạng chuỗi

        [Column("blog_title")]
        public string blog_title { get; set; }

        [Column("blog_author")]
        public string blog_author { get; set; }

        [Column("blog_time")]
        public DateTime? blog_time { get; set; }

        [Column("blog_description")]
        public string blog_description { get; set; }


        [ForeignKey("UserId")]
        [Column("UserId")]
        public int UserId { get; set; } // Trường khóa ngoại liên kết với bảng users

        //// Navigation property
        //public virtual User User { get; set; } // Chỉ định quan hệ với bảng users
    }
}
