using System;

namespace TemperatureConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            double input;
            do
            {
                Console.WriteLine("\nMenu.");
                Console.WriteLine("1. Fahrenheit to Celsius");
                Console.WriteLine("2. Celsius to Fahrenheit");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter temperature (Fahrenheit):  ");
                        input = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("{0} F = {1} C", input, TempFToC(input));
                        break;
                    case 2:
                        Console.Write("Enter temperature (Celsius):  ");
                        input = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("{0} C = {1} F", input, TempCToF(input));
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            } while (choice != 0);
        }

        static double TempCToF(double celsius)
        {
            return (9.0 / 5) * celsius + 32;
        }

        static double TempFToC(double fahrenheit)
        {
            return (5.0 / 9) * (fahrenheit - 32);
        }
    }
}
