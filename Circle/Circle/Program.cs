using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle cir = new Circle();
            Console.WriteLine(cir.ToString());
            Console.WriteLine(cir.GetArea());
            Console.WriteLine("___________");
            Circle cir1 = new Circle(5.0,"green");
            Console.WriteLine(cir1.ToString());
            Console.WriteLine(cir1.GetArea());
            Console.WriteLine("___________");

            Cylinder cy = new Cylinder();
            Console.WriteLine(cy.ToString());
            Console.WriteLine(cy.GetVolumn());
            Console.WriteLine("___________");
            Cylinder cy1 = new Cylinder(1.6f);
            Console.WriteLine(cy1.ToString());
            Console.WriteLine(cy1.GetVolumn());
            Console.WriteLine("___________");
            Cylinder cy2 = new Cylinder(1.0f,6.0f,"yellow");
            Console.WriteLine(cy2.ToString());
            Console.WriteLine(cy2.GetVolumn());
            Console.ReadKey();
        }
    }
}
