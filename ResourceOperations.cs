using System;
using LibraryManager.Models;

public static class ResourceOperations
{
    public static void AddResource()
    {
        Console.WriteLine("\n-- Add New Resource --");

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Publication Year: ");
        int publicationYear = int.Parse(Console.ReadLine());

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        var resource = new Resource
        {
            Title = title,
            Author = author,
            PublicationYear = publicationYear,
            Genre = genre,
            IsAvailable = true // default to available
        };

        using (var context = new LibraryContext())
        {
            context.Resources.Add(resource);
            context.SaveChanges();
        }

        Console.WriteLine("Resource added successfully!");
    }

    public static void ListResources()
    {
        Console.WriteLine("\n-- List of Resources --");

        using (var context = new LibraryContext())
        {
            var resources = context.Resources.ToList();

            if (!resources.Any())
            {
                Console.WriteLine("No resources found.");
                return;
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"ID: {resource.Id}, Title: {resource.Title}, Author: {resource.Author}, Year: {resource.PublicationYear}, Genre: {resource.Genre}, Available: {resource.IsAvailable}");
            }
        }
    }
}
