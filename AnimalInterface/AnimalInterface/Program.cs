using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___________");
            Chicken hen = new Chicken();
            Console.WriteLine(hen.MakeSound());
            Console.WriteLine(hen.HowToEat());

            Console.WriteLine("___________");
            Tiger tig = new Tiger();
            Console.WriteLine(tig.MakeSound());

            Console.WriteLine("___________");
            Apple app = new Apple();
            Console.WriteLine(app.HowToEat());

            Console.WriteLine("___________");
            Orange orr = new Orange();
            Console.WriteLine(orr.HowToEat());

            Console.ReadKey();
        }
    }
}
