using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Shape
    {
        // Data field
        private string color = "green";
        private bool filled = true;


        // Properties
        public string Color { get => color; set => color = value; }
        public bool Filled { get => filled; set => filled = value; }


        // Constructors
        public Shape() { }

        public Shape (string color , bool filled)
        {
            this.color = color;
            this.filled = filled;
        }

        // Methods
        public override string ToString()
        {
            return String.Format("A Shape with color of {0} and {1}", color, (filled) ? "filled" : "not filled");
        }
    }
}
