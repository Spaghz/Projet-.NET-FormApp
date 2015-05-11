using FormApp.Core.Shapes;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes
{
    public sealed class Segment : ShapeSimple
    {
        private Point _p1, _p2;
        private static readonly int _type = 2;

        public Segment(string name)
            : base(name)
        {
            _p1 = null;
            _p2 = null; 
        }

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

        public override int Type
        {
            get { return _type; }
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



       /***********************************
       *  Draw
       ***********************************/

       public override void Translation(Vector v)
       {
          P1 = v.translation(P1);
          P2 = v.translation(P2);
       }


        public override void Homotethie(double rapport)
        {
           P1.X *= rapport;
           P1.Y *= rapport;

           P2.X *= rapport;
           P2.Y *= rapport;
        }

       
        public override void Rotation(Point p, float angle_radiant)
        {
            if(p == P1) //P1 is invariant, P2 will be modified
            {
                P2.X = ((P2.X-P1.X)*Math.Cos(angle_radiant)) - ((P2.Y-P1.Y)*Math.Sin(angle_radiant) + P1.X);
                P2.Y = ((P2.X-P1.X)*Math.Sin(angle_radiant)) + ((P2.Y-P1.Y)*Math.Cos(angle_radiant) + P1.Y);
            }
            else if(p == P2) //P2 is invariant, P1 will be modified
            {
                P1.X = ((P1.X-P2.X)*Math.Cos(angle_radiant)) - ((P1.Y-P2.Y)*Math.Sin(angle_radiant) + P2.X);
                P1.Y = ((P1.X-P2.X)*Math.Sin(angle_radiant)) + ((P1.Y-P2.Y)*Math.Cos(angle_radiant) + P2.Y);
            }
            else
            {
                System.Console.WriteLine("Choose a segment point !");
            }
        }



        /***********************************
         *  Draw
         ***********************************/
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            int[] rgb = EdgeColor.intToRgb();
            pen.Color = System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            g.DrawLine(pen, (System.Drawing.Point) this.P1, (System.Drawing.Point) this.P2);
        }


        /***********************************
         *  SetParameters
         ***********************************/
        public override void SetParamaters(int x1, int y1, int x2, int y2)
        {
            _p2 = new Point(x2, y2);
        }


        /***********************************
         *  InitializeForm
         ***********************************/
        public override Shape InitializeForm()
        {
            return new Segment("segment");
        }


        /***********************************
        *  Create Form
        ***********************************/
        public override void Create(int x, int y, Color edgeColor, Color backgroundColor)
        {
            this.SetColors(edgeColor, backgroundColor);
            _p1 = new Point(x, y);
        }



        /***********************************
       *  ToString
       ***********************************/
        public override string ToString()
        {
            String s = "Segment : \n";
            s += P1.ToString() + "\n" + P2.ToString();
            return s;
        }

    }
}
