using System;
using Cafémenu;

namespace Cafémenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Café and Gym!");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Calculate VAT");
                Console.WriteLine("2. Calculate Gym Membership Price");
                Console.WriteLine("3. Use Calculator");
                Console.WriteLine("4. Menu Options");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateVATOption();
                        break;
                    case "2":
                        CalculateGymMembershipCostOption();
                        break;
                    case "3":
                        CalculatorOption();
                        break;
                    case "4":
                        MenuOptionsOption();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CalculateVATOption()
        {
            Console.WriteLine("\n--- Calculate VAT ---");
            Console.Write("Enter product type (music, food, alcohol): ");
            string productType = Console.ReadLine();
            Console.Write("Enter price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                try
                {
                    decimal vat = ServiceMethods.CalculateVAT(productType, price);
                    Console.WriteLine($"The VAT for {productType} at price {price} is: {vat}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid price entered.");
            }
        }

        static void CalculateGymMembershipCostOption()
        {
            Console.WriteLine("\n--- Calculate Gym Membership Cost ---");
            Console.Write("Enter age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Console.Write("Do you want premium membership? (yes/no): ");
                bool isPremium = Console.ReadLine()?.ToLower() == "yes";

                int cost = ServiceMethods.CalculateGymMembershipCost(age, isPremium);
                Console.WriteLine($"The total gym membership cost is: {cost}");
            }
            else
            {
                Console.WriteLine("Invalid age entered.");
            }
        }

        static void CalculatorOption()
        {
            Console.WriteLine("\n--- Calculator ---");
            Console.Write("Enter operation (+, -, *, /): ");
            string operation = Console.ReadLine();
            Console.Write("Enter first number: ");
            if (double.TryParse(Console.ReadLine(), out double value1))
            {
                Console.Write("Enter second number: ");
                if (double.TryParse(Console.ReadLine(), out double value2))
                {
                    try
                    {
                        double result = ServiceMethods.Calculator(operation, value1, value2);
                        Console.WriteLine($"The result of {operation} is: {result}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid second number entered.");
                }
            }
            else
            {
                Console.WriteLine("Invalid first number entered.");
            }
        }

        static void MenuOptionsOption()
        {
            Console.WriteLine("\n--- Menu Options ---");
            Console.Write("Enter menu option (help, add, delete, edit, find, list): ");
            string option = Console.ReadLine();
            ServiceMethods.MenuOptions(option);
        }
    }
}

