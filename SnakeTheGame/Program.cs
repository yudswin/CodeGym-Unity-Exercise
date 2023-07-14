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
        int[] X, Y;

        //Fruit
        int fruitX;
        int fruitY;
        Random rnd = new Random();


        // [CONSTRUCTOR]
        Snake()
        {
            //Snake start location
            X = new int[Height * Width];
            Y = new int[Height * Width];
            X[0] = Width/2;
            Y[0] = Height/2;

            //Fruit start location
            RandomFruit();
        }

        //[DEBUGGING]
        private void SnakeLocation() // Update Snake location
        {
            Console.SetCursorPosition(Width + 5, 0);
            Console.Write("X: {0} | Y: {1}", X[0], Y[0]);

            Console.SetCursorPosition(Width + 5, 1);
            Console.Write("FRUIT [X: {0} | Y: {1}]", fruitX, fruitY);

            Console.SetCursorPosition(Width + 5, 2);
            Console.Write("SIZE {0} x {1}", Width, Height);
        }


        private void Render()
        {
            SnakeLocation();
            
            //Draw Vertical Border
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

            //Draw Horizontal Border
            for (int i = 0;i <= Width; i += Width)
            {
                for (int j = 0; j <= Height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("#");
                }
            }

            //Draw Fruit
            if(isAlive)
            {
                Console.SetCursorPosition(fruitX, fruitY);
                Console.Write("1");
            }

            

        }


        private void RandomFruit()
        {
            fruitX = rnd.Next(1, Width);
            fruitY = rnd.Next(1, Height);

            for (int i = 0; i < parts; i++)
            {
                if (fruitX == X[i] && fruitY == Y[i])
                    RandomFruit();
            }
        }
        //[GAME STATE]
        private void GameOver() // Update Snake location
        {
            Console.SetCursorPosition(Width + 5, 1);
            Console.Write("GAME OVER");
        }

        //[LOGIC AND MANAGER]
        private void Logic()
        {

            //Fruit
            if (X[0] == fruitX && Y[0] == fruitY)
            {
                parts++;
                RandomFruit();
            }

            //Snake
            if (X[0] > 0 && X[0] < Width && Y[0] > 0 && Y[0] < Height)
            {
                
                for (int i = parts; i > 1; i--)
                {
                    X[i - 1] = X[i - 2];
                    Y[i - 1] = Y[i - 2];
                }

                for (int i = 0; i < parts; i++)
                {
                    Console.SetCursorPosition(X[i], Y[i]);
                    Console.Write("0");
                }
                

            } else
            {
                isAlive = false;
                for (int i = 1; i < parts; i++)
                {
                    Console.SetCursorPosition(X[i], Y[i]);
                    Console.Write("0");
                }
                GameOver();
            }

            for (int i = 2; i < parts; i++)
            {
                if (X[0] == X[i] && Y[0] == Y[i])
                {
                    isAlive = false;
                    GameOver();
                    break;
                }
            }

            //Speed
            if (isAlive)
            {
                int delay = Math.Max(200 - (parts * 10), 50);
                Thread.Sleep(delay);
            }

        }

        // [CONTROLLER]
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey key = ConsoleKey.W;
        bool horizontal = false, vertical = true;


        private void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (!horizontal && vertical)
                        {
                            vertical = false;
                            horizontal = true;
                            key = keyInfo.Key;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!horizontal && vertical)
                        {
                            vertical = false;
                            horizontal = true;
                            key = keyInfo.Key;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (horizontal && !vertical)
                        {
                            horizontal = false;
                            vertical = true;
                            key = keyInfo.Key;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (horizontal && !vertical)
                        {
                            horizontal = false;
                            vertical = true;
                            key = keyInfo.Key;
                        }
                        break;
                }
            }
        }

        private void Update()
        {
            
            // Snake moving
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
            isAlive = true;
            Console.CursorVisible = false;

            // Initialize the initial direction of the snake
            horizontal = true;
            vertical = false;
            key = ConsoleKey.UpArrow;
            


            while (isAlive)
            {
                Console.Clear();
                Render();
                Input();
                Update();
                Logic();
            }
        }




        //MAIN
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start the game !!!");
            Console.ReadKey(true);

        replay:
            Snake game = new Snake();
            //game.ScreenSetting(80, 30); // Set the window size
            game.Play();

            Console.SetCursorPosition(game.Width + 5, 20);
            Console.WriteLine("Press any key to restart the game !!!");
            if (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                goto replay;
            }
        }

        public void ScreenSetting(int width, int height)
        {
            Console.InputEncoding = Encoding.UTF8; //Input font
            Console.OutputEncoding = Encoding.UTF8; //Output font 

            Console.SetWindowSize(width, height); // Set size window
            Console.SetBufferSize(this.Width, this.Height); // Set number of row and collumn 
        }
    }
}
