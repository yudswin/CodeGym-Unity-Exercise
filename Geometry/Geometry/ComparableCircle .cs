using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class ComparableCircle : Circle, IComparable<ComparableCircle>
    {
        public ComparableCircle() { }

        public ComparableCircle(double radius) : base(radius) { }

        public ComparableCircle(double radius, string color, bool filled) : base(radius, color, filled) { }

        public int CompareTo(ComparableCircle other)
        {
            if (getRadius() > other.getRadius()) return 1;
            else if (getRadius() < other.getRadius()) return -1;
            else return 0;
        }
    }
}
