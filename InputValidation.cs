using System;


//this class provides reusable input validation for the app
public static class ValidationManager
{

    // ensures the user enters non-empty string
    public static string ReadNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt); //show prompt
            input = Console.ReadLine()?.Trim(); //read input and remove extra whitespaces
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrEmpty(input)); //repeat until valid input is provided

        return input;
    }

    // ensures valid publication year between 1400 and current year
    public static int ReadValidYear(string prompt)
    {
        int year;
        int currentYear = DateTime.Now.Year;

        while (true)
        {
            Console.Write(prompt); //ask user for input
            string input = Console.ReadLine();

            //parse and validate the year
            if (int.TryParse(input, out year) && year >= 1400 && year <= currentYear)
            {
                return year; //return valid year
            }

            Console.WriteLine($"Please enter a valid year between 1400 and {currentYear}.");
        }
    }

    // validates resource type - book, magazine, journal
    public static string ReadValidType(string prompt)
    {
        string[] validTypes = { "Book", "Magazine", "Journal" };
        string input;

        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();

            //check if input matches any validType
            if (!string.IsNullOrEmpty(input) &&
                Array.Exists(validTypes, type => type.Equals(input, StringComparison.OrdinalIgnoreCase)))
            {
                //format input to have capital letter first followed by lowercase letters
                return char.ToUpper(input[0]) + input.Substring(1).ToLower(); // Normalize casing
            }

            Console.WriteLine("Invalid type. Please enter Book, Magazine, or Journal.");
        }
    }
}
