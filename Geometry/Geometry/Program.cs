using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ComparableCircle - IComparable Tests:
            ComparableCircle[] circles = new ComparableCircle[3];
            circles[0] = new ComparableCircle(3.0);
            circles[1] = new ComparableCircle();
            circles[2] = new ComparableCircle(0.4, "ocean blue", false);

            Console.WriteLine("Pre-sorted:");
            foreach (ComparableCircle circle in circles)
            {
                Console.WriteLine(circle);
            }

            Array.Sort(circles);

            Console.WriteLine("After-sorted:");
            foreach (ComparableCircle circle in circles)
            {
                Console.WriteLine(circle);
            }

            // CircleComparer - IComparer Test:
            Circle[] cir = new Circle[3];
            cir[0] = new Circle(3.6);
            cir[1] = new Circle();
            cir[2] = new Circle(3.5, "indigo", false);

            Console.WriteLine("Pre-sorted:");
            foreach (Circle circle in cir)
            {
                Console.WriteLine(circle);
            }

            IComparer<Circle> circleComparator = new CircleComparator();
            Array.Sort(cir, circleComparator);

            Console.WriteLine("After-sorted:");
            foreach (Circle circle in cir)
            {
                Console.WriteLine(circle);
            }


            Console.ReadKey();
        }
    }
}
