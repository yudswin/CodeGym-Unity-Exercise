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
            Console.WriteLine();
            Console.WriteLine("------------------");
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
                    Console.WriteLine("Chose type draw the triangle\r\n" +
                    "1. top-left\r\n" +
                    "2. top-right\r\n" +
                    "3. botton-left\r\n" +
                    "4. botton-right\r\n" +
                    "0. Exit\r\n");
                    Console.Write("Enter your choice:");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine();
                            Console.WriteLine("Draw the top-left triangle");
                            DrawTriangle(5, 1);
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine();
                            Console.WriteLine("Draw the top-right triangle");
                            DrawTriangle(5, 2);
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine();
                            Console.WriteLine("Draw the bottom-left triangle");
                            DrawTriangle(5, 3);
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine();
                            Console.WriteLine("Draw the bottom-right triangle");
                            DrawTriangle(5, 4);
                            break;
                        case ConsoleKey.D0:
                            Environment.Exit(0);
                            break;
                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    Console.WriteLine("Draw the square");
                    DrawSquare(5);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine();
                    Console.WriteLine("Draw the rectangle");
                    DrawRectangle(3, 5);
                    break;
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nNo choice!");
                    break;
            }

            Console.Write("\nPress 'C' to continue the process...");
            if (Console.ReadKey().Key == ConsoleKey.C) goto UserInput;
        }

        static void DrawTriangle(int side, int type)
        {
            switch (type)
            {
                case 1: //top-left
                    for (int i = 0; i < side; i++)
                    {
                        for (int j = 0; j < side - i; j++)
                        {
                            Console.Write("* ");
                        }

                        Console.WriteLine();
                    }
                    break;
                case 2: //top-right
                    
                    for (int i = 0; i < side; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("  ");
                        }

                        for (int j = 0; j < side - i; j++)
                        {
                            Console.Write("* ");
                        }

                        Console.WriteLine();
                    }
                    break;
                case 3: //bottom-left
                    for (int i = 0; i < side + 1; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 4: //bottom-right
                    for (int i = 0; i < side; i++)
                    {
                        for (int j = 0; j < side - i - 1; j++)
                        {
                            Console.Write("  ");
                        }

                        for (int j = 0; j <= i; j++)
                        {
                            Console.Write("* ");
                        }

                        Console.WriteLine();
                    }
                    break;
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
