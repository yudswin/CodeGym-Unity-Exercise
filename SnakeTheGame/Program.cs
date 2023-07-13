using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//sources : https://youtu.be/_GmjXi1kcHA
// https://www.codeproject.com/Articles/4426/Console-Enhancements


/* [Y]
 * ^
 * |
 * |
 * |_ _ _ _> [X]
*/ 
 
namespace SnakeTheGame
{
    internal class Snake
    {
        
        
        //Board
        int Height = 25;
        int Width = 50;

        //Snake
        bool isAlive = true;
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
            Console.SetCursorPosition(Width + 5, 0);
            Console.Write("X: {0} | Y: {1}", X[0], Y[0]);
        }

        public void GetWindowLocation()
        {
            
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
            if (X[0] < 1 || X[0] > Width - 1 || Y[0] < 1 || Y[0] > Height - 1)
            {
                isAlive = false;
                Console.SetCursorPosition(x, y);
                Console.Write("0");
                DrawLose();
            } else
            {
                Console.SetCursorPosition(x, y);
                Console.Write("0");
            }
        }

        private void DrawFruit(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("1");
        }

        private void DrawLose() // Update Snake location
        {
            Console.SetCursorPosition(Width + 5, 1);
            Console.Write("GAME OVER");
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

            if (isAlive)
            {
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
            }
            
            Thread.Sleep(50);
        }

        // [CONTROLLER]
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey key = ConsoleKey.W;
        bool horizontal, vertical;

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
            }

            //Snake moving
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (horizontal && !vertical)
                    {
                        Y[0]--;
                        horizontal = false;
                        vertical = true;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (horizontal && !vertical)
                    {
                        Y[0]++;
                        horizontal = false;
                        vertical = true;
                    }
                        
                    break;
                case ConsoleKey.RightArrow:
                    if (!horizontal && vertical)
                    {
                        X[0]++;
                        horizontal= true;
                        vertical= false;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (!horizontal && vertical)
                    {
                        X[0]--;
                        horizontal = true;
                        vertical = false;
                    }
                    break;
            }
        }


        // [GAME RENDERING]
        public void Play()
        {
            isAlive = true;
            Console.CursorVisible = false;
            while (isAlive)
            {
                Console.Clear();
                DrawBorder();
                Input();
                Logic();
            }
        }

        public void ScreenSetting(int width, int height)
        {
            Console.InputEncoding = Encoding.UTF8; //Input font
            Console.OutputEncoding = Encoding.UTF8; //Output font 

            Console.SetWindowSize(width, height); // Set size window
            Console.SetBufferSize(this.Width, this.Height); // Set number of row and collumn 
        }


        //MAIN
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start the game !!!");
            ConsoleKeyInfo key = Console.ReadKey(true);
            
        replay:
            Snake game = new Snake();
            game.Play();

            Console.SetCursorPosition(game.Width + 5, 20);
            Console.WriteLine("Press any key to restart the game !!!");
            if (Console.ReadKey().Key != ConsoleKey.Escape) goto replay;
        }
    }
}
