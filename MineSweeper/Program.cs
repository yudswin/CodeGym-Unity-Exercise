using System;
using System.Data;

namespace MineSweeper
{
    internal class Program
    {
        /*                  [GAME LOGIC] 
         * 2 Array with 2 Dimension: 1 for the bomb, 1 for the indices
         * cell state IsBomb() => true or false
         * cell location x (row) , y (collumn)
         * NeighborCheck() != IsBomb() => return total
         * 
         * x   0 1 2
         *     _ _ _     y
         *    |B|_|_|    0
         *    |_|2|_|    1
         *    |_|B|_|    2
         * 
         *  total: 2
         *  bomb : 💣
         */

        /*                  [SETUP METHOD]
            GenerateMap()
            GenerateBomb()
            GenerateNeighBor()
            PrintBoard()
        */

        //Variables and constants
        const int fixedRow = 5;                         // x cordinate 
        const int fixedColumn = 5;                      // y cordinate 
        const int fixedBomb = 5;

        string[,] map = new string[fixedRow, fixedColumn];        //Printing array
        int[,] neighbor = new int[fixedRow, fixedColumn];     //Neighbor array 
        bool[,] bomb = new bool[fixedRow, fixedColumn];       //Bomb array

        static void Main(string[] args)
        {
            Program game = new Program();
            game.Setup();
            for (int i = 0; i < game.map.GetLength(0); i ++)
            {
                for (int j = 0; j < game.map.GetLength(1); j ++)
                {
                    Console.Write(game.map[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < game.neighbor.GetLength(0); i++)
            {
                for (int j = 0; j < game.neighbor.GetLength(1); j++)
                {
                    Console.Write(game.neighbor[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < game.bomb.GetLength(0); i++)
            {
                for (int j = 0; j < game.bomb.GetLength(1); j++)
                {
                    Console.Write(game.bomb[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }

        void Setup()
        {
            GenerateMap();
            GenerateBomb();
            GenerateNeighbor();
            DrawMap();
        }

        void GenerateMap()
        {
            for (int x = 0; x < fixedRow; x++)
            {
                for (int y = 0; y < fixedColumn; y++)
                {
                    map[x, y] = " ";
                    neighbor[x, y] = 0;
                    bomb[x, y] = false;
                }
            }
        }

        void GenerateBomb()
        {
            Random rnd = new Random();
            int bombPlaced = 0;
            while (bombPlaced < fixedBomb)
            {
                int x = rnd.Next(fixedRow);
                int y = rnd.Next(fixedColumn);

                if (!bomb[x, y])
                {
                    bomb[x, y] = true;
                    bombPlaced++;
                }
            }
        }


        void GenerateNeighbor()
        {
            for (int x = 0; x < fixedRow; x++)
            {
                for (int y = 0; y < fixedColumn; y++)
                {
                    neighbor[x, y] = NeighborCheck(x, y);
                }
            }
        }

        int NeighborCheck(int x, int y)
        {
            int total = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < fixedRow && j >= 0 && j < fixedColumn && bomb[i, j])
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        
        void DrawMap()
        {
            for (int x = 0;x < fixedRow; x++)
            {
                for (int y = 0; y < fixedColumn; y++)
                {
                    if (bomb[x,y]) map[x, y] = "*";
                    else map[x, y] = neighbor[x,y].ToString();
                }
            }
        }
        
         
    }
}
