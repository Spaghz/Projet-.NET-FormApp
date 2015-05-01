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
     
        public Rectangle(string name, Point p1, Point p2,Point p3, Point p4)
            : base(name)
        {
           
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
            this.AddPoint(p4);
        }

        public Rectangle(string name, Color backgroundColor,Color edgeColor, Point p1, Point p2, Point p3, Point p4)
            : base(name, backgroundColor,edgeColor)
        {
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
            this.AddPoint(p4);
        }

        public Point P1
        {
            get { return this.Points[0]; }
            set { this.Points[0] = value; }
        }

        public Point P2
        {
            get { return this.Points[1]; }
            set { this.Points[1] = value; }
        }

        public Point P3
        {
            get { return this.Points[2]; }
            set { this.Points[2] = value; }
        }

        public Point P4
        {
            get { return this.Points[3]; }
            set { this.Points[3] = value; }
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

    