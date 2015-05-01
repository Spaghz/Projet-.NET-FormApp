using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Utils
{
    public class Vector
    {
        private double _x, _y;

        public Vector(double x,double y)
        {
            _x = x;
            _y = y;
        }

        public Vector(Point P1,Point P2)
        {
            checkParameters(P1, P2);

            _x = P2.X - P1.X;
            _y = P2.Y - P2.Y;
        }

        // Properties
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }


        // Method
        public bool isVectorNull()
        {
            return (_x == 0 && _y == 0);
        }

        // Operators overload
        public static Vector operator *(Vector v, double mult)
        {
            if (v == null)
                throw new ArgumentNullException();

            return new Vector(v.X * mult, v.Y * mult);
        }

        public static Vector operator / (Vector v,double dividend)
        {
            if (v == null)
                throw new ArgumentNullException();

            if (dividend == 0)
                throw new ArgumentException("Vector : division by zero.");

            return new Vector(v.X / dividend, v.Y / dividend);
        }

        private static void checkParameters(Point P1, Point P2)
        {
            checkNullParameters(P1, P2);
        }

        private static void checkNullParameters(Point P1, Point P2)
        {
            if ((P1 == null) || (P2 == null))
                throw new ArgumentNullException();
        }

        public Point translation(Point P)
        {
            return new Point(P.X + this.X, P.Y + this.Y);
        }

    }
}
