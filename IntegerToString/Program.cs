using System;
using System.Globalization;
using System.Linq;

namespace IntegerToString
{
    internal class Program
    {

        static void Main(string[] args)
        {

        /**
        use case 1: 000  error input
        use case 2: 1a2  error input
        use case 3: 132  3 digit != 0
        use case 4: 201  2nd digit = 0
        use case 5: 203  3rd digit = 0
        use case 6: 021  1st digit = 0
        **/

            Console.WriteLine();
            Console.Write("Enter 3 digit integer: ");
            int abc = Convert.ToInt16(Console.ReadLine());

            //Get digit
            int a, b, c;
            a = abc / 100; // first digit
            b = abc / 10 % 10; // second digit  
            c = abc % 10; // last digit

            //String array to store words
            string[] lastdigit = { " ", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] seconddigit = { " ", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string firstdigit = "hundred";


            //debug: check digit
            Console.WriteLine(a + "\t" + b + "\t" + c);

            if (abc < 1000 || abc > 99 )
            {
               
            } else if (abc <= 99 || abc > 9)
            {
                Console.WriteLine("Error input!!");
            }




            
            //switch (value % 10)
            //{
            //    case 0: result = " " + result; break;
            //    case 1: result = " one" + result; break;
            //    case 2: result = " two" + result; break;
            //    case 3: result = " three" + result; break;
            //    case 4: result = " four" + result; break;
            //    case 5: result = " five" + result; break;
            //    case 6: result = " six" + result; break;
            //    case 7: result = " seven" + result; break;
            //    case 8: result = " eight" + result; break;
            //    case 9: result = " nine" + result; break;
            //}
            
            //switch (value / 10 % 10)
            //{
            //    case 0: result = " " + result; break;
            //    case 1: result = " one" + result; break;
            //    case 2: result = " two" + result; break;
            //    case 3: result = " three" + result; break;
            //    case 4: result = " four" + result; break;
            //    case 5: result = " five" + result; break;
            //    case 6: result = " six" + result; break;
            //    case 7: result = " seven" + result; break;
            //    case 8: result = " eight" + result; break;
            //    case 9: result = " nine" + result; break;
            //}


            //Console.WriteLine(value % 10);
            //Console.WriteLine(value /10 % 10);
            //Console.WriteLine(value /100 % 10);

            Console.ReadKey();

        }
    }
}

