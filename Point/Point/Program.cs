using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point2D point = new Point2D();
            Console.WriteLine(point.ToString());
            Console.WriteLine("___________");
            Point2D point1 = new Point2D(3.0f, 0.4f);
            Console.WriteLine(point1.ToString());
            Console.WriteLine("___________");

            Point3D point2 = new Point3D();
            Console.WriteLine(point2.ToString());
            Console.WriteLine("___________");
            Point3D point3 = new Point3D(5.0f);
            Console.WriteLine(point3.ToString());
            Console.WriteLine("___________");
            Point3D point4 = new Point3D(2.0f, 3.0f, 0.4f);
            Console.WriteLine(point4.ToString());
            Console.WriteLine("___________");
            Console.ReadKey();
        }
    }
}
