using System;

namespace FindMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
            do
            {
                Console.WriteLine("Enter a size:");
                size = Int32.Parse(Console.ReadLine());
                if (size > 20)
                    Console.WriteLine("Size should not exceed 20");
            } while (size > 20);

            int[] array = new int[size];
            int[] indices = new int[array.Length]; // store the old index before sorting

            RandomInsert(array, indices);
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            QuickSort(array, indices, 0, array.Length - 1);
            FindMaximum(array, indices);
            Console.ReadLine();
        }

        //Just to recheck.
        private static void FindMaximum(int[] array, int[] indices)
        {
            int max = array[0];
            int index = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] > max)
                {
                    max = array[j];
                    index = j;
                }
            }
            Console.WriteLine("\nThe largest property value in the list is " + max + " ,at position " + indices[index]); 
            //Zero is the 1st position
        }

        //QuickSort => the last elememt is maximum
        static void QuickSort(int[] array, int[] indices, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, indices, low, high);
                QuickSort(array, indices, low, pivotIndex - 1);
                QuickSort(array, indices, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] array, int[] indices, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                    Swap(indices, i, j);
                }
            }

            Swap(array, i + 1, high);
            Swap(indices, i + 1, high);
            return i + 1;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        //Random insert element to array
        static void RandomInsert(int[] array, int[] indices)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 1000);
            }

            for (int i = 0; i < array.Length; i++)
            {
                indices[i] = i;
            }
        }


    }
}
