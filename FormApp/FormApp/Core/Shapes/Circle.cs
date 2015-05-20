using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Utils;

namespace FormApp.Core.Shapes
{
    public sealed class Circle : ShapeSimple
    {
        /***********************************
         *  Members
         ***********************************/

        private Point   _center;
        private Point   _distantEdgePoint;
        private double  _radius;
        private static readonly int _type = 6;

        /***********************************
         *  Constructor(s)
         ***********************************/

        public Circle(string nom) 
            :base(nom)
        {
            _radius = 0.0;
            _center = null;
            _distantEdgePoint = null;
        }

        public Circle(string nom, Point center,double radius) : base(nom)
        {

            Point tmp = new Point(center.X + radius, center.Y);
            checkParameters(center, tmp, radius);

            _center = center;
            _distantEdgePoint = tmp; 
            _radius = radius;
        }

        public Circle(string nom, Point center, Point distantEdgePoint)
            : base(nom)
        {
            _center = center;
            _distantEdgePoint = distantEdgePoint;
            _radius = new Vector(center, distantEdgePoint).Length;
            checkParameters(center, distantEdgePoint, _radius);

        }



        public Circle(string nom, Circle c)
            : base(nom)
        {
            _center = c.Center;
            _distantEdgePoint = c.DistantEdgePoint;
            _radius = new Vector(c.Center, c.DistantEdgePoint).Length;
            checkParameters(c.Center, c.DistantEdgePoint, _radius);

        }



        public Circle(string nom, Color backgroundColor,Color edgeColor,Point center,double radius) : base(nom, backgroundColor,edgeColor)
        {

            Point tmp_distantEdgePoint = new Point(center.X + radius, center.Y);
            checkParameters(center, tmp_distantEdgePoint, radius);


            _center = center;
            _distantEdgePoint = tmp_distantEdgePoint;
            _radius = radius;

        }

        public Circle(Circle c)
            : base(c.Name)
        {
            _center = c.Center;
            _distantEdgePoint = c.DistantEdgePoint;
            _radius = c.Radius;

        }



        /***********************************
         *  Properties
         ***********************************/

        public Point Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public Point DistantEdgePoint
        {
            get { return _distantEdgePoint; }
            set { _distantEdgePoint = value; }
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

        public override int Type
        {
            get { return _type; }
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
         *  Check methods
         ***********************************/

        private static void checkParameters(Point center, Point distantEdgePoint, double radius)
        {
            checkCenter(center);
            checkDistantPointEdgePoint(distantEdgePoint);
            checkRadius(radius);
        }

        private static void checkRadius(double radius)
        {
            //if (radius <= 0)
            if(radius < 0)
                throw new ArgumentException("Radius of a circle can not be inferior or equals to 0");
        }

        private static void checkCenter(Point center)
        {
            if (center == null)
                throw new ArgumentNullException();
        }

        private static void checkDistantPointEdgePoint(Point distantEdgePoint)
        {
            if (distantEdgePoint == null)
                throw new ArgumentNullException();
        }


        /***********************************
         *  Utils 
         ***********************************/

        protected override string ToJsonSpecificMore()
        {
           return   "\"Center\":{\"X\":" + Center.X.ToString().Replace(',', '.') + ",\"Y\":" + Center.Y.ToString().Replace(',', '.') + "},"
                +   "\"DistantEdgePoint\":{\"X\":" + DistantEdgePoint.X.ToString().Replace(',', '.') + ",\"Y\":" + DistantEdgePoint.Y.ToString().Replace(',', '.')
                +   "},\"Radius\":" + Radius.ToString().Replace(',', '.');
        }


        public List<Point> Discrectisation(int precision)
        {
            double x, y;
            List<Point> discretised_circle = new List<Point>();

            for (int i = 1; i <= precision; i++)
            {
                x = Radius * Math.Cos((2 * Math.PI) / precision * i) + Center.X;
                y = Radius * Math.Sin((2 * Math.PI) / precision * i) + Center.Y;

                Point p = new Point(x, y);
                discretised_circle.Add(p);

            }

            return discretised_circle;
        }


        /***********************************
        *  Transformations
        ***********************************/


        public override Shape Translation(Vector v)
        {
            Center = Center.Translation(v);
            DistantEdgePoint = DistantEdgePoint.Translation(v);

            return this;
        }


        public override Shape Homothetie(Point p, double rapport)
        {
            Center = Center.Homothetie(p, rapport);
            DistantEdgePoint = DistantEdgePoint.Homothetie(p, rapport);
            Radius *= rapport;

            return this;
        }


        public override Shape Homothetie(double rapport)
        {
            return Homothetie(new Point(0.0, 0.0), rapport);
        }


        public override Shape Rotation(Point point, double angle)
        {
            Center = Center.Rotation(point, angle);
            DistantEdgePoint = DistantEdgePoint.Rotation(point, angle);

            return this;
        }


        /***********************************
         *  Draw
         ***********************************/
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            int[] rgb = EdgeColor.intToRgb();
            pen.Color = System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            g.DrawEllipse(pen, (System.Drawing.Rectangle)this);
        }


        /***********************************
         *  Cast rectangle
         ***********************************/
        public static explicit operator System.Drawing.Rectangle(Circle circle)
        {
            return new System.Drawing.Rectangle((int)(circle.Center.X - circle.Radius),
                                                                (int)(circle.Center.Y - circle.Radius),
                                                                (int)(circle.Radius * 2), (int)(circle.Radius * 2));
        }


        /***********************************
        *  SetParameters
        ***********************************/
        public override void SetParamaters(int x1, int y1, int x2, int y2)
        {
            this.Radius = (Math.Abs(x1 - x2) / 2.0);
            this.Center = new Point(Math.Min(x1, x2) + this.Radius, Math.Min(y1, y2) + this.Radius);
            this._distantEdgePoint = new Point(Center.X + Radius, Center.Y);
        }


        /***********************************
         *  InitializeForm
         ***********************************/
        public override Shape InitializeForm()
        {
            return new Circle("circle");
        }


        /***********************************
        *  Create Form
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
            String s = "Cercle : \n";
            s += "{ Center " + Name + ": " + Center.ToString() + " ; Radius : " + Radius + " ; DistantEdgePoint : " + DistantEdgePoint.ToString() + " }";
            return s;
        }



    }
}
