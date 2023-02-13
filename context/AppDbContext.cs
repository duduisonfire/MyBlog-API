namespace MyBlogAPI.context;
using Microsoft.EntityFrameworkCore;
using MyBlog_API.models;
using MyBlogAPI.Models;

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

        modelBuilder.Entity<Users>()
            .HasIndex(u => u.User)
            .IsUnique();

        modelBuilder.Entity<Users>()
            .HasIndex(u => u.UserEmail)
            .IsUnique();
    }
}
