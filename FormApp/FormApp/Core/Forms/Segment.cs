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

        public Segment(Point p1,Point p2) : base()
        {
            checkParameters(p1, p2);

            _p1 = p1;
            _p2 = p2;
        }

        public Segment(Color color,Point p1, Point p2)
            : base(color)
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
            if ((p1 == null) || (p2 == null))
                throw new ArgumentNullException();
        }

        private static void checkEquality(Point p1, Point p2)
        {
            if (p1 == p2)
                throw new ArgumentException();
        }
    }
}
