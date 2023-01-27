using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyBlogAPI.Models;

[Table("Posts")]
public class Posts
{
    [Key]
    public int? Id { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("Title")]
    public string? Title { get; set; }

    [Required]
    [Column("Content")]
    public string? Content { get; set; }

    [Required]
    [Column("OwnerId")]
    public int? OwnerId { get; set; }

    public Users? Users { get; set; }

    [Required]
    [Column("Category")]
    public int? CategoryId { get; set; }

    public Categories? Categories { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}