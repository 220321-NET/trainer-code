using Microsoft.EntityFrameworkCore;

namespace DL;

// DbContext represents a session (from connect to disconnect to a database)
// DbContext is an implementation of Repository and Unit of Work design pattern
// Repository pattern in DbContext, is primarily achieved through using DbSet 
// which represents the collection of records/entities and by using LINQ (language-integrated query)
// Unit of work design pattern is implemented by using ChangeTracker
// EFCore is lazy loading by default, it will got go grab data until it is asked
// Nor it will go push or update data until it has been asked.
// Once SaveChanges() is called, then it looks through all the changes that exists in the changetracker and persists it to the database. 
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