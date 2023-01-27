using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBlogAPI.Models;

namespace MyBlog_API.models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Users")]
        public string? User { get; set; }

        [Required]
        [Column("Password")]
        public string? Password { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("UserName")]
        public string? UserName { get; set; }

        [Column("UserPhoto")]
        public string? UserPhoto { get; set; }

        [Column("UserLevel")]
        public int? UserLevel { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public List<Posts>? Posts { get; set; }
    }

    public class ToVerifyUser
    {
        [Required]
        [MaxLength(255)]
        public string? User { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
