using System;
using System.Linq;
using LibraryManager.Models;

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

    public static void AddResource()
    {
        using (var context = new LibraryContext())
        {
            //Ask user for details one by one
            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Author: ");
            var author = Console.ReadLine();

            Console.Write("Publication Year: ");
            int year = int.TryParse(Console.ReadLine(), out var y) ? y : 0;

            Console.Write("Genre: ");
            var genre = Console.ReadLine();

            Console.Write("Resource Type (Book, Magazine, Journal): ");
            var type = Console.ReadLine();

            //Create a new resource object and set properties
            var newResource = new Resource
            {
                Title = title,
                Author = author,
                PublicationYear = year,
                Genre = genre,
                ResourceType = type,
                IsAvailable = true //available by default
            };

            //Add resource to database and save changes
            context.Resources.Add(newResource);
            context.SaveChanges();

            Console.WriteLine("Resource added. Press Enter to continue...");
            Console.ReadLine();
        }
    }

    public static void EditResource()
    {
        using (var context = new LibraryContext())
        {
            //Ask for ID of resource to edit
            Console.Write("Enter ID of resource to edit: ");
            int id = int.TryParse(Console.ReadLine(), out var resId) ? resId : -1;

            //Find resource by id
            var resource = context.Resources.FirstOrDefault(r => r.Id == id);
            if (resource == null)
            {
                Console.WriteLine("Resource not found. Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Leave field blank to keep current value.\n");

            //For each field show current value and allow user to modify it
            Console.Write($"Title ({resource.Title}): ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title)) resource.Title = title;

            Console.Write($"Author ({resource.Author}): ");
            var author = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(author)) resource.Author = author;

            Console.Write($"Year ({resource.PublicationYear}): ");
            var yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out var year)) resource.PublicationYear = year;

            Console.Write($"Genre ({resource.Genre}): ");
            var genre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(genre)) resource.Genre = genre;

            Console.Write($"Type ({resource.ResourceType}): ");
            var type = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(type)) resource.ResourceType = type;

            context.SaveChanges();
            Console.WriteLine("Resource updated. Press Enter to continue...");
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
