using System;


namespace StudentFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students = { "Christian", "Michael", "Camila", "Sienna", "Tanya", "Connor", "Zachariah", "Mallory", "Zoe", "Emily" };

            Console.WriteLine("Enter a name’s student:");
            string name = Console.ReadLine();

            Console.WriteLine(BinarySearch(students, name));
            Console.ReadKey();

        }

        private static bool BinarySearch(string[] students, string name)
        {
            BubbleSort(students);
            int low = 0;
            int high = students.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                string midName = students[mid];

                if (string.Compare(midName, name) == 0) return true;
                else if (string.Compare(midName, name) > 0) high = mid - 1;
                else low = mid + 1;
            }
            return false;

        }

        public static void BubbleSort(string[] students)
        {

            for (int outer = students.Length - 1; outer >= 0; outer--)
            {
                for (int inner = 0; inner < students.Length - 1; inner++)
                {
                    if (string.Compare(students[inner], students[inner + 1]) > 0)
                    {
                        string temp = students[inner];
                        students[inner] = students[inner + 1];
                        students[inner + 1] = temp;
                    }
                }

            }
        }
    }
}