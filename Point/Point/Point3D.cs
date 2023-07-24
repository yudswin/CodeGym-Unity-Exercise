using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    public class Point3D : Point2D
    {
        private float z = 0.0f;

        public float Z { get => z; set => z = value; }

        public Point3D() { }

        public Point3D(float z) { this.z = z; }

        public Point3D(float x, float y, float z) : base(x, y) { this.z = z; }

        public void SetXYZ(float newX, float newY, float newZ)
        {
            SetXY(newX, newY);
            Z = newZ;
        }

        public float[] GetXYZ()
        {
            return new float[] { X, Y, z };
        }

        public override string ToString()
        {
            return String.Format("{0} | Z = {1}",base.ToString(),z);
        }
    }
}
