using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    public class Circle
    {
        private double radius = 1.0f;
        private string color = "yellow";

        public double Radius { get => radius; set => radius = value; }
        public string Color { get => color; set => color = value; }

        public Circle() { }

        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return String.Format("A Circle with radius = {0} and color {1}", radius, color);
        }
    }
}
