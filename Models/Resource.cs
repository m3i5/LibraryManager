namespace LibraryManager.Models;

//this class defines structure of library resource
public class Resource
{
    public int Id { get; set; } //primary key for database
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public int PublicationYear { get; set; }
    public string Genre { get; set; } = "";
    public string ResourceType { get; set; } //Book, Magazine, Journal - expected
    public bool IsAvailable { get; set; } = true;
    public string? BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}
