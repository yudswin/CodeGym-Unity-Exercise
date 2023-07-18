using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Rectangle rec1 = new Rectangle(10.5, 20);
            rec1.Display();
            Console.WriteLine("Area = {0} | Perimeter = {1}", rec1.Area(), rec1.Perimeter());

            while (true)
            {
                Console.WriteLine("[Rectangle calculation]");
                Console.Write("input your width: ");
                double w = double.Parse(Console.ReadLine());
                Console.Write("input your height: ");
                double h = double.Parse(Console.ReadLine());
                Rectangle rec = new Rectangle(w, h);

                rec.Display();
                Console.WriteLine("Area = {0} | Perimeter = {1}", rec.Area(), rec.Perimeter());

                Console.WriteLine("Press E to exit");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.E) break;
                Console.Clear();
            }
        }
    }

    public class Rectangle
    {
        //Data field
        private double width, height;

        //Property
        public double Height
        {
            get => height;
            set => height = value;
        }
        public double Width
        {
            get => width;
            set => width = value;
        }

        //Default Constructor
        public Rectangle()
        {

        }
        //Constructor
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        //Area
        public double Area()
        {
            return height * width;
        }

        //Perimeter
        public double Perimeter()
        {
            return (height + width) * 2;
        }

        public void Display()
        {
            Console.WriteLine("The Rectangle | width = {0} | height = {1}",width, height);
        }

    }


}
