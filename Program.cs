using System;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n==== Library Management ====");
            Console.WriteLine("1. Add Resource");
            Console.WriteLine("2. List All Resources");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Choose an option: ");

            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    ResourceOperations.AddResource();
                    break;
                case "2":
                    ResourceOperations.ListResources();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
        Console.WriteLine("Goodbye!");
    }
}