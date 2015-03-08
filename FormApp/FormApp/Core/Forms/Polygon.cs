using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Utils;
using System.Collections;

namespace FormApp.Core.Forms
{
    public sealed class Polygon : FormSimple, IEnumerable
    {
        /***********************************
         *  Members
         ***********************************/
        private List<Point> _points;

        /***********************************
         *  Constructor(s)
         ***********************************/
        public Polygon() : base() 
        {
            _points = new List<Point>();
        }

        public Polygon(Color color) : base(color) 
        {
            _points = new List<Point>();
        }

        public Polygon(Polygon polygon) : base(polygon.Color)
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

        /***********************************
         *  Methods
         ***********************************/
        public void AddPoint(Point p)
        {
            foreach (Point polygonPoint in this)
                if (polygonPoint == p)
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

            Polygon polygonToReturn = new Polygon(polygon);
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
    }
}
