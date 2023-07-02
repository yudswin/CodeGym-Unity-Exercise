using System;

namespace PrimeCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
        /**
        test case 1: Small Composite Numbers: 4 9 15
        test case 2: Large Prime Numbers: 97 101 131 
        test case 3: Large Composite Numbers: 100 225 999
        test case 2: Negative Numbers: -5 -10 -17
        test case 4: Zero and One
        test case 5: Edge cases: 2 999,999,991 1000000000 (large composite number)
        **/

        UserInput:
            Console.Write("\nEnter integer: "); // User input
            long input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(IsPrime(input));

            //Loop user input
            Console.Write("\nPress 'M' to continue...");
            if (Console.ReadKey().Key == ConsoleKey.M) goto UserInput;
        }

        static bool IsPrime(long num)
        {
            if (num < 2)
            {
                return false;
            }
            else if (num == 2)
            {
                return true;
            }
            else
            {
                long i = 2;
                while (i < Math.Sqrt(num) + 1)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                    i++;
                }
                return true;
            }
        }
    }


}
