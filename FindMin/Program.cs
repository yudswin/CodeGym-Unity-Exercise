using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] numbers = RandomArray(size);
            PrintArray(numbers);
            Console.WriteLine("Minimum of array is: " + FindMin(numbers));
            Console.ReadKey();

        }

        static int FindMin(int[] array) 
        {
            int min = array[0];
            foreach (int i in array)
            {
                if (i > min) min = i;
            }
            return min;
        }

        static int[] RandomArray(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(0,100000);
            }
            return array;
        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine();
        }
    }
}
