using System;
using System.Data;
using System.Runtime.InteropServices;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter row: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter collumn: ");
            int col = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter i: ");
            int i = Convert.ToInt32(Console.ReadLine())

            MineSweeper game = new MineSweeper(row, col)
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("\ni = " + j);
                game.Setup();
                game.DrawMap();
                Console.WriteLine("______________________");
            }
            Console.ReadKey();


        }
    }
    class MineSweeper
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

        // Variables and constants
        private int fixedRow;                         // x cordinate 
        private int fixedColumn;                      // y cordinate 
        private const int fixedBomb = 5;

        private string[,] map;        // Printing array
        private int[,] neighbor;      // Neighbor array 
        private bool[,] bomb;         // Bomb array

        // Constructor
        public MineSweeper(int intputRow, int inputColumn)
        {
            
            this.fixedRow = intputRow;
            this.fixedColumn = inputColumn;

            map = new string[fixedRow, fixedColumn];
            neighbor = new int[fixedRow, fixedColumn];
            bomb = new bool[fixedRow, fixedColumn];
        }



        void BombCalculate()
        {
            
        }

        public void DrawMap() //method to print map to the 
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }

            /*  [Debug: check neighbor[] and bomb[] ]
            Console.WriteLine();
            for (int i = 0 i < game.neighbor.GetLength(0); i++)
            {
                for (int j = 0; j < game.neighbor.GetLength(1); j++)
                {
                    Console.Write(game.neighbor[i, j] + " ")
                }
                Console.WriteLine();
            }
           
            for (int i = 0; i < game.bomb.GetLength(0); i++)
            {
                for (int j = 0; j < game.bomb.GetLength(1); j++)
                {
                    Console.Write(game.bomb[i, j] + " ")
                }
                Console.WriteLine();
            }
            */
        }

        public void Setup()
        {
            GenerateMap();
            GenerateBomb();
            GenerateNeighbor();
            MapInitialize();
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

        
        void MapInitialize()
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
