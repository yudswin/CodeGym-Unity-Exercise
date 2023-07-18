using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat beo = new Cat("Beo", 1.5, 50);
            beo.PrintInfo();
            Console.ReadKey();
        }
    }

    public abstract class Animal
    {
        protected double Weight { get; set; }
        protected double Height { get; set; }

        public Animal(double weight, double height)
        {
            Weight = weight;
            Height = height;
        }

        public abstract void PrintInfo();

    }

    public class Cat : Animal
    {
        private string Name { get; set; }
        
        public Cat(string name, double weight, double height) : base(weight,height) 
        {
            Name = name;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("[Cat] Name: {0}| Weight: {1}| Height: {2}",Name,Weight,Height);
        }
        

    }

}
