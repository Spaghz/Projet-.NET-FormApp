using FormApp.Core.Forms;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Forms
{
    public sealed class Segment : FormSimple
    {
        private Point _p1, _p2;

        public Segment(string name, Point p1,Point p2) : base(name)
        {
            checkParameters(p1, p2);

            _p1 = p1;
            _p2 = p2;
        }

        public Segment(string name, Color backgroundColor,Color edgeColor,Point p1, Point p2)
            : base(name, backgroundColor,edgeColor)
        {
            checkParameters(p1,p2);

            _p1 = p1;
            _p2 = p2;
        }

        // Properties

        public Point P1
        {
            get { return _p1; }
            set 
            {
                checkEquality(_p1, value);
                _p1 = value;
            }
        }

        public Point P2
        {
            get { return _p2; }
            set 
            {
                checkEquality(_p2, value);
                _p2 = value;
            }
        }

        public override double Area
        {
            get  {return 0;}
        }

        public double Length
        {
            get { return Math.Sqrt(Math.Pow(P2.Y - P1.Y, 2) + Math.Pow(P2.X - P1.X, 2)); }
        }

        private static void checkParameters(Point p1, Point p2)
        {
            checkNullParameters(p1, p2);

            checkEquality(p1, p2);
        }

        private static void checkNullParameters(Point p1, Point p2)
        {
            if (((object)p1 == null) || ((object)p2 == null))
                throw new ArgumentNullException();
        }

        private static void checkEquality(Point p1, Point p2)
        {
            if (p1 == p2)
                throw new ArgumentException("Segment creation failed : the two points are equals.");
        }


        protected override string ToJsonSpecificMore()
        {
            return "\"P1\":{\"X\":" + P1.X.ToString().Replace(',', '.') + ",\"Y\":" + P1.Y.ToString().Replace(',', '.')
                 + "},\"P2\":{\"X\":" + P2.X.ToString().Replace(',', '.') + ",\"Y\":" + P2.Y.ToString().Replace(',', '.')
                 + "}";
       }

        public override Form Translation(Vector v)
        {
            throw new NotImplementedException();
        }

        public override Form Rotation(Point p, float angle_radiant)
        {
            throw new NotImplementedException();
        }

        public override int Type
        {
            get { throw new NotImplementedException(); }
        }
    }
}
