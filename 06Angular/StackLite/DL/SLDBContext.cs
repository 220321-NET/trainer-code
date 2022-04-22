using Microsoft.EntityFrameworkCore;

namespace DL;

public class SLDBContext : DbContext
{
    public SLDBContext() : base() { }
    public SLDBContext(DbContextOptions options) : base(options) { }

    public DbSet<Issue> Issues { get; set; }

    public DbSet<Answer> Answers { get; set; }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();
        modelBuilder.Entity<Review>()
        .Property(a => a.Id)
        .ValueGeneratedOnAdd();
    }*/
}