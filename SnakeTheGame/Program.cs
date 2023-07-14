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
        //                   [LOCAL PARAMETERS]
        //Board
        int Height = 25;
        int Width = 50;

        //Snake
        bool isAlive = true;
        int parts = 100;
        int[] X, Y;

        //Fruit
        int fruitX;
        int fruitY;
        Random rnd = new Random();


        //                   [CONSTRUCTOR]
        Snake()
        {
            //Snake start location
            X = new int[Height * Width];
            Y = new int[Height * Width];
            X[0] = Width / 2;
            Y[0] = Height / 2;

            //Fruit start location
            RandomFruit();
        }

        //                   [DEBUGGING]
        private void SnakeLocation() // Update Snake location
        {
            Console.SetCursorPosition(Width + 5, 0);
            Console.Write("X: {0} | Y: {1}", X[0], Y[0]);

            Console.SetCursorPosition(Width + 5, 1);
            Console.Write("FRUIT [X: {0}|Y: {1}]", fruitX, fruitY);

            Console.SetCursorPosition(Width + 5, 2);
            Console.Write("SIZE {0} x {1}", Width, Height);
        }


        private void Render()
        {
            //SnakeLocation(); // Debugging
            //Draw Vertical Border
            //color format
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i <= Height; i += Height)
            {
                for (int j = 0; j <= Width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write("═");
                }
            }
        
    
            //Draw Horizontal Border
            for (int i = 0;i <= Width; i += Width)
            {
                for (int j = 0; j <= Height; j++)
                {
                        Console.SetCursorPosition(i, j);
                        Console.Write("║");
                }
            }

            //Draw Corner
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");

            Console.SetCursorPosition(0, Height);
            Console.Write("╚");

            Console.SetCursorPosition(Width, 0);
            Console.Write("╗");

            Console.SetCursorPosition(Width, Height);
            Console.Write("╝");

            Console.ResetColor(); //end color format

            //Draw Fruit
            if (isAlive)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(fruitX, fruitY);
                Console.Write("$");
                Console.ResetColor();
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
        } //end RandomFruit()

        private void DrawSnake(int i)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X[0], Y[0]);
            Console.Write("@");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(X[i], Y[i]);
            Console.Write(" ");
            Console.ResetColor();
        }

        //                   [GAME STATE]
        private void GameOver()
        {
            string[] lines = new string[3];
            lines[0] = "╔═══════════╗";
            lines[1] = "║ GAME OVER ║";
            lines[2] = "╚═══════════╝";

            // Calculate the center position
            int leftPadding = Width/2 - lines[0].Length/2;
            int topPadding = Height/2 - 1;
            for (int i = 0; i < lines.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(leftPadding,topPadding);
                Console.WriteLine(lines[i]);
                topPadding++;
            }
            string replay = "press any key to restart the game";
            leftPadding = Width / 2 - replay.Length / 2;
            Console.SetCursorPosition(leftPadding, topPadding + 1);
            Console.WriteLine(replay);
            Console.ResetColor();
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
                // console color format
                
                for (int i = parts; i > 1; i--)
                {
                    X[i - 1] = X[i - 2];
                    Y[i - 1] = Y[i - 2];
                }

                for (int i = 0; i < parts; i++)
                {
                    DrawSnake(i);
                }
                Console.ResetColor(); // end color format

            } else
            {
                isAlive = false;
                Console.ForegroundColor = ConsoleColor.Green; // console color format
                for (int i = 1; i < parts; i++)
                {
                    DrawSnake(i);
                }
                Console.ResetColor(); //end color format
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

        } //end Logic()


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
        } //end Input()

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

        } //end Update


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
        } //end Play

        public void ScreenSetting(int width, int height)
        {
            Console.InputEncoding = Encoding.UTF8; //Input font
            Console.OutputEncoding = Encoding.UTF8; //Output font 

            Console.SetWindowSize(width, height); // Set size window
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;// Set number of row and collumn 
        } //end SreenSetting 


        //[MAIN]
        static void Main(string[] args)
        {
            
            Console.WriteLine("Press any key to start the game !!!");
            Console.ReadKey(true);

        replay:
            Snake game = new Snake();
            game.ScreenSetting(51, 26); // Set the window size
            game.Play();

            if (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                goto replay;
            }
        }

        
    }
}
