using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Square : Rectangle
    {
        // Constructors
        public Square() { }
 
        public Square(double side) : base(side, side) { }
        
        public Square(double side, string color, bool filled) : base (side, side,color,filled) { }

        // Properties
        public double Side { get => Width; set => SetSide(value); }
       
        // Methods

        public void SetSide(double side)
        {
            Width = side;
            Length = side;
        }

        public sealed override double Length { get => base.Length; set => SetSide(value); }
        public sealed override double Width { get => base.Width; set => SetSide(value); }

        public override string ToString()
        {
            return String.Format("A Square with side = {0}, which is a subclass of {1}", Width, base.ToString());
        }

    }
}
