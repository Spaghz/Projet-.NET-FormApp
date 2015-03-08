using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Utils
{
    public class Point
    {
        /***********************************
         *  Members
         ***********************************/
        private double _x, _y;

        /***********************************
         *  Constructor(s)
         ***********************************/
        public Point(double x,double y)
        {
            _x = x;
            _y = y;
        }

        /***********************************
         *  Properties
         ***********************************/

        public double X
        {
            get { return _x; }
            //set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            //set { _y = value; }
        }

        /***********************************
         *  Methods
         ***********************************/

        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        /***********************************
         *  Operators overload
         ***********************************/

        public static Point operator + (Point p,Vector v)
        {
            if ((p == null) || (v == null))
                throw new ArgumentNullException();

            return new Point(p.X + v.X, p.Y + v.Y);
        }

        public static bool operator == (Point P1,Point P2)
        {
            if (System.Object.ReferenceEquals(P1, P2))
                return true;

            return ((P1.X == P2.X) && (P1.Y == P2.Y));
        }

        public static bool operator != (Point P1,Point P2)
        {
            return (!(P1 == P2));
        }

        public override bool Equals(object obj)
        {
            if ((Point)obj == null)
                return false;

            return this == (Point)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
