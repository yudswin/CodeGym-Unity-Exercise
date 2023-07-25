using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Rectangle rec = new Rectangle(5.0, 3.0, "ocean blue", true);
                Square shape = new Square(4.0, "black", false);
                Circle cir = new Circle(3.4, "pink", true);
                Random rnd = new Random();

                Console.WriteLine("Before resize");
                Console.WriteLine(rec.ToString());
                Console.WriteLine();
                Console.WriteLine(shape.ToString());
                Console.WriteLine();
                Console.WriteLine(cir.ToString());

                //Resize
                rec.Resize(rnd.Next(1, 100));
                shape.Resize(rnd.Next(1, 100));
                cir.Resize(rnd.Next(1, 100));

                Console.WriteLine("______________");
                Console.WriteLine("After resize");
                Console.WriteLine(rec.ToString());
                Console.WriteLine();
                Console.WriteLine(shape.ToString());
                Console.WriteLine();
                Console.WriteLine(cir.ToString());

                Console.WriteLine("press Enter to stop");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter) break;
                Console.Clear();
            }

            Console.ReadKey();
        }
    }
}
