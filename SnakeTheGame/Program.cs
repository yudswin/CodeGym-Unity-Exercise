using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//sources : https://youtu.be/_GmjXi1kcHA

namespace SnakeTheGame
{
    internal class Snake
    {
        //Board
        int Height = 25;
        int Width = 50;
        
        //Snake
        int parts = 3;
        int[] X = new int[50];
        int[] Y = new int[50];

        //Fruit
        int fruitX;
        int fruitY;
        Random rnd = new Random();


        // [CONSTRUCTOR]
        Snake()
        {
            //Snake start location
            X[0] = 5;
            Y[0] = 5;

            //Fruit start location
            fruitX = rnd.Next(2, (Width - 2));
            fruitY = rnd.Next(2, (Height - 2));
        }

        //[DEBUGGING]
        private void SnakeLocation() // Update Snake location
        {
            Console.SetCursorPosition(Width + 20, 0);
            Console.Write("X: {0} | Y: {1}", X[0], Y[0]);
        }

        //[DRAW METHOD]
        private void DrawBorder()
        {
            SnakeLocation();
            for (int i = 0; i <= Height; i += Height) 
            {
                for (int j = 0;j <= Width; j++)
                {
                    if (j % 2 != 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("#");
                    }
                }
            }

            for (int i = 0;i <= Width; i += Width)
            {
                for (int j = 0; j <= Height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("#");
                }
            }
        }

        private void DrawSnake(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("0");
        }

        private void DrawFruit(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("1");
        }

        //[LOGIC AND MANAGER]
        private void Logic()
        {
            //Fruit hit checking
            if (X[0] == fruitX)
            {
                if (Y[0] == fruitY)
                {
                    parts++; //Snake grown
                    fruitX = rnd.Next(2, (Width - 2));
                    fruitY = rnd.Next(2, (Height - 2));
                }
            }

            for (int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }

 
            //Draw Snake
            for (int i = 0; i <= (parts - 1); i++)
            {
                DrawSnake(X[i], Y[i]);
            }
            DrawFruit(fruitX, fruitY);
            Thread.Sleep(100);
        }

        // [CONTROLLER]
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey key = ConsoleKey.W;

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            }

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Y[0]--;
                    break;
                case ConsoleKey.DownArrow:
                    Y[0]++;
                    break;
                case ConsoleKey.RightArrow:
                    X[0]++;
                    break;
                case ConsoleKey.LeftArrow:
                    X[0]--;
                    break;
            }
        }

        // [GAME RENDERING]
        public void Play()
        {
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                DrawBorder();
                Input();
                Logic();
            }
        }

        static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Play();            
        }
    }
}
