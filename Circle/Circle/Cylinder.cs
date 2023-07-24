using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    public class Cylinder : Circle
    {
        private double height = 1.0f;

        public double Height { get => height; set => height = value; }

        public Cylinder() { }  

        public Cylinder(double height)
        {
            this.height = height;
        }

        public Cylinder(double height, double radius, string color) : base(radius, color)
        {
            this.height = height;
        }

        public override string ToString()
        {
            return String.Format("A Cylinder with height = {0} and a subclass of {1}", height, base.ToString());
        }

        public double GetVolumn()
        {
            return GetArea() * height;
        }
    }
}
