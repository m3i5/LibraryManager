using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LibraryManager.Models;

public class LibraryContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }

    // This method sets up how to connect to the SQL Server database
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Change 'LibraryDB' to any name you'd like
        options.UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
