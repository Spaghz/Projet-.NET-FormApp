using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using FormApp.Core.Utils;

namespace FormApp.Core.Shapes
{
    public class Rectangle : Polygon
    {
        private static readonly int _type = 3;

        public Rectangle(string name)
            : base(name)
        {
           
        }


        public Rectangle(string name, Point p1, Point p2)
            : base(name)
        {
          
            if (p1.X == p2.X || p1.Y == p2.Y)
                throw new ArgumentException("X or Y parameters are equals, try another second point");
            else
            {
                this.AddPoint(p1);
                this.AddPoint(p2);

                this.AddPoint(new Point(p2.X, p1.Y));
                this.AddPoint(new Point(p1.X, p2.Y));
            }
        }

       

        public Rectangle(string name, Color backgroundColor, Color edgeColor, Point p1, Point p2)
            : base(name, backgroundColor, edgeColor)
        {
            if (p1.X == p2.X || p1.Y == p2.Y)
                throw new ArgumentException("X or Y parameters are equals, try another second point");
            else
            {
                this.AddPoint(p1);
                this.AddPoint(p2);

                this.AddPoint(new Point(p2.X, p1.Y));
                this.AddPoint(new Point(p1.X, p2.Y));
            }
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

        public override int Type
        {
            get { return _type; }
        }

    // Aire d'un polygone = aire d'un rectangle
    /*    public override double Area
        {
            get
            {
                Segment a = new Segment("a", P1, P2),
                        b = new Segment("b", P2, P3);

                return (a.Length * b.Length);
            }
        }
        */
        protected override string ToJsonSpecificMore()
        {
            return "\"P1\":{\"X\":" + P1.X.ToString().Replace(',', '.') + ",\"Y\":" + P1.Y.ToString().Replace(',', '.')
                + "},\"P2\":{\"X\":" + P2.X.ToString().Replace(',', '.') + ",\"Y\":" + P2.Y.ToString().Replace(',', '.')
                + "},\"P3\":{\"X\":" + P3.X.ToString().Replace(',', '.') + ",\"Y\":" + P3.Y.ToString().Replace(',', '.')
                + "},\"P4\":{\"X\":" + P4.X.ToString().Replace(',', '.') + ",\"Y\":" + P4.Y.ToString().Replace(',', '.')
                + "}";
        }


        /***********************************
         *  Draw
         ***********************************/
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            int[] rgb = EdgeColor.intToRgb();
            pen.Color = System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            g.DrawRectangle(pen, (System.Drawing.Rectangle)this);
        }


        /***********************************
         *  Height, width
         ***********************************/
        public int Width()
        {
            return (int)(P2.X - P1.X);
        }

        public int Height()
        {
            return (int)(P1.Y - P3.Y);
        }


        /***********************************
         *  Cast rectangle
         ***********************************/
        public static explicit operator System.Drawing.Rectangle(Rectangle rectangle)
        {
            return new System.Drawing.Rectangle((int)rectangle.P1.X, (int)rectangle.P4.Y,
                                                            rectangle.Width(),
                                                            rectangle.Height());
        }


        /***********************************
         *  SetParameters
         ***********************************/
        public override void SetParamaters(int x1, int y1, int x2, int y2)
        {
            this.P1 = new Point(Math.Min(x1, x2), Math.Max(y1, y2));
            this.P4 = new Point(Math.Max(x1, x2), Math.Min(y1, y2));
            this.P2 = new Point(this.P4.X, this.P1.Y);
            this.P3 = new Point(this.P1.X, this.P4.Y);
        }


        /***********************************
         *  InitializeForm
         ***********************************/
        public override Shape InitializeForm()
        {
            return new Rectangle("rectangle");
        }

        /***********************************
         *  Create Rectangle
         ***********************************/
        public override void Create(int x, int y, Color edgeColor, Color backgroundColor)
        {
            this.SetColors(edgeColor, backgroundColor);
        }



        /***********************************
        *  ToString
        ***********************************/
        public override string ToString()
        {
            String s = "Rectangle : \n";
            s += base.ToString();
            return s;  
        }

      
        

    }
}

    