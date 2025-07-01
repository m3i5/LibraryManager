using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Models;


public static class LibCollection
{
    //this method seeds the database only if it's currently empty
    public static void populateCollection()
    {
        using (var context = new LibraryContext())
        {

            var items = new[]
            {
            //Books
            new Resource { Title = "The Hobbit", Author = "J.R.R. Tolkien", ResourceType = "Book", PublicationYear = 1937, Genre = "Fantasy", IsAvailable = true },
            new Resource { Title = "1984", Author = "George Orwell", ResourceType = "Book", PublicationYear = 1949, Genre = "Dystopian", IsAvailable = true },
            new Resource { Title = "To Kill a Mockingbird", Author = "Harper Lee", ResourceType = "Book", PublicationYear = 1960, Genre = "Classic", IsAvailable = true },
            new Resource { Title = "Pride and Prejudice", Author = "Jane Austen", ResourceType = "Book", PublicationYear = 1813, Genre = "Romance", IsAvailable = false, BorrowedBy = "John Doe", DueDate = DateTime.Today.AddDays(-7) },
            new Resource { Title = "A Brief History of Time", Author = "Stephen Hawking", ResourceType = "Book", PublicationYear = 1988, Genre = "Science", IsAvailable = true },
            new Resource { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ResourceType = "Book", PublicationYear = 1925, Genre = "Classic", IsAvailable = false, BorrowedBy = "Jack Ryan", DueDate = DateTime.Today.AddDays(-9) },
            new Resource { Title = "Brave New World", Author = "Aldous Huxley", ResourceType = "Book", PublicationYear = 1932, Genre = "Dystopian", IsAvailable = false, BorrowedBy = "Michael Fox", DueDate = DateTime.Today.AddDays(14) },
            new Resource { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", ResourceType = "Book", PublicationYear = 1997, Genre = "Fantasy", IsAvailable = true },
            new Resource { Title = "The Da Vinci Code", Author = "Dan Brown", ResourceType = "Book", PublicationYear = 2003, Genre = "Thriller", IsAvailable = true },
            new Resource { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ResourceType = "Book", PublicationYear = 1951, Genre = "Classic", IsAvailable = true },
            new Resource { Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", ResourceType = "Book", PublicationYear = 2011, Genre = "History", IsAvailable = true },
            new Resource { Title = "The Road", Author = "Cormac McCarthy", ResourceType = "Book", PublicationYear = 2006, Genre = "Post-Apocalyptic", IsAvailable = true },
            new Resource { Title = "The Alchemist", Author = "Paulo Coelho", ResourceType = "Book", PublicationYear = 1988, Genre = "Philosophical", IsAvailable = true },
            new Resource { Title = "Frankenstein", Author = "Mary Shelley", ResourceType = "Book", PublicationYear = 1818, Genre = "Horror", IsAvailable = true },
            new Resource { Title = "The Martian", Author = "Andy Weir", ResourceType = "Book", PublicationYear = 2011, Genre = "Science Fiction", IsAvailable = true },
            new Resource { Title = "The Book Thief", Author = "Markus Zusak", ResourceType = "Book", PublicationYear = 2005, Genre = "Historical Fiction", IsAvailable = false, BorrowedBy = "Ethan Brown", DueDate = DateTime.Today.AddDays(14) },
            new Resource { Title = "Becoming", Author = "Michelle Obama", ResourceType = "Book", PublicationYear = 2018, Genre = "Autobiography", IsAvailable = true },
            new Resource { Title = "Gone Girl", Author = "Gillian Flynn", ResourceType = "Book", PublicationYear = 2012, Genre = "Thriller", IsAvailable = true },
            new Resource { Title = "Educated", Author = "Tara Westover", ResourceType = "Book", PublicationYear = 2018, Genre = "Memoir", IsAvailable = true },
            new Resource { Title = "The Midnight Library", Author = "Matt Haig", ResourceType = "Book", PublicationYear = 2020, Genre = "Fantasy", IsAvailable = false, BorrowedBy = "Michael Fox", DueDate = DateTime.Today.AddDays(1) },
            new Resource { Title = "The Shining", Author = "Stephen King", ResourceType = "Book", PublicationYear = 1977, Genre = "Horror", IsAvailable = true },
            new Resource { Title = "The Fellowship of the Ring", Author = "J.R.R. Tolkien", ResourceType = "Book", PublicationYear = 1954, Genre = "Fantasy", IsAvailable = true },
            new Resource { Title = "Jane Eyre", Author = "Charlotte Brontë", ResourceType = "Book", PublicationYear = 1847, Genre = "Gothic", IsAvailable = false, BorrowedBy = "Alice White", DueDate = DateTime.Today.AddDays(11) },
            new Resource { Title = "Moby-Dick", Author = "Herman Melville", ResourceType = "Book", PublicationYear = 1851, Genre = "Adventure", IsAvailable = true },
            new Resource { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", ResourceType = "Book", PublicationYear = 1866, Genre = "Psychological Fiction", IsAvailable = false, BorrowedBy = "David Stone", DueDate = DateTime.Today.AddDays(10) },
            new Resource { Title = "Little Women", Author = "Louisa May Alcott", ResourceType = "Book", PublicationYear = 1868, Genre = "Classic", IsAvailable = true },
            new Resource { Title = "Dracula", Author = "Bram Stoker", ResourceType = "Book", PublicationYear = 1897, Genre = "Horror", IsAvailable = true },
            new Resource { Title = "The Girl with the Dragon Tattoo", Author = "Stieg Larsson", ResourceType = "Book", PublicationYear = 2005, Genre = "Mystery", IsAvailable = false, BorrowedBy = "Brian Adams", DueDate = DateTime.Today.AddDays(-9) },
            new Resource { Title = "The Hunger Games", Author = "Suzanne Collins", ResourceType = "Book", PublicationYear = 2008, Genre = "Dystopian", IsAvailable = true },
            new Resource { Title = "The Help", Author = "Kathryn Stockett", ResourceType = "Book", PublicationYear = 2009, Genre = "Historical Fiction", IsAvailable = false, BorrowedBy = "Brian Adams", DueDate = DateTime.Today.AddDays(-10) },
            new Resource { Title = "A Game of Thrones", Author = "George R.R. Martin", ResourceType = "Book", PublicationYear = 1996, Genre = "Fantasy", IsAvailable = false, BorrowedBy = "John Doe", DueDate = DateTime.Today.AddDays(3) },
            new Resource { Title = "Life of Pi", Author = "Yann Martel", ResourceType = "Book", PublicationYear = 2001, Genre = "Adventure", IsAvailable = false, BorrowedBy = "Michael Fox", DueDate = DateTime.Today.AddDays(-1) },
            new Resource { Title = "The Kite Runner", Author = "Khaled Hosseini", ResourceType = "Book", PublicationYear = 2003, Genre = "Drama", IsAvailable = true },
            new Resource { Title = "Memoirs of a Geisha", Author = "Arthur Golden", ResourceType = "Book", PublicationYear = 1997, Genre = "Historical Fiction", IsAvailable = true },
            new Resource { Title = "The Color Purple", Author = "Alice Walker", ResourceType = "Book", PublicationYear = 1982, Genre = "Feminist Fiction", IsAvailable = false, BorrowedBy = "Alice White", DueDate = DateTime.Today.AddDays(-5) },
            new Resource { Title = "The Pillars of the Earth", Author = "Ken Follett", ResourceType = "Book", PublicationYear = 1989, Genre = "Historical Fiction", IsAvailable = false, BorrowedBy = "Michael Fox", DueDate = DateTime.Today.AddDays(-10) },
            new Resource { Title = "The Secret History", Author = "Donna Tartt", ResourceType = "Book", PublicationYear = 1992, Genre = "Mystery", IsAvailable = false, BorrowedBy = "Ethan Brown", DueDate = DateTime.Today.AddDays(9) },
            new Resource { Title = "Norwegian Wood", Author = "Haruki Murakami", ResourceType = "Book", PublicationYear = 1987, Genre = "Romance", IsAvailable = false, BorrowedBy = "David Stone", DueDate = DateTime.Today.AddDays(12) },
            new Resource { Title = "Cloud Atlas", Author = "David Mitchell", ResourceType = "Book", PublicationYear = 2004, Genre = "Science Fiction", IsAvailable = true },
            new Resource { Title = "The Name of the Wind", Author = "Patrick Rothfuss", ResourceType = "Book", PublicationYear = 2007, Genre = "Fantasy", IsAvailable = true },


            //Magazines
            new Resource { Title = "National Geographic - Planet Earth Special", Author = "National Geographic Society", ResourceType = "Magazine", PublicationYear = 2024, Genre = "Science", IsAvailable = false, BorrowedBy = "Ethan Green", DueDate = DateTime.Today.AddDays(2) },
            new Resource { Title = "TIME - 100 Most Influential People", Author = "TIME", ResourceType = "Magazine", PublicationYear = 2023, Genre = "News", IsAvailable = false, BorrowedBy = "Jane Smith", DueDate = DateTime.Today.AddDays(-10) },
            new Resource { Title = "The Economist - Global Outlook", Author = "The Economist", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Finance", IsAvailable = false, BorrowedBy = "George Silver", DueDate = DateTime.Today.AddDays(-9) },
            new Resource { Title = "Wired - Future Tech", Author = "Wired", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Technology", IsAvailable = false, BorrowedBy = "Ethan Green", DueDate = DateTime.Today.AddDays(-6) },
            new Resource { Title = "Scientific American - Brain Science", Author = "Scientific American", ResourceType = "Magazine", PublicationYear = 2022, Genre = "Science", IsAvailable = true },
            new Resource { Title = "Forbes - Billionaires Edition", Author = "Forbes", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Business", IsAvailable = true },
            new Resource { Title = "Popular Science - Space Frontier", Author = "Popular Science", ResourceType = "Magazine", PublicationYear = 2022, Genre = "Science", IsAvailable = false, BorrowedBy = "Bob Brown", DueDate = DateTime.Today.AddDays(12) },
            new Resource { Title = "Bloomberg Businessweek - Tech Innovators", Author = "Bloomberg", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Business", IsAvailable = false, BorrowedBy = "John Doe", DueDate = DateTime.Today.AddDays(13) },
            new Resource { Title = "National Geographic - Ocean Wonders", Author = "National Geographic Society", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Nature", IsAvailable = true },
            new Resource { Title = "TIME - Climate Crisis", Author = "TIME", ResourceType = "Magazine", PublicationYear = 2022, Genre = "Environment", IsAvailable = false, BorrowedBy = "Charlie Black", DueDate = DateTime.Today.AddDays(3) },
            new Resource { Title = "The Atlantic - American Democracy", Author = "The Atlantic", ResourceType = "Magazine", PublicationYear = 2022, Genre = "Politics", IsAvailable = true },
            new Resource { Title = "MIT Technology Review - AI Futures", Author = "MIT", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Technology", IsAvailable = false, BorrowedBy = "John Doe", DueDate = DateTime.Today.AddDays(10) },
            new Resource { Title = "New Scientist - The Human Genome", Author = "New Scientist", ResourceType = "Magazine", PublicationYear = 2022, Genre = "Science", IsAvailable = false, BorrowedBy = "Ian Gray", DueDate = DateTime.Today.AddDays(6) },
            new Resource { Title = "Harvard Business Review - Leadership 2024", Author = "Harvard Business Review", ResourceType = "Magazine", PublicationYear = 2024, Genre = "Business", IsAvailable = true },
            new Resource { Title = "Cosmos - The Expanding Universe", Author = "Cosmos Media", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Science", IsAvailable = false, BorrowedBy = "Charlie Black", DueDate = DateTime.Today.AddDays(0) },
            new Resource { Title = "The New Yorker - Art in America", Author = "Condé Nast", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Culture", IsAvailable = false, BorrowedBy = "Bob Brown", DueDate = DateTime.Today.AddDays(-1) },
            new Resource { Title = "Fast Company - Most Creative People", Author = "Fast Company", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Business", IsAvailable = true },
            new Resource { Title = "IEEE Spectrum - Next-Gen Robotics", Author = "IEEE", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Technology", IsAvailable = true },
            new Resource { Title = "Foreign Affairs - Global Conflict", Author = "Council on Foreign Relations", ResourceType = "Magazine", PublicationYear = 2023, Genre = "Politics", IsAvailable = false, BorrowedBy = "Jane Smith", DueDate = DateTime.Today.AddDays(-3) },
            new Resource { Title = "Smithsonian - American History", Author = "Smithsonian Institution", ResourceType = "Magazine", PublicationYear = 2022, Genre = "History", IsAvailable = true },

            //Journals 
            new Resource { Title = "Nature - Climate Change", Author = "Nature Publishing Group", ResourceType = "Journal", PublicationYear = 2023, Genre = "Environmental Science", IsAvailable = true },
            new Resource { Title = "Science - Human Genome Research", Author = "AAAS", ResourceType = "Journal", PublicationYear = 2022, Genre = "Biology", IsAvailable = false, BorrowedBy = "John Doe", DueDate = DateTime.Today.AddDays(-9) },
            new Resource { Title = "The Lancet - Global Health", Author = "Elsevier", ResourceType = "Journal", PublicationYear = 2023, Genre = "Medicine", IsAvailable = false, BorrowedBy = "Alice Johnson", DueDate = DateTime.Today.AddDays(6) },
            new Resource { Title = "IEEE Transactions on Neural Networks", Author = "IEEE", ResourceType = "Journal", PublicationYear = 2022, Genre = "AI", IsAvailable = false, BorrowedBy = "Ian Gray", DueDate = DateTime.Today.AddDays(13) },
            new Resource { Title = "ACM Computing Surveys", Author = "ACM", ResourceType = "Journal", PublicationYear = 2023, Genre = "Computer Science", IsAvailable = false, BorrowedBy = "George Silver", DueDate = DateTime.Today.AddDays(-4) },
            new Resource { Title = "Journal of Economic Perspectives", Author = "American Economic Association", ResourceType = "Journal", PublicationYear = 2023, Genre = "Economics", IsAvailable = true },
            new Resource { Title = "New England Journal of Medicine", Author = "NEJM Group", ResourceType = "Journal", PublicationYear = 2023, Genre = "Medicine", IsAvailable = false, BorrowedBy = "Jane Smith", DueDate = DateTime.Today.AddDays(-10) },
            new Resource { Title = "Cell - Immunology Special", Author = "Cell Press", ResourceType = "Journal", PublicationYear = 2022, Genre = "Biology", IsAvailable = false, BorrowedBy = "Fiona Blue", DueDate = DateTime.Today.AddDays(12) },
            new Resource { Title = "Journal of Political Economy", Author = "University of Chicago Press", ResourceType = "Journal", PublicationYear = 2023, Genre = "Politics", IsAvailable = true },
            new Resource { Title = "Journal of Artificial Intelligence Research", Author = "AI Access Foundation", ResourceType = "Journal", PublicationYear = 2023, Genre = "AI", IsAvailable = true },

            };

            if (!context.Resources.Any())
            {
                context.Resources.AddRange(items);
                context.SaveChanges();
                Console.WriteLine("Database seeded with initial resources.");
            }
            else
            {
                Console.WriteLine("Database already contains data. Seeding skipped.");
            }
        }

    }

    //this method clears the table - use carefully
    public static void ClearDatabase()
    {
        using (var context = new LibraryContext())
        {
            context.Resources.RemoveRange(context.Resources);
            context.SaveChanges();
            Console.WriteLine("Database cleared.");
        }
    }
}

