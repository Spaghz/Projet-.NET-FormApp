﻿using System;
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
        private Point   _randomEdgePoint;
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
            _randomEdgePoint = null;
        }

        public Circle(string nom, Point center,double radius) : base(nom)
        {

            Point tmp = new Point(center.X + radius, center.Y);
            checkParameters(center, tmp, radius);

            _center = center;
            _randomEdgePoint = tmp; 
            _radius = radius;
        }

        public Circle(string nom, Point center, Point randomEdgePoint)
            : base(nom)
        {
            _center = center;
            _randomEdgePoint = randomEdgePoint;
            _radius = new Vector(center, randomEdgePoint).Length;
            checkParameters(center, randomEdgePoint, _radius);

        }



        public Circle(string nom, Color backgroundColor,Color edgeColor,Point center,double radius) : base(nom, backgroundColor,edgeColor)
        {

            Point tmp_randomEdgePoint = new Point(center.X + radius, center.Y);
            checkParameters(center, tmp_randomEdgePoint, radius);


            _center = center;
            _randomEdgePoint = tmp_randomEdgePoint;
            _radius = radius;

        }

        public Circle(Circle c)
            : base(c.Name)
        {
            _center = c.Center;
            _randomEdgePoint = c.RandomEdgePoint;
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

        public Point RandomEdgePoint
        {
            get { return _randomEdgePoint; }
            set { _randomEdgePoint = value; }
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

        private static void checkParameters(Point center, Point randomEdgePoint, double radius)
        {
            checkCenter(center);
            checkRandomPointEdgePoint(randomEdgePoint);
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

        private static void checkRandomPointEdgePoint(Point randomEdgePoint)
        {
            if (randomEdgePoint == null)
                throw new ArgumentNullException();
        }


        /***********************************
         *  Utils 
         ***********************************/

        protected override string ToJsonSpecificMore()
        {
           return "\"Center\":{\"X\":" + Center.X.ToString().Replace(',', '.') + ",\"Y\":" + Center.Y.ToString().Replace(',', '.')
             + "},\"Radius\":" + Radius.ToString().Replace(',', '.');
        }


        /***********************************
        *  Operations
        ***********************************/


        public override Shape Translation(Vector v)
        {
            Circle c = new Circle(this);
            c.Center = v.translation(c.Center);
            

            return c;
        }

        public override Shape Rotation(Point p, float angle_radiant)
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
            this._randomEdgePoint = new Point(Center.X + Radius, Center.Y);
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
    }
}