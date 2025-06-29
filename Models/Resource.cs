namespace LibraryManager.Models;

public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public int PublicationYear { get; set; }
    public string Genre { get; set; } = "";
    public string ResourceType { get; set; } //Book, Magazine, Journal
    public bool IsAvailable { get; set; } = true;
    public string? BorrowedBy { get; set; }
    public DateTime? DueDate { get; set; }
}
