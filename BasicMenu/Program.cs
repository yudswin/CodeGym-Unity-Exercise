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

            DrawSquare(5);
            Console.WriteLine();
            DrawRectangle(7, 9);
            Console.WriteLine();
            DrawTriangle(4, 5);

        UserInput:
            Console.WriteLine("Menu\r\n" +
                "1. Draw the triangle\r\n" +
                "2. Draw the square\r\n" +
                "3. Draw the rectangle\r\n" +
                "0. Exit\r\n");
            Console.Write("Enter your choice:");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Console.WriteLine("Enter Draw the triangle");
                    
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

        static void DrawTriangle(int heigth, int length)
        {
            for (int i = 0;i < heigth; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

        }

        static void DrawRectangle(int length, int width)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        static void DrawSquare(int side)
        {
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
