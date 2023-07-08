using System;
using System.Collections.Generic;

namespace ArrayDeletion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using Array
            Console.Write("Enter size of array: ");
            int size_array = Convert.ToInt32(Console.ReadLine());
            int[] numbers = RandomArray(size_array);
            PrintArray(numbers);

            Console.WriteLine("Enter number to delete: ");
            int del = Convert.ToInt32(Console.ReadLine());
            Deletion(numbers, del);
            PrintArray(numbers);


            //using List

            Console.Write("Enter size of list: ");
            int size_list = Convert.ToInt32(Console.ReadLine());
            List<int> list = RandomList(size_list);
            PrintList(list);
            Console.WriteLine("Enter number to delete: ");
            del = Convert.ToInt32(Console.ReadLine());
            Deletion(list, del);
            PrintList(list);

            Console.ReadKey();
        }

        //Array methods
        static int[] RandomArray(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(0, 100000);
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

        static void Deletion(int[] array, int key)
        {

            Array.Sort(array);
            int low = 0;
            int high = array.Length - 1;
            bool flag = false;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int midValue = array[mid];

                if (midValue == key)
                {
                    array[mid] = 0;
                    flag = true;
                }
                else if (midValue > key) high = mid - 1;
                else low = mid + 1;
            }

            if (flag) Console.WriteLine("value deleted!!");
            else throw new InvalidOperationException("No value found");

        }

        //List methods
        static void PrintList(List<int> list)
        {
            foreach (int num in list)
            {
                Console.Write(num + " | ");
            }
            Console.WriteLine();
        }

        static List<int> RandomList(int size)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(0, 100000));
            }
            return list;
        }

        static void Deletion(List<int> list, int key)
        {
            if (list.Remove(key)) Console.WriteLine("value deleted!!");
            else throw new InvalidOperationException("No value found");
        }
    }
}
