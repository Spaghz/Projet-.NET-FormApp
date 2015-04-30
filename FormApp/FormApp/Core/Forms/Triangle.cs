using FormApp.Core.Forms;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Forms
{
    public sealed class Triangle : Polygon
    {
        public Triangle(Point p1, Point p2,Point p3)
            : base()
        {
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
        }

        public Triangle(Color color, Point p1, Point p2, Point p3)
            : base(color)
        {
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
        }

        public Point P1
        {
            get { return this.getPoint(1); }
            set { this.getPoint(1) = value; }
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

        public override double Area
        {
            get 
            { 
                /*  Heron's formula :
                 *  A = sqrt(s(s-a)(s-b)(s-c))
                 *  
                 *  s = (1/2)(a+b+c)
                 *  a,b,c : sides of the trinalge
                 */

                Segment a = new Segment(P1, P2),
                        b = new Segment(P2, P3),
                        c = new Segment(P3, P1);

                double s = (a.Length + b.Length + c.Length)/2;

                return Math.Sqrt(s * (s - a.Length) * (s - b.Length) * (s - c.Length));
            }
        }

        protected override string ToJsonSpecificMore()
        {
            return "\"P1\":{\"X\":" + P1.X.ToString().Replace(',', '.') + ",\"Y\":" + P1.Y.ToString().Replace(',', '.') + "},\"P2\":{\"X\":" + P2.X.ToString().Replace(',', '.') + ",\"Y\":" + P2.Y.ToString().Replace(',', '.') + "},\"P3\":{\"X\":" + P3.X.ToString().Replace(',', '.') + ",\"Y\":" + P3.Y.ToString().Replace(',', '.') + "}";
        }
    }
}