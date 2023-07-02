using System;
using System.Globalization;
using System.Linq;
using System.Diagnostics;

namespace IntegerToString
{
    internal class Program
    {
        static string ConvertToWords(int num)
        {
            //String array to store words
            string[] single = { " ", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] multiple = { " ", " ", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] two = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string pow = "hundred";

            //Get digits
            int a, b, c;
            a = num / 100; // first digit
            b = num / 10 % 10; // second digit  
            c = num % 10; // last digit

            //Debug: check digit
            //Console.WriteLine(a + "\t" + b + "\t" + c);

            //Convert
            if (num < 1000 && num > 99)
            {
                if (b == 1)
                {
                    return single[a] + " " + pow + " and " + two[c];
                }
                else if (b > 1)
                {
                    return single[a] + " " + pow + " and " + multiple[b] + " " + single[c];
                }
                else if (c != 0)
                {
                    return single[a] + " " + pow + " and " + single[c];
                } else
                {
                    return single[a] + " " + pow;
                }
            }
            else
            {
                return "Error input!!";
            }

        }

        static void Main(string[] args)
        {

            /**
            test case 1: Number with zeros: 102, 305, 700
            test case 2: Number ending with zero: 120, 450, 900
            test case 3: Number with repeated digit (2, 3 digits): 777, 322, 113
            test case 2: Number with tens and units: 357, 425, 836
            test case 4: Number with teens: 113, 512, 219
            **/

            Console.WriteLine(ConvertToWords(111)); //error 
            Console.WriteLine(ConvertToWords(132));
            Console.WriteLine(ConvertToWords(201));
            Console.WriteLine(ConvertToWords(230));
            Console.WriteLine(ConvertToWords(021)); //error
            
            Console.WriteLine("------------------");

        UserInput:
            Console.Write("\nEnter 3 digit integer: "); // User input
            int input = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(ConvertToWords(input));

            //Loop user input
            Console.Write("\nPress 'M' to continue...");
            if (Console.ReadKey().Key == ConsoleKey.M) goto UserInput;


        }
    }
}

