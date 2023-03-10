using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyBlogAPI.Models;

[Table("Categories")]
public class Categories
{
    [Key]
    public int? Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("CategoryName")]
    public string? CategoryName { get; set; }

    [Required]
    [Column("CategoryDescription")]
    public string? CategoryDescription { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public List<Posts>? Posts { get; set; }
}