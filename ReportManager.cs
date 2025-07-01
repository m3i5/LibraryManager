using System;
using System.Linq;


// This class contains methods to generate reports from the database
public static class ReportManager
{
    // Report 1: List all resources grouped by their type e.g., Book, Journal
    public static void GenerateResourceCategoryReport()
    {
        // Create a new connection to the database
        using (var context = new LibraryContext())
        {
            // Group all resources in the database by their type e.g Book, Magazine
            var groupedResources = context.Resources
                .GroupBy(r => r.ResourceType) // Group by type
                .ToList(); // Execute query and get results

            Console.WriteLine("\n--- Resources by Category ---");

            // Loop through each group (each resource type)
            foreach (var group in groupedResources)
            {
                Console.WriteLine($"\n{group.Key}:"); // Print the type name

                // List all resources in that category
                foreach (var resource in group)
                {
                    Console.WriteLine($"- {resource.Title} by {resource.Author} ({resource.PublicationYear})");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();//Pause, so user can read the list
        }
    }

    // Report 2: List all overdue resources
    public static void GenerateOverdueReport()
    {
        // Open a database connection
        using (var context = new LibraryContext())
        {
            // Get today's date to compare
            var today = DateTime.Today;

            // Find all resources that have passed their return date
            var overdueResources = context.Resources
                .Where(r => r.DueDate != null && r.DueDate < today)
                .ToList();

            Console.WriteLine("\n--- Overdue Resources ---");

            // If no overdue resources found, display message
            if (!overdueResources.Any())
            {
                Console.WriteLine("No overdue resources.");
                return;
            }

            // Display each overdue resource with borrower and due date
            foreach (var resource in overdueResources)
            {
                Console.WriteLine($"- {resource.Title} borrowed by {resource.BorrowedBy}, due on {resource.DueDate?.ToShortDateString()}");
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();//Pause, so user can read the list
        }
    }
}
