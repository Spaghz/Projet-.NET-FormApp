﻿using FormApp.Core.Forms;
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

        private Point _p1, _p2, _p3;

        public Triangle(string nom, Point p1, Point p2,Point p3)
            : base(nom)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;

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
            get { return _p1; }
            set { _p1 = value; }
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

                Segment a = new Segment("a",P1, P2),
                        b = new Segment("b",P2, P3),
                        c = new Segment("c",P3, P1);

                double s = (a.Length + b.Length + c.Length)/2;

                return Math.Sqrt(s * (s - a.Length) * (s - b.Length) * (s - c.Length));
            }
        }

        protected override string ToJsonSpecificMore()
        {
            return "\"P1\":{\"X\":" + P1.X.ToString().Replace(',', '.') + ",\"Y\":" + P1.Y.ToString().Replace(',', '.') 
                + "},\"P2\":{\"X\":" + P2.X.ToString().Replace(',', '.') + ",\"Y\":" + P2.Y.ToString().Replace(',', '.') 
                + "},\"P3\":{\"X\":" + P3.X.ToString().Replace(',', '.') + ",\"Y\":" + P3.Y.ToString().Replace(',', '.') + "}";
        }
    }
}