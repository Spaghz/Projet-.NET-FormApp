using FormApp.Core.Shapes;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes
{
    [DataContract]
    public sealed class Triangle : Polygon
    {
        private static readonly int _type = 1;

        public Triangle(String name)
            :base(name)
        {
        }

        public Triangle(string name, Point p1, Point p2,Point p3)
            : base(name)
        {
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
           
        }

        public Triangle(string name, Color backgroundColor,Color edgeColor, Point p1, Point p2, Point p3)
            : base(name, backgroundColor,edgeColor)
        {
            this.AddPoint(p1);
            this.AddPoint(p2);
            this.AddPoint(p3);
            
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

        public override double Area
        {
            get 
            { 
                /*  Heron's formula :
                 *  A = sqrt(s(s-a)(s-b)(s-c))
                 *  
                 *  s = (1/2)(a+b+c)
                 *  a,b,c : sides of the trianlge
                 */

                Segment a = new Segment("a",P1, P2),
                        b = new Segment("b",P2, P3),
                        c = new Segment("c",P3, P1);

                double s = (a.Length + b.Length + c.Length)/2;

                return Math.Sqrt(s * (s - a.Length) * (s - b.Length) * (s - c.Length));
            }
        }

        public override int Type
        {
            get { return _type; }
        }

        protected override string ToJsonSpecificMore()
        {
            return "\"P1\":{\"X\":" + P1.X.ToString().Replace(',', '.') + ",\"Y\":" + P1.Y.ToString().Replace(',', '.') 
                + "},\"P2\":{\"X\":" + P2.X.ToString().Replace(',', '.') + ",\"Y\":" + P2.Y.ToString().Replace(',', '.') 
                + "},\"P3\":{\"X\":" + P3.X.ToString().Replace(',', '.') + ",\"Y\":" + P3.Y.ToString().Replace(',', '.') + "}";
        }


        /***********************************
         *  InitializeForm
         ***********************************/
        public override Shape InitializeForm()
        {
            return new Triangle("triangle");
        }

        /***********************************
       *  Create Form
       ***********************************/
        public override void Create(int x, int y, Color edgeColor, Color backgroundColor)
        {
            if (this.Points.Count < 2)
            {
                this.SetColors(edgeColor, backgroundColor);
                this.Points.Add(new Point(x, y));
                this.Points.Add(new Point(x, y));
            }
            else if(this.Points.Count == 2)
                this.Points.Add(new Point(x, y));
        }


        /***********************************
        *  ToString
        ***********************************/
        public override string ToString()
        {
            String s = "Triangle : \n";
            s += base.ToString();
            return s;
        }

    }
}