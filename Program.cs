using System;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        //Fill database only if empty
        LibCollection.populateCollection();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Library Manager ===");
            Console.WriteLine("1. View all resources");
            Console.WriteLine("2. Add new resource");
            Console.WriteLine("3. Edit resource");
            Console.WriteLine("4. Delete resource");
            Console.WriteLine("5. Borrow resource");
            Console.WriteLine("6. Return resource");
            Console.WriteLine("7. Search resources");
            Console.WriteLine("8. Reports");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ResourceOperations.ListResources();
                    break;
                case "2":
                    ResourceOperations.AddResource();
                    break;
                case "3":
                    ResourceOperations.UpdateResource();
                    break;
                case "4":
                    ResourceOperations.DeleteResource();
                    break;
                case "5":
                    ResourceOperations.BorrowResource();
                    break;
                case "6":
                    ResourceOperations.ReturnResource();
                    break;
                case "7":
                    SearchMenu();
                    break;
                case "8":
                    ReportMenu();
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
            Console.WriteLine("Goodbye!");

        }
    }

    // Displays a submenu for search options
    static void SearchMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Search Menu ===");
            Console.WriteLine("1. Search by title");
            Console.WriteLine("2. Search by author");
            Console.WriteLine("3. Search by genre");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SearchManager.SearchByTitle();
                    break;
                case "2":
                    SearchManager.SearchByAuthor();
                    break;
                case "3":
                    SearchManager.SearchByGenre();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    // Displays a submenu for report options
    static void ReportMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Reports Menu ===");
            Console.WriteLine("1. Resources by category");
            Console.WriteLine("2. Overdue items");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ReportManager.GenerateResourceCategoryReport();
                    break;
                case "2":
                    ReportManager.GenerateOverdueReport();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }

}