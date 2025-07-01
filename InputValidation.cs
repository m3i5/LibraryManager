using System;


public static class ValidationManager
{

    // Helper method: Ensures non-empty input
    public static string ReadNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    // Helper method: Ensures valid publication year (e.g., 1400–current year)
    public static int ReadValidYear(string prompt)
    {
        int year;
        int currentYear = DateTime.Now.Year;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out year) && year >= 1400 && year <= currentYear)
            {
                return year;
            }

            Console.WriteLine($"Please enter a valid year between 1400 and {currentYear}.");
        }
    }

    // Helper method: Validates resource type (case-insensitive)
    public static string ReadValidType(string prompt)
    {
        string[] validTypes = { "Book", "Magazine", "Journal" };
        string input;

        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input) &&
                Array.Exists(validTypes, type => type.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                return char.ToUpper(input[0]) + input.Substring(1).ToLower(); // Normalize casing
            }

            Console.WriteLine("Invalid type. Please enter Book, Magazine, or Journal.");
        }
    }
}
