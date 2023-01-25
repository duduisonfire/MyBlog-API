namespace MyBlog_API.context;
using Microsoft.EntityFrameworkCore;
using Models.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Users>? Users { get; set; }
    public DbSet<Posts>? Posts { get; set; }
    public DbSet<Categories>? Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posts>()
            .HasOne(b => b.Users)
            .WithMany(i => i.Posts)
            .HasForeignKey(b => b.OwnerId);

        modelBuilder.Entity<Posts>()
            .HasOne(b => b.Categories)
            .WithMany(i => i.Posts)
            .HasForeignKey(b => b.CategoryId);
    }
}
