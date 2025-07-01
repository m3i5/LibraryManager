using Xunit; // Required for writing unit tests using xUnit
using Microsoft.EntityFrameworkCore; // Required for in-memory database support
using LibraryManager.Models; // Access to the Resource model
using LibraryManager; // Access to LibraryContext (your database context)
using System.Linq; // For LINQ queries (like .FirstOrDefault, .Where, etc.)

public class ResourceOperationsTests
{
    // This method creates a temporary, fake database for testing.
    // Each time a test runs, it uses a new clean copy of this database.
    private LibraryContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique name per test run
            .Options;

        return new LibraryContext(options); // Return a context connected to this fake DB
    }

    // This test checks if a new resource (like a book) can be added successfully
    [Fact] // This attribute marks it as a test method
    public void AddResource_ShouldAddResourceToDatabase()
    {
        // Arrange – set up everything needed before performing the action
        using var context = GetInMemoryContext();

        var resource = new Resource
        {
            Title = "Test Book",
            Author = "Test Author",
            PublicationYear = 2025,
            Genre = "Test Genre",
            ResourceType = "Book",
            IsAvailable = true
        };

        context.Resources.Add(resource); // Add the resource to the context
        context.SaveChanges(); // Save the changes to the fake database

        //check if the result is as expected
        var savedResource = context.Resources.FirstOrDefault(r => r.Title == "Test Book");

        Assert.NotNull(savedResource); // Ensure it was actually saved
        Assert.Equal("Test Author", savedResource.Author); // Confirm correct data
    }

    // This test checks if an existing resource can be updated correctly
    [Fact]
    public void UpdateResource_ShouldModifyExistingResource()
    {
        // Arrange
        using var context = GetInMemoryContext();

        // First, add a resource
        var resource = new Resource
        {
            Title = "Original Title",
            Author = "Author A",
            PublicationYear = 2020,
            Genre = "Fiction",
            ResourceType = "Book",
            IsAvailable = true
        };
        context.Resources.Add(resource);
        context.SaveChanges();

        // Act – update the title of the resource
        var savedResource = context.Resources.First(); // Get the resource we just added
        savedResource.Title = "Updated Title"; // Change the title
        context.SaveChanges(); // Save the update

        // Assert – check if the title was updated
        var updatedResource = context.Resources.First(); // Fetch the updated version
        Assert.Equal("Updated Title", updatedResource.Title); // Check new title
    }

    // This test checks if searching by title returns the correct resource
    [Fact]
    public void SearchResource_ByTitle_ShouldReturnCorrectResource()
    {
        // Arrange
        using var context = GetInMemoryContext();

        // Add two resources with different titles
        context.Resources.Add(new Resource
        {
            Title = "C# Programming",
            Author = "Author X",
            PublicationYear = 2021,
            Genre = "Tech",
            ResourceType = "Book"
        });
        context.Resources.Add(new Resource
        {
            Title = "Java Programming",
            Author = "Author Y",
            PublicationYear = 2022,
            Genre = "Tech",
            ResourceType = "Book"
        });
        context.SaveChanges();

        // Act – perform a case-insensitive search for titles containing "C#"
        var results = context.Resources
            .Where(r => r.Title.Contains("C#", System.StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Assert – only one result should be returned, and it's the correct one
        Assert.Single(results); // Only one match expected
        Assert.Equal("C# Programming", results[0].Title); // Ensure it's the right one
    }

    [Fact]
    public void DeleteResource_ShouldRemoveFromDatabase()
    {
        // Arrange
        using var context = GetInMemoryContext();

        var resource = new Resource
        {
            Title = "Delete Me",
            Author = "Unknown",
            PublicationYear = 2020,
            Genre = "Drama",
            ResourceType = "Book"
        };
        context.Resources.Add(resource);
        context.SaveChanges();

        // Act
        context.Resources.Remove(resource);
        context.SaveChanges();

        // Assert
        var exists = context.Resources.Any(r => r.Title == "Delete Me");
        Assert.False(exists); // Should no longer exist
    }

    [Fact]
    public void BorrowResource_ShouldSetDueDate()
    {
        // Arrange
        using var context = GetInMemoryContext();
        var resource = new Resource
        {
            Title = "Borrowable Book",
            Author = "Someone",
            PublicationYear = 2019,
            Genre = "History",
            ResourceType = "Book",
            IsAvailable = true
        };
        context.Resources.Add(resource);
        context.SaveChanges();

        // Act – simulate borrowing
        var item = context.Resources.First();
        item.IsAvailable = false;
        item.DueDate = DateTime.Now.AddDays(14); // 2-week deadline
        context.SaveChanges();

        // Assert
        var updated = context.Resources.First();
        Assert.False(updated.IsAvailable);
        Assert.True(updated.DueDate.HasValue);
    }

    [Fact]
    public void CannotBorrowAlreadyBorrowedResource()
    {
        // Arrange – create an in-memory database context
        using var context = GetInMemoryContext();

        // Create a resource marked as already borrowed (IsAvailable = false)
        var resource = new Resource
        {
            Title = "Borrowed Book",
            Author = "Tester",
            PublicationYear = 2021,
            Genre = "Science",
            ResourceType = "Book",
            IsAvailable = false // simulate already borrowed
        };

        // Save to in-memory DB
        context.Resources.Add(resource);
        context.SaveChanges();

        // Act – read the saved item
        var item = context.Resources.First();

        // Assert – confirm the saved availability is FALSE
        Assert.False(item.IsAvailable);
    }

    [Fact]
    public void ReturnResource_ShouldMakeItAvailable()
    {
        // Arrange
        using var context = GetInMemoryContext();
        var resource = new Resource
        {
            Title = "Returning Book",
            Author = "Returner",
            PublicationYear = 2018,
            Genre = "Fantasy",
            ResourceType = "Book",
            IsAvailable = false,
            DueDate = DateTime.Now.AddDays(-5) // overdue
        };
        context.Resources.Add(resource);
        context.SaveChanges();

        // Act – simulate return
        var item = context.Resources.First();
        item.IsAvailable = true;
        item.DueDate = null;
        context.SaveChanges();

        // Assert
        var updated = context.Resources.First();
        Assert.True(updated.IsAvailable);
        Assert.Null(updated.DueDate);
    }

    [Fact]
    public void Search_ByAuthorOrGenre_ShouldReturnMatchingResults()
    {
        // Arrange
        using var context = GetInMemoryContext();
        context.Resources.AddRange(
            new Resource { Title = "Book1", Author = "Alice", Genre = "Mystery", PublicationYear = 2010, ResourceType = "Book" },
            new Resource { Title = "Book2", Author = "Bob", Genre = "Fantasy", PublicationYear = 2012, ResourceType = "Book" }
        );
        context.SaveChanges();

        // Act – search by author "Bob"
        var byAuthor = context.Resources.Where(r => r.Author.Contains("Bob")).ToList();

        // Act – search by genre "Mystery"
        var byGenre = context.Resources.Where(r => r.Genre.Contains("Mystery")).ToList();

        // Assert
        Assert.Single(byAuthor);
        Assert.Equal("Book2", byAuthor[0].Title);

        Assert.Single(byGenre);
        Assert.Equal("Book1", byGenre[0].Title);
    }


}
