using Microsoft.EntityFrameworkCore;
using LibraryManager.Models;

public class LibraryContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }

    // Default constructor used by the app normally
    public LibraryContext() { }

    // Constructor used by unit tests to pass in custom options
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    // Only run this if no options are passed (e.g., from the app)
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
