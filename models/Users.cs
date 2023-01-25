using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Models;

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

    [Required]
    [Column("UserPhoto")]
    public string? UserPhoto { get; set; }

    [Required]
    [Column("UserLevel")]
    public int? UserLevel { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public List<Posts>? Posts { get; set; }
}