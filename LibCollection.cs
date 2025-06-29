using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Models;


public static class LibCollection
{
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
            new Resource { Title = "Pride and Prejudice", Author = "Jane Austen", ResourceType = "Book", PublicationYear = 1813, Genre = "Romance", IsAvailable = true },
            new Resource { Title = "A Brief History of Time", Author = "Stephen Hawking", ResourceType = "Book", PublicationYear = 1988, Genre = "Science", IsAvailable = true },
            new Resource { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ResourceType = "Book", PublicationYear = 1925, Genre = "Classic", IsAvailable = true },
            new Resource { Title = "Brave New World", Author = "Aldous Huxley", ResourceType = "Book", PublicationYear = 1932, Genre = "Dystopian", IsAvailable = true },
            new Resource { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", ResourceType = "Book", PublicationYear = 1997, Genre = "Fantasy", IsAvailable = true },
            new Resource { Title = "The Da Vinci Code", Author = "Dan Brown", ResourceType = "Book", PublicationYear = 2003, Genre = "Thriller", IsAvailable = true },
            new Resource { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ResourceType = "Book", PublicationYear = 1951, Genre = "Classic", IsAvailable = true },
            new Resource { Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", ResourceType = "Book", PublicationYear = 2011, Genre = "History", IsAvailable = true },
            new Resource { Title = "The Road", Author = "Cormac McCarthy", ResourceType = "Book", PublicationYear = 2006, Genre = "Post-Apocalyptic", IsAvailable = true },
            new Resource { Title = "The Alchemist", Author = "Paulo Coelho", ResourceType = "Book", PublicationYear = 1988, Genre = "Philosophical", IsAvailable = true },
            new Resource { Title = "Frankenstein", Author = "Mary Shelley", ResourceType = "Book", PublicationYear = 1818, Genre = "Horror", IsAvailable = true },
            new Resource { Title = "The Martian", Author = "Andy Weir", ResourceType = "Book", PublicationYear = 2011, Genre = "Science Fiction", IsAvailable = true },

            //Magazines
            new Resource { Title = "National Geographic - May 2024", Author = "National Geographic Society", PublicationYear = 2024, Genre = "Science", ResourceType = "Magazine", IsAvailable = true },
            new Resource { Title = "TIME - Person of the Year", Author = "TIME", PublicationYear = 2023, Genre = "News", ResourceType = "Magazine", IsAvailable = true },
            new Resource { Title = "The Economist - World in 2024", Author = "The Economist", PublicationYear = 2024, Genre = "Finance", ResourceType = "Magazine", IsAvailable = true },
            new Resource { Title = "Wired - Tech for Tomorrow", Author = "Wired", PublicationYear = 2023, Genre = "Technology", ResourceType = "Magazine", IsAvailable = true },
            new Resource { Title = "Scientific American - AI Special", Author = "Scientific American", PublicationYear = 2023, Genre = "Science", ResourceType = "Magazine", IsAvailable = true },

                //Journals 
            new Resource { Title = "Nature - Genetics Issue", Author = "Nature Publishing Group", PublicationYear = 2022, Genre = "Biology", ResourceType = "Journal", IsAvailable = true },
            new Resource { Title = "Journal of Machine Learning", Author = "JMLR", PublicationYear = 2021, Genre = "Computer Science", ResourceType = "Journal", IsAvailable = true },
            new Resource { Title = "The Lancet - Global Health", Author = "Elsevier", PublicationYear = 2023, Genre = "Medicine", ResourceType = "Journal", IsAvailable = true },
            new Resource { Title = "ACM Transactions on Graphics", Author = "ACM", PublicationYear = 2022, Genre = "Graphics", ResourceType = "Journal", IsAvailable = true },                new Resource { Title = "IEEE Transactions on Neural Networks", Author = "IEEE", PublicationYear = 2022, Genre = "AI", ResourceType = "Journal", IsAvailable = true }
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
}

