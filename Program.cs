using System;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Optional: Seed database only if empty
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
            Console.WriteLine("8. Generate Resources by Category Report");
            Console.WriteLine("9. Generate Overdue Items Report");
            Console.WriteLine("10. Search by title");
            Console.WriteLine("11. Search by author");
            Console.WriteLine("12. Search by genre");
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
                    ResourceOperations.EditResource();
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
                    ResourceOperations.SearchResources();
                    break;
                case "8":
                    ReportManager.GenerateResourceCategoryReport();
                    break;
                case "9":
                    ReportManager.GenerateOverdueReport();
                    break;
                case "10":
                    SearchManager.SearchByTitle();
                    break;
                case "11":
                    SearchManager.SearchByAuthor();
                    break;
                case "12":
                    SearchManager.SearchByGenre();
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
}