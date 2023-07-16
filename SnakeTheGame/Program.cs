using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * https://youtu.be/_GmjXi1kcHA
 * https://www.codeproject.com/Articles/4426/Console-Enhancements
 * https://github.com/khietltn/basicCsharp/tree/main/CGO_Buoi06_SnakeGame
 * 
*/

/* [Y] Height
 * ^
 * |
 * |
 * |_ _ _ _> [X] Width 
*/

namespace SnakeTheGame
{
    public class Snake
    {
        
        int Height = 25;
        int Width = 50;
        int PanelHeight = 3;

        bool isAlive, horizontal, vertical;
        bool isPause = false;
        int parts, score, hiScore, timeCounter;     // Snake size 
        Stopwatch watch = new Stopwatch();
        int[] X,Y;
        int fruitX, fruitY;                         // Fruit coordinates
        Random rnd = new Random();
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        ConsoleKey key = ConsoleKey.UpArrow;


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
            ScreenSetting(Width + 1, Height + PanelHeight - 1);

            Console.ForegroundColor = ConsoleColor.Red;     // Color format
            for (int i = 0; i <= Height; i += Height)       // Draw Vertical Border
            {
                for (int j = 0; j <= Width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write("═");
                }
            }

            for (int i = 0; i <= Width; i += Width)          // Draw Horizontal Border
            {
                for (int j = 0; j <= Height; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("║");
                }
            }

            // Draw Corner
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            Console.SetCursorPosition(0, Height);
            Console.Write("╚");
            Console.SetCursorPosition(Width, 0);
            Console.Write("╗");
            Console.SetCursorPosition(Width, Height);
            Console.Write("╝");
            Console.ResetColor();                            // End color format

            Panel(Width, Height);

            // Draw Fruit
            if (isAlive)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(fruitX, fruitY);
                Console.Write("$");
                Console.ResetColor();
            }
        }

        private void Panel(int w, int h)
        {
            int panelWidth = w;
            int panelHeight = h;

            Console.ForegroundColor = ConsoleColor.Yellow;
            string hiScoreStr = "Hi-Score: ";
            Console.SetCursorPosition(1, panelHeight + 1);
            Console.Write(hiScoreStr + hiScore);

            string scoreStr = "Score: ";
            int leftPadding = (panelWidth - scoreStr.Length) / 2;
            Console.SetCursorPosition(leftPadding, panelHeight + 1);
            Console.Write(scoreStr + score);
            
            string timeStr = "Time: ";
            leftPadding = panelWidth - (timeStr.Length + 4);
            Console.SetCursorPosition(leftPadding, panelHeight + 1);
            Console.Write(timeStr + timeCounter);
            Console.ResetColor();
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

        private void DrawSnake(int i)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X[0], Y[0]);
            Console.Write("@");
            if (X[i] != 0 && Y[i] != 0)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(X[i], Y[i]);
                Console.Write(" ");
            }
            Console.ResetColor();
        }

        private void GameOver()
        {
            //
            string[] lines = new string[3];
            lines[0] = "╔═══════════╗";
            lines[1] = "║ GAME OVER ║";
            lines[2] = "╚═══════════╝";

            // Calculate the center position
            int leftPadding = Width / 2 - lines[0].Length / 2;
            int topPadding = Height / 2 - 1;
            for (int i = 0; i < lines.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(leftPadding, topPadding);
                Console.WriteLine(lines[i]);
                topPadding++;
            }

            string replay = "press [R] to restart the game";
            leftPadding = Width / 2 - replay.Length / 2;
            Console.SetCursorPosition(leftPadding, topPadding + 1);
            Console.WriteLine(replay);
            Console.ResetColor();
            
        }

        private void Pause()
        {
            Console.Clear();

            string[] lines = new string[3];
            lines[0] = "╔════════════╗";
            lines[1] = "║ GAME PAUSE ║";
            lines[2] = "╚════════════╝";

            // Calculate the center position
            int leftPadding = Width / 2 - lines[0].Length / 2;
            int topPadding = Height / 2 - 1;
            for (int i = 0; i < lines.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(leftPadding, topPadding);
                Console.WriteLine(lines[i]);
                topPadding++;
            }

            string resumeMessage = "press [P] to resume";
            leftPadding = (Width - resumeMessage.Length) / 2;
            topPadding += 1;
            Console.SetCursorPosition(leftPadding, topPadding);
            Console.WriteLine(resumeMessage);

            ConsoleKeyInfo newKey = Console.ReadKey(true); // Wait for any key press to resume
            if (newKey.Key == ConsoleKey.P)
                isPause = false; // Resume the game by setting isPause to false
        }


        private void UpdateHighScore()
        {
            if (score >= hiScore)
            {
                hiScore = score;
            }
        }

        private void Time()
        {
            
            watch.Start();
                if (watch.ElapsedMilliseconds >= 1000)
                {
                    timeCounter++;
                    watch.Restart();
                }
        }

        private void Logic()
        {

            //Get point
            if (X[0] == fruitX && Y[0] == fruitY)
            {
                parts++;
                score++;
                RandomFruit();
                UpdateHighScore();
            }

            //Snake growth 
            if (X[0] > 0 && X[0] < Width && Y[0] > 0 && Y[0] < Height)
            {
                for (int i = parts; i > 1; i--)
                {
                    X[i - 1] = X[i - 2];
                    Y[i - 1] = Y[i - 2];
                }

                for (int i = 0; i < parts; i++) DrawSnake(i);
            }
            else
            {
                isAlive = false;
                Console.ForegroundColor = ConsoleColor.Green;   // console color format
                for (int i = 1; i < parts; i++) DrawSnake(i);
                Console.ResetColor();                           // end color format
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

            //Game speed
            if (isAlive)
            {
                int delay = Math.Max(200 - (parts * 10), 50);
                Thread.Sleep(delay);
            }

        }

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
                    case ConsoleKey.P:
                        isPause = !isPause;
                        break;

                }
            }
        }

        private void Update()
        {
            switch (key)        // Snake moving
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

        public void Play()
        {
            Console.Clear();
            isAlive = true;
            score = 0; parts = 10; timeCounter = 0;

            X = new int[25 * 50];
            Y = new int[25 * 50];
            X[0] = Width / 2;                   // Snake start location
            Y[0] = Height / 2;

            key = ConsoleKey.UpArrow;
            horizontal = true;
            vertical = false;


            RandomFruit();                      // Fruit start location

            while (isAlive)
            {
                Console.Clear();
                Time();
                Render();
                Input();

                if (!isPause)
                {
                    Update();
                    Logic();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void ScreenSetting(int width, int height)
        {
            Console.CursorVisible = false;
            Console.InputEncoding = Encoding.UTF8;          // Set input font
            Console.OutputEncoding = Encoding.UTF8;         // Set output font 
            Console.SetWindowSize(width, height);           // Set size window
            Console.BufferWidth = Console.WindowWidth;      // Set number of row and collumn 
            Console.BufferHeight = Console.WindowHeight;
        }


        //[MAIN]
        static void Main(string[] args)
        {

            Console.WriteLine("Press any key to start the game !!!");
            Console.ReadKey(true);
            Snake game = new Snake();
            bool replay = true;

            while (replay)
            {
                game.Play();

                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.R) break;
                    if (key.Key == ConsoleKey.Escape) replay = false;

                } while (key.Key != ConsoleKey.R && key.Key != ConsoleKey.Escape);
            }
        }
    }
}