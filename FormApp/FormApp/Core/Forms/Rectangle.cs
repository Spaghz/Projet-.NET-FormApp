using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormApp.Core.Forms;
using FormApp.Core.Utils;

namespace FormApp.Core.Forms
{
    public class Rectangle : Polygon 
    {
        private Point _p1, _p2, _p3, _p4;

        public Rectangle(string nom, Point p1, Point p2,Point p3, Point p4)
            : base(nom)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
            _p4 = p4;

            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
            this.AddPoint(p4);
        }

        public Rectangle(Color color, Point p1, Point p2, Point p3, Point p4)
            : base(color)
        {
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
            this.AddPoint(p4);
        }

        public Point P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }

        public Point P2
        {
            get { return _p2; }
            set { _p2 = value; }
        }

        public Point P3
        {
            get { return _p3; }
            set { _p3 = value; }
        }

        public Point P4
        {
            get { return _p4; }
            set { _p4 = value; }
        }


        public override double Area
        {
            get 
            { 
                Segment a = new Segment("a", P1, P2),
                        b = new Segment("b", P2, P3);
                     
               return (a.Length * b.Length);
            }
        }

        protected override string ToJsonSpecificMore()
        {
            return "\"P1\":{\"X\":" + P1.X.ToString().Replace(',', '.') + ",\"Y\":" + P1.Y.ToString().Replace(',', '.') 
                + "},\"P2\":{\"X\":" + P2.X.ToString().Replace(',', '.') + ",\"Y\":" + P2.Y.ToString().Replace(',', '.') 
                + "},\"P3\":{\"X\":" + P3.X.ToString().Replace(',', '.') + ",\"Y\":" + P3.Y.ToString().Replace(',', '.')
                + "},\"P4\":{\"X\":" + P4.X.ToString().Replace(',', '.') + ",\"Y\":" + P4.Y.ToString().Replace(',', '.') 
                + "}";
        }
    }
}

    