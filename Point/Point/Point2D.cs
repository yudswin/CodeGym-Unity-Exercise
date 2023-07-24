using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    public class Point2D
    {
        private float x = 0.0f;
        private float y = 0.0f;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Point2D() { }

        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float[] GetXY()
        {
            return new float[] { x, y };
        }

        public void SetXY(float newx, float newy)
        {
            this.x = newx;
            this.y = newy;
        }

        public override string ToString()
        {
            return String.Format("Point: X = {0} | Y = {1}",x,y);
        }
    }
}
