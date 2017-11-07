using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitExam2
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection;
            int quantity;
            decimal subtotal = 0.0m;
            const decimal stateTax = 0.03m;
            decimal tax = 0.0m;

            Console.ForegroundColor = ConsoleColor.Green;

            do
            {
                DisplayMenu();

                selection = GetSelection();

                ValidateSelection(ref selection);

                if (selection == 4)
                {
                    break;
                }

                quantity = GetQuantity();

                Console.ForegroundColor = ConsoleColor.Cyan;

                subtotal += CalculateSale(selection, quantity);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Your current subtotal is {subtotal:C}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            } while (true);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            tax = stateTax * subtotal;
            decimal total = tax + subtotal;
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Tax: {tax:C}");
            Console.WriteLine($"Total sale: {total:C}");

        }


        private static void DisplayMenu()
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("\t 1 - Apple - $0.75 per item");
            Console.WriteLine("\t 2 - Banana - $0.49 per pound");
            Console.WriteLine("\t 3 - Orange - $4.75 per dozen");
            Console.WriteLine("\t 4 - Quit");
        }


        private static decimal CalculateSale(int selection, int quantity)
        {
            decimal price = 0.0m;
            decimal subtotal = 0.0m;
            switch (selection)
            {
                case 1:
                    price = 0.75m;
                    subtotal = price * quantity;
                    Console.WriteLine($"{quantity} Apples, @ {price} per apple = {subtotal:C}");
                    break;
                case 2:
                    price = 0.49m;
                    subtotal = price * quantity;
                    Console.WriteLine($"{quantity} pounds of bananas, @ {price} per pound = {subtotal:C}");
                    break;
                case 3:
                    price = 4.75m;
                    subtotal = price * quantity;
                    Console.WriteLine($"{quantity} dozen oranges, @ {price} per dozen = {subtotal:C}");
                    break;
                default:
                    break;
            }


            return subtotal;
        }


        private static int ValidateSelection(ref int selection)
        {
            while (selection < 1 || selection > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{selection} is not a valid selection, enter a value between 1-4: ");
                selection = int.Parse(Console.ReadLine());
            }
            //if (selection < 1 || selection > 4)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.Write($"{selection} is not a valid selection, enter a value between 1-4: ");
            //    selection = int.Parse(Console.ReadLine());
            //}

            Console.ForegroundColor = ConsoleColor.Green;

            return selection;
        }

        private static int GetQuantity()
        {
            Console.Write("Please enter a quantity: ");
            return int.Parse(Console.ReadLine());
        }

        private static int GetSelection()
        {
            Console.Write("Please make a selection: ");
            return int.Parse(Console.ReadLine()); ;
        }

    }
}
