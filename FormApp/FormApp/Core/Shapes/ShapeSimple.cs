using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes
{
    abstract public class ShapeSimple : Shape
    {
        protected ShapeSimple(string name) : base(name) {}
        protected ShapeSimple(string name, Color backgroundColor,Color edgeColor) : base(name, backgroundColor,edgeColor) { }

        abstract public override double Area
        {
            get;
        }

        protected override string ToJsonSpecific()
        {
            return "{\"specificData\":{" + ToJsonSpecificMore() + "}";
        }

        abstract protected string ToJsonSpecificMore();

        /***********************************
         *  SetColors
         ***********************************/
        public override void SetColors(Color edgeColor, Color backgroundColor)
        {
            this.EdgeColor = edgeColor;
            this.BackgroundColor = backgroundColor;
        }

        abstract public override int Type
        {
            get;
        }

       
        /***********************************
        *  Transformations
        ***********************************/

        abstract public override Shape Homothetie(Point p, double rapport);

        abstract public override Shape Homothetie(double rapport);

        abstract public override Shape Translation(Vector v);

        abstract public override Shape Rotation(Point p, double angle_radiant);

        /***********************************
         *  Drawing
         ***********************************/

        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            throw new NotImplementedException();
        }

        public override void SetParamaters(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        public override Shape InitializeForm()
        {
            throw new NotImplementedException();
        }

        public override void Create(int x, int y, Color edgeColor, Color backgroundColor)
        {
            throw new NotImplementedException();
        }


        abstract override public string ToString();


    }
}
