using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class ColorableProgram
    {
        public ColorableProgram()
        {
            Square square = new Square();
            List<Shape> shapes = new List<Shape>();
            Console.Write("Enter number shape: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                shapes.Add(AddRandomShape());
            }

            int counter = 0;
            foreach (Shape shape in shapes)
            {
                if (shape is Square)
                {
                    Console.Write("[shape {0}] : ", counter);
                    ((Square)shape).HowToColor();
                }
                counter++;
            }

            Console.ReadKey();
            
        }

        Shape AddRandomShape()
        {
            Random rnd = new Random();
            switch (rnd.Next(1,4))
            {
                case 1: return new Circle(5.0, "light blue", true);
                case 2: return new Rectangle(3.0, 5.3, "dark blue", false);
                case 3: return new Square(3.4, "black", true);
                default: return new Square(2.1, "ocean blue", false);
            }
        }
    }
}
