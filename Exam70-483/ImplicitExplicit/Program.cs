using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitExplicit
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3d p1 = (Point3d)new Point2d(3d, 5d);
            Point2d p2 = (Point2d)new Point3d(1d, 2d, 3d);
            Point3d p3 = new Point2d(3d, 2d);
            // Point2d p4 = new Point3d(5d, 3d, 1d); // doesnt work because conversion is not implicit
        }
    }

    public struct Point2d
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2d(double x, double y) 
            : this()
        {
            X = x;
            Y = y;
        }
    }

    public struct Point3d
    {
        public static explicit operator Point2d(Point3d value)
        {
            return new Point2d(value.X, value.Y);
        }

        public static implicit operator Point3d(Point2d value)
        {
            return new Point3d(value.X, value.Y, 0d);
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
