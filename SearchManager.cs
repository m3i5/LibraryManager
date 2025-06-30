using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using LibraryManager.Models;

public static class SearchManager
{
    public static void SearchByTitle()
    {
        Console.WriteLine("Enter title: ");
        string keyword = Console.ReadLine()?.Trim().ToLower();

        using (var context = new LibraryContext())
        {
            var results = context.Resources
                .Where(r => r.Title.ToLower().Contains(keyword))
                .ToList();

            DisplayResults(results, "title", keyword);
        }
    }

    public static void SearchByAuthor()
    {
        Console.Write("Enter author keyword: ");
        string keyword = Console.ReadLine()?.Trim().ToLower();

        using (var context = new LibraryContext())
        {
            var results = context.Resources
                .Where(r => r.Author.ToLower().Contains(keyword))
                .ToList();

            DisplayResults(results, "author", keyword);
        }
    }

    public static void SearchByGenre()
    {
        Console.Write("Enter genre keyword: ");
        string keyword = Console.ReadLine()?.Trim().ToLower();

        using (var context = new LibraryContext())
        {
            var results = context.Resources
                .Where(r => r.Genre.ToLower().Contains(keyword))
                .ToList();

            DisplayResults(results, "genre", keyword);
        }
    }


    public static void DisplayResults(System.Collections.Generic.List<Resource> results, string field, string keyword)
    {
        if (!results.Any())
        {
            Console.WriteLine("No matching resources.");
            return;
        }

        foreach (var res in results)
        {
            Console.WriteLine($"- {res.Title} by {res.Author} ({res.PublicationYear}) - Genre: {res.Genre}");
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();//Pause, so user can read the list
    }
}