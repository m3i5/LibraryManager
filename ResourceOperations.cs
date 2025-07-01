using System;
using System.Linq;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

public static class ResourceOperations
{
    public static void ListResources()
    {
        using (var context = new LibraryContext()) // Open a connection to the database
        {
            var resources = context.Resources.ToList(); //Get all resources and conver to a list
            Console.WriteLine("\nAvailable Resources:\n");

            foreach (var res in resources) //Loop through each resource and print out details
            {
                Console.WriteLine($"ID: {res.Id}, Title: {res.Title}, Author: {res.Author}, Type: {res.ResourceType}, Available: {(res.IsAvailable ? "Yes" : "No")}");
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();//Pause, so user can read the list
        }
    }

    // Adds a new resource to the library with input validation
    public static void AddResource()
    {

        Console.WriteLine("\n--- Add New Resource ---");

        string title = ValidationManager.ReadNonEmptyInput("Enter title: ");
        string author = ValidationManager.ReadNonEmptyInput("Enter author: ");
        int publicationYear = ValidationManager.ReadValidYear("Enter publication year: ");
        string genre = ValidationManager.ReadNonEmptyInput("Enter genre: ");
        string resourceType = ValidationManager.ReadValidType("Enter resource type (Book, Magazine, Journal): ");

        var newResource = new Resource
        {
            Title = title,
            Author = author,
            PublicationYear = publicationYear,
            Genre = genre,
            ResourceType = resourceType,
            IsAvailable = true
        };

        using (var context = new LibraryContext())
        {
            context.Resources.Add(newResource);
            context.SaveChanges();
        }

        Console.WriteLine("Resource added successfully!");

    }

    public static void UpdateResource()
{
    using (var context = new LibraryContext())
    {
        // Ask user for the ID of the resource to edit
        Console.Write("Enter ID of resource to edit: ");
        bool parsed = int.TryParse(Console.ReadLine(), out int id);
        if (!parsed || id <= 0)
        {
            Console.WriteLine("Invalid ID entered.");
            return;
        }

        // Find resource by ID
        var resource = context.Resources.FirstOrDefault(r => r.Id == id);
        if (resource == null)
        {
            Console.WriteLine("Resource not found. Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("\nLeave field blank to keep current value.\n");

        // Update Title
        Console.Write($"Title ({resource.Title}): ");
        var title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title))
            resource.Title = title;

        // Update Author
        Console.Write($"Author ({resource.Author}): ");
        var author = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(author))
            resource.Author = author;

        // Update Publication Year with validation
        Console.Write($"Year ({resource.PublicationYear}): ");
        var yearInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(yearInput))
        {
            if (int.TryParse(yearInput, out int year) &&
                year >= 1400 && year <= DateTime.Now.Year)
            {
                resource.PublicationYear = year;
            }
            else
            {
                Console.WriteLine("Invalid year. Keeping original.");
            }
        }

        // Update Genre
        Console.Write($"Genre ({resource.Genre}): ");
        var genre = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(genre))
            resource.Genre = genre;

        // Update Resource Type with basic validation
        Console.Write($"Type ({resource.ResourceType}) [Book/Magazine/Journal]: ");
        var type = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(type))
        {
            string[] validTypes = { "Book", "Magazine", "Journal" };
            if (validTypes.Any(t => t.Equals(type, StringComparison.OrdinalIgnoreCase)))
            {
                // Capitalize first letter for consistency
                resource.ResourceType = char.ToUpper(type[0]) + type.Substring(1).ToLower();
            }
            else
            {
                Console.WriteLine("Invalid type. Keeping original.");
            }
        }

        // Save changes to the database
        context.SaveChanges();

        Console.WriteLine("Resource updated successfully. Press Enter to continue...");
        Console.ReadLine();
    }
}


    public static void DeleteResource()
    {
        using (var context = new LibraryContext())
        {
            Console.Write("Enter ID of resource to delete: ");
            int id = int.TryParse(Console.ReadLine(), out var resId) ? resId : -1;

            var resource = context.Resources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                Console.WriteLine("Resource not found. Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            context.Resources.Remove(resource);
            context.SaveChanges();

            Console.WriteLine("Resource deleted. Press Enter to continue...");
            Console.ReadLine();
        }
    }


    public static void BorrowResource()
    {
        using (var context = new LibraryContext())
        {
            //Ask for resource ID to borrow
            Console.Write("Enter ID of resource to borrow: ");
            int id = int.TryParse(Console.ReadLine(), out var resId) ? resId : -1;

            //Find by ID
            var resource = context.Resources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                Console.WriteLine("Resource not found.");
            }
            else if (!resource.IsAvailable) //IF already borrowed notify user
            {
                Console.WriteLine("Resource is already borrowed.");
            }
            else
            {
                Console.Write("Enter name of borrower: ");
                var borrower = Console.ReadLine();

                Console.Write("Enter number of days to borrow (default 14): ");
                int days = int.TryParse(Console.ReadLine(), out var d) ? d : 14;

                resource.IsAvailable = false; //update status
                resource.BorrowedBy = borrower;
                resource.DueDate = DateTime.Now.AddDays(days);

                context.SaveChanges();
                Console.WriteLine($"Resource borrowed until {resource.DueDate.Value.ToShortDateString()}.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }


    public static void ReturnResource()
    {
        using (var context = new LibraryContext())
        {
            Console.Write("Enter ID of resource to return: ");
            int id = int.TryParse(Console.ReadLine(), out var resId) ? resId : -1;

            var resource = context.Resources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                Console.WriteLine("Resource not found.");
            }
            else if (resource.IsAvailable)
            {
                Console.WriteLine("This resource is not currently borrowed.");
            }
            else
            {
                resource.IsAvailable = true;
                resource.BorrowedBy = null;
                resource.DueDate = null;

                context.SaveChanges();
                Console.WriteLine("Resource successfully returned.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }


    public static void SearchResources()
    {
        // To be added after CRUD
    }
}
