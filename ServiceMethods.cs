using System;

namespace Cafémenu
{
    public static class ServiceMethods
    {
        //calculate VAT for a café business
        public static decimal CalculateVAT(string productType, decimal price)
        {
            decimal vatRate = productType.ToLower() switch
            {
                "music entertainment" => 0.06m,
                "food" => 0.12m,
                "alcohol" => 0.25m,
                _ => throw new ArgumentException("Invalid product type.")
            };

            return price * vatRate;
        }

        // calculate gym membership cost
        public static int CalculateGymMembershipCost(int age, bool isPremium)
        {
            int basePrice = (age < 19 || age > 64) ? 2200 : 3100;
            if (isPremium) basePrice += 300;

            return basePrice;
        }

        // Calculator options
        public static double Calculator(string operation, double value1, double value2)
        {
            return operation.ToLower() switch
            {
                "add" => value1 + value2,
                "subtract" => value1 - value2,
                "multiply" => value1 * value2,
                "divide" => value2 != 0 ? value1 / value2 : throw new DivideByZeroException("Cannot divide by zero."),
                _ => throw new ArgumentException("Invalid operation.")
            };
        }

        // Menu options 
        public static void MenuOptions(string option)
        {
            switch (option.ToLower())
            {
                case "help":
                    Console.WriteLine("Displaying help information...");
                    break;
                case "add":
                    Console.WriteLine("Add operation selected.");
                    break;
                case "delete":
                    Console.WriteLine("Delete operation selected.");
                    break;
                case "edit":
                    Console.WriteLine("Edit operation selected.");
                    break;
                case "find":
                    Console.WriteLine("Find operation selected.");
                    break;
                case "list":
                    Console.WriteLine("Listing all items...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

