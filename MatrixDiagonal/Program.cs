using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of matrix: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = SquareMatrix2D(size);
            PrintMatrix(matrix);
            Console.WriteLine("The sum of Principal Diagonal = {0}", PrincipalDiagonal(matrix));
            Console.ReadKey();
            
        }

        static int[,] SquareMatrix2D(int size)
        {
            int[,] matrix = new int[size, size]; //Square Matrix
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rnd.Next(1, 255);
                }
            }
            return matrix;
        }

        static int PrincipalDiagonal(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == i) sum += matrix[i,j];
                }
            }
            return sum;
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
