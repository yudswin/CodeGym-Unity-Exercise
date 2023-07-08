using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionFindMax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Random Matrix
            int[,] array2D = Create2DArray(5);
            PrintMatrix(array2D);
            Console.WriteLine("Max is {0}", FindMax(array2D));

            //Step 2: User's Matrix
            
            //Get size
            Console.Write("Enter size of matrix: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = Create2DArray(input);

            //Get element
            Console.WriteLine("[Enter element in matrix]");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("[{0}, {1}] = ", row, col );
                    matrix[row,col] = Convert.ToInt32(Console.ReadLine());
                }
            }
            PrintMatrix(matrix);
            Console.WriteLine("Max is {0}", FindMax(matrix));

            Console.ReadKey();
        }

        static int[,] Create2DArray(int size)
        {
            int[,] matrix = new int[size, size]; //Square Matrix
            Random rnd = new Random();
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rnd.Next(1, 255);
                }
            }
            return matrix;

        }

        static int FindMax(int[,] matrix)
        {
            int max = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > max) max = matrix[row, col];
                }
            }
            return max;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
