using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Rectangle : Shape, Resizeable
    {
        // Data field
        private double width = 1.0f;
        private double length  = 1.0f;

        // Properties
        public virtual double Width { get => width; set => width = value; }
        public virtual double Length { get => length; set => length = value; }

        // Constructors
        public Rectangle() { }

        public Rectangle(double width, double length)
        {
            this.width = width;
            this.length = length;
        }

        public Rectangle(double width, double length, string color, bool filled) : base(color, filled)
        {
            this.width = width;
            this.length = length;
        }

        

        public virtual double GetArea()
        {
            return width * length;
        }

        public virtual double GetPerimeter()
        {
            return 2 * (width + length);
        }

        public override string ToString()
        {
            return String.Format("A Rectangle with width = {0}, height = {1}, which is subclass of {2}", width, length, base.ToString());
        }

        public virtual void Resize(double percent)
        {
            width *= percent / 100;
            length *= percent / 100;
        }
    }
}
