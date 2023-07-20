using System;
using System.Diagnostics;
using System.Threading;

namespace StopWatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StopWatch sort = new StopWatch();
            Console.Write("Enter size of array: ");
            int size_array = Convert.ToInt32(Console.ReadLine());
            sort.Start();
            int[] numbers = Array.RandomArray(size_array);
            sort.Stop();
            Console.WriteLine("Generate 100,000 elements (s): " + sort.Elapsed);
            //Array.PrintArray(numbers);
            sort.Start();
            Array.SelectionSort(numbers);
            sort.Stop();
            //Array.PrintArray(numbers);
            Console.WriteLine("Selection sort (s): " + sort.Elapsed);
            

            Console.ReadKey();
        }
    }

    public class StopWatch
    {
        // Data field
        private DateTime startTime, endTime;
        private Stopwatch watch;

        // Property
        public DateTime StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        public DateTime EndTIme
        {
            get => endTime;
            set => endTime = value;
        }

        public void Start()
        {
            startTime = DateTime.Now;
            
        }

        public void Stop()
        {
            endTime = DateTime.Now;
           
        }

        public void Reset()
        {
          
            startTime = DateTime.MinValue;
            endTime = DateTime.MinValue;
        }

        public TimeSpan Elapsed => (endTime - startTime);
    }

    public class Array
    {
        public static int[] RandomArray(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(0, 100000);
            }
            return array;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine();
        }

        public static void SelectionSort(int[] array)
        {
            int inner, outter, min;
            for (outter = 0; outter < array.Length - 1; outter++)
            {
                min = outter;
                for (inner = outter + 1; inner < array.Length; inner++)
                {
                    if (array[inner] < array[min]) min = inner;
                }
                Swap(array, outter, min);
            }
        } 

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }


    }

}
