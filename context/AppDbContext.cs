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
            .HasOne(post => post.Owner)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.OwnerId);

        modelBuilder.Entity<Posts>()
            .HasOne(post => post.Categories)
            .WithMany(categories => categories.Posts)
            .HasForeignKey(post => post.CategoryId);

        modelBuilder.Entity<Users>()
            .HasIndex(u => u.User)
            .IsUnique();

        modelBuilder.Entity<Users>()
            .HasIndex(u => u.UserEmail)
            .IsUnique();
    }
}
