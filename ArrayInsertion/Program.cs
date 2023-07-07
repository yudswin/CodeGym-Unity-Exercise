using System;
using System.Collections.Generic;

namespace ArrayInsertion
{
    internal class Program
    {
        /* 
         * Get input size* from User (size = n)
         * Create new list with given size*
         * Insert(element, index) m insert element* at index* (index = k)
         * InsertTop(), insertLast(), insertAtIndex()
         * 
         * Time Complexity: O(n)  to shift element from k to n-1
         * Space Complexity: O(1)
        */

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.Write("Enter size of array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            numbers.Add(0);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);

            //CreatList(numbers, size);
            PrintList(numbers);
            

            Console.Write("Insert new value :");
            int value = Convert.ToInt32(Console.ReadLine());
            Console.Write("At index??: ");
            int index = Convert.ToInt32(Console.ReadLine());
            
            AddWithIndex(numbers, value, index);
            PrintList(numbers);

            Console.ReadKey();
        }

        static void CreatList(List<int> list, int size)
        {
            for (int i = 0; i < size; i++)
            {
                list.Add(0);
            }
        }

        static void AddWithIndex(List<int> list, int value, int index)
        {
            if (list[index] == 0)
            {
                list[index] = value; 
            } else
            {
                list.Add(0);
                for (int i = list.Count;i > index;i--)
                {
                    list[i - 1] = list[i];
                }
                list[index] = value;
            }

        }

        static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
        }
    }
}

