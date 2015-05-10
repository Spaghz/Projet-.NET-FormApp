﻿using System;
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
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /***********************************
         *  Methods
         ***********************************/

        public override string ToString()
        {
            return "(" + X + ";" + Y + ")";
        }

        public string ToJson(string pointName)
        {
            if (pointName.Length == 0)
                throw new ArgumentException("Point name musn't be empty when exporting it into jSon : please specify a name for that point.");

            return "\"" + pointName.ToString() + "\":{\"X\":" + X.ToString().Replace(',','.') + ",\"Y\":" + Y.ToString().Replace(',','.') + "}";
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

        public static bool operator == (Point p1,Point p2)
        {
            if (System.Object.ReferenceEquals(p1, p2 ))
                return true;

            if (((object)p1 == null) || ((object)p2 == null))
                return false;

            return ((p1.X == p2.X) && (p1.Y == p2.Y));
        }

        public static bool operator != (Point P1,Point P2)
        {
            return (!(P1 == P2));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return this == (Point)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        /***********************************
       *  Cast point
       ***********************************/
        public static explicit operator System.Drawing.Point(Point point)
        {
            return new System.Drawing.Point((int)point.X, (int)point.Y);
        }
    }
}
