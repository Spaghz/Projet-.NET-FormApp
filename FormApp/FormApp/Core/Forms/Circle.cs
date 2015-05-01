using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Utils;

namespace FormApp.Core.Forms
{
    public sealed class Circle : FormSimple
    {
        /***********************************
         *  Members
         ***********************************/

        private Point   _center;
        private double  _radius;

        /***********************************
         *  Constructor(s)
         ***********************************/

        public Circle(string nom, Point center,double radius) : base(nom)
        {
            checkParameters(center, radius);

            _center = center;
            _radius = radius;
        }


        public Circle(string nom, Color backgroundColor,Color edgeColor,Point center,double radius) : base(nom, backgroundColor,edgeColor)
        {
            checkParameters(center, radius);

            _center = center;
            _radius = radius;
        }

        /***********************************
         *  Properties
         ***********************************/

        public Point Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public double Radius
        {
            get { return _radius; }
            set 
            {
                checkRadius(value);

                _radius = value; 
            }
        }

        public override double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        /***********************************
         *  Operators overload
         ***********************************/

        public static bool operator == (Circle c1,Circle c2)
        {
            if ((c1 == null) || (c2 == null))
                throw new ArgumentNullException();

            return ((c1.Center == c2.Center) && (c1.Radius == c2.Radius));
        }

        public static bool operator != (Circle c1,Circle c2)
        {
            return (!(c1 == c2));
        }

        public override bool Equals(object obj)
        {
            if ((Circle)obj == null)
                return false;

            return ((Circle)obj == this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /***********************************
         *  Private methods
         ***********************************/

        private static void checkParameters(Point center, double radius)
        {
            checkCenter(center);

            checkRadius(radius);
        }

        private static void checkRadius(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius of a circle can not be inferior or equals to 0");
        }

        private static void checkCenter(Point center)
        {
            if (center == null)
                throw new ArgumentNullException();
        }

        protected override string ToJsonSpecificMore()
        {
           return "\"Center\":{\"X\":" + Center.X.ToString().Replace(',', '.') + ",\"Y\":" + Center.Y.ToString().Replace(',', '.')
             + "},\"Radius\":" + Radius.ToString().Replace(',', '.');
        }
    }
}
