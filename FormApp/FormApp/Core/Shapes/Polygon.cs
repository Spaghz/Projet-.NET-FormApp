using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Utils;
using System.Collections;

namespace FormApp.Core.Shapes
{
    public class Polygon : ShapeSimple, IEnumerable
    {
        /***********************************
         *  Members
         ***********************************/
        private List<Point> _points;
        public readonly static int _type = 4;
        bool convexe = true;

        /***********************************
         *  Constructor(s)
         ***********************************/
        public Polygon(string nom) : base(nom) 
        {
            _points = new List<Point>();
        }

        public Polygon(string nom, Color backgroundColor,Color edgeColor) : base(nom, backgroundColor,edgeColor) 
        {
            _points = new List<Point>();
        }

        public Polygon(string nom, Polygon polygon) : base(nom, polygon.BackgroundColor,polygon.EdgeColor)
        {
            _points = new List<Point>(polygon._points);
        }

        /***********************************
         *  Properties
         ***********************************/


        public override double Area
        {
                get { return calculatePolygonArea(Points); }
        }

        private double calculatePolygonArea(List<Point> points)
        {

            double area = 0.0;

            for (int i = 0, j = Count-1; i < Count; i++)
            {
                area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y);
                j = i;
            }

            if (area < 0)
                return -area / 2;
            else
                return area / 2;
        }



        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public override int Type
        {
            get { return _type; }
        }

        public int Count
        {
            get { return Points.Count; }
        }


        public bool isConvexe
        {
            get { return this.convexe; }
        }

        /***********************************
         *  Methods
         ***********************************/
        public void AddPoint(Point p)
        {
            foreach (Point polygonPoint in this)
                if (polygonPoint == p && p != null)
                    throw new ArgumentException("Point is already present in the polygon");

            _points.Add(p);
        }

        public override string ToString()
        {
            String s = "";
            foreach (Point p in this)
                s += "    " + p.ToString() + "\n";

            return s;
        }

        public void ClearDoublons()
        {
            this.Points.Remove(this.Points[0]);
            int size = this.Points.Count;
            this.Points.Remove(this.Points[size - 1]);
        }

        /***********************************
         *  Operator overload
         ***********************************/

        public static Polygon operator + (Polygon polygon,Point point)
        {
            if ((polygon == null) || (point == null))
                throw new ArgumentNullException();

            Polygon polygonToReturn = new Polygon(polygon.Name,polygon);
            polygonToReturn.AddPoint(point);
            return polygonToReturn;
        }

        /***********************************
         *  IEnumerator shit
         ***********************************/
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PolygonEnum GetEnumerator()
        {
            return new PolygonEnum(_points);
        }

        protected override string ToJsonSpecificMore()
        {
            String res = "";
            int i = 1;

            foreach(Point p in this)
                res += p.ToJson("P" + i++.ToString())+",";

            return res.Substring(0, res.Length - 1);
        }

        /***********************************
         *  Draw
         ***********************************/
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            int[] rgb = EdgeColor.intToRgb();
            pen.Color = System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]);

            System.Drawing.Point[] listPoints = new System.Drawing.Point[this.Points.Count];
            int i = 0;
            foreach(Point pIn in this.Points)
            {
                    listPoints[i] = (System.Drawing.Point)pIn;
                    i++;
            }

            g.DrawPolygon(pen, listPoints);    
        }

         /***********************************
         *  SetParameters
         ***********************************/
        public override void SetParamaters(int x1, int y1, int x2, int y2)
        {
                this.Points.Last().X = x2;
                this.Points.Last().Y = y2;
    
        }

        /***********************************
         *  InitializeForm
         ***********************************/
        public override Shape InitializeForm()
        {
            return new Polygon("polygon");
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
            else
                this.Points.Add(new Point(x, y));
        }





        /***********************************
        *  Transformation
       ***********************************/
        public override Shape Translation(Vector v)
        {
            //Eventuellement, à moins de rendre Point Iterable ???
            //foreach (Point p in Points)
            //    p = p.Translation(v);

           // On ne peut pas utiliser foreach ici, car nous avons besoin de modifier la valeur des Points de la liste
            for(int i=0; i<Count; i++)
                Points[i].Translation(v);
          
            return this;
        }



        public override Shape Homothetie(double rapport)
        {
            return Homothetie(new Point(0.0, 0.0), rapport);
        }


        public override Shape Homothetie(Point p, double rapport)
        {
            for (int i = 0; i < Count; i++)
                Points[i].Homothetie(p,rapport);

            return this;
        }


        public override Shape Rotation(Point point, double angle)
        {
            for (int i = 0; i < Count; i++)
                Points[i].Rotation(point, angle);

            return this;
        }
    }
}
