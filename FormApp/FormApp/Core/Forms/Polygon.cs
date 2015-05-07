using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Utils;
using System.Collections;

namespace FormApp.Core.Forms
{
    public class Polygon : FormSimple, IEnumerable
    {
        /***********************************
         *  Members
         ***********************************/
        private List<Point> _points;

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
            get { throw new NotImplementedException(); }
        }

        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
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
            String s = "Polygon : \n";
            foreach (Point p in this)
                s += p.ToString() + "\n";

            return s;
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
            return "";
            //return "{\"P1\":{\"X\":" + P1.X + ",\"Y\":" + P1.Y + "},\"P2\":{\"X\":" + P2.X + ",\"Y\":" + P2.X + "},\"P3\":{\"X\":" + P3.X + ",\"Y\":" + P3.X + "}}";
        }

        public override Form Translation(Vector v)
        {
            throw new NotImplementedException();
        }

        public override Form Rotation(Point p, float angle_radiant)
        {
            throw new NotImplementedException();
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
                listPoints[i] = (System.Drawing.Point) pIn;
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
        public override Form InitializeForm()
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
    }
}
