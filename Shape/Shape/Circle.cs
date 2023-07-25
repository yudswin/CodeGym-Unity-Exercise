using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Circle : Shape, Resizeable
    {
        // Data field
        private double radius = 1.0f;

        // Properties
        public double Radius { get => radius; set => radius = value; }

        // Constructor
        public Circle() { }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public Circle(double radius, string color, bool filled) : base(color, filled)
        {
            this.Radius = radius;
        }

        // Methods

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return Math.PI * 2 * Radius;
        }

        public override string ToString()
        {
            return String.Format("A Circle with radius = {0}, which is subclass of {1}", radius, base.ToString());
        }

        public void Resize(double percent)
        {
            radius *= percent / 100;
        }
    }
}
