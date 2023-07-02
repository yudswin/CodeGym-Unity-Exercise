using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
        UserInput:
            Console.WriteLine("Menu\r\n" +
                "1. Draw the triangle\r\n" +
                "2. Draw the square\r\n" +
                "3. Draw the rectangle\r\n" +
                "M. Exit\r\n");
            Console.Write("Enter your choice:");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Console.WriteLine("Draw the triangle");
                    Console.WriteLine("******");
                    Console.WriteLine("*****");
                    Console.WriteLine("****");
                    Console.WriteLine("***");
                    Console.WriteLine("**");
                    Console.WriteLine("*");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    Console.WriteLine("Draw the square");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine();
                    Console.WriteLine("Draw the rectangle");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    Console.WriteLine("* * * * * *");
                    break;
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("No choice!");
                    break;
            }

            Console.Write("\nPress 'C' to continue the process...");
            if (Console.ReadKey().Key == ConsoleKey.C) goto UserInput;
        }
    }
}
