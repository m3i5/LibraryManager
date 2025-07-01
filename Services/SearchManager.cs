using System;
using System.Linq;
using LibraryManager.Models;

public static class SearchManager
{
    //searches for resource by title (partial match, case insensitive)
    public static void SearchByTitle()
    {
        Console.WriteLine("Enter title: ");
        string keyword = Console.ReadLine()?.Trim().ToLower() ?? "";

        using (var context = new LibraryContext())
        {
            //match title with partial match
            var results = context.Resources
                .Where(r => r.Title.ToLower().Contains(keyword))
                .ToList();

            DisplayResults(results, "title", keyword);
        }
    }

    //search resource by author name
    public static void SearchByAuthor()
    {
        Console.Write("Enter author keyword: ");
        string keyword = Console.ReadLine()?.Trim().ToLower() ?? "";

        using (var context = new LibraryContext())
        {
            var results = context.Resources
                .Where(r => r.Author.ToLower().Contains(keyword))
                .ToList();

            DisplayResults(results, "author", keyword);
        }
    }

    //search resource by genre
    public static void SearchByGenre()
    {
        Console.Write("Enter genre keyword: ");
        string keyword = Console.ReadLine()?.Trim().ToLower() ?? "";

        using (var context = new LibraryContext())
        {
            var results = context.Resources
                .Where(r => r.Genre.ToLower().Contains(keyword))
                .ToList();

            DisplayResults(results, "genre", keyword);
        }
    }


    //display search results
    public static void DisplayResults(System.Collections.Generic.List<Resource> results, string field, string keyword)
    {
        Console.WriteLine($"\nSearch results for {field}: \"{keyword}\"");

        if (!results.Any())
        {
            Console.WriteLine("No matching resources found.");
        }
        else
        {
            foreach (var res in results)
            {
                Console.WriteLine($"- {res.Title} by {res.Author} ({res.PublicationYear}) - Genre: {res.Genre}, Type: {res.ResourceType}, Available: {(res.IsAvailable ? "Yes" : "No")}");
            }
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine(); // Pause to allow the user to read the results
    }
}