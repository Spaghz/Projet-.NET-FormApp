using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using FormApp.Core.Utils;
namespace FormApp.Core.Shapes.COR
{
    public class LinkPolygon : CORShapeLink
    {
        public LinkPolygon(CORShapeLink next = null) : base(next) { }

        protected override Shape CreateShape2(string[] splittedSerializedShape)
        {
            int i = 1;

            Polygon p = new Polygon(
                splittedSerializedShape[2],
                new Color(Convert.ToInt32(splittedSerializedShape[5])),
                new Color(Convert.ToInt32(splittedSerializedShape[6])));

            while(!splittedSerializedShape[7+i].Equals("</POINTS>"))
            {
                p.AddPoint(new Point(splittedSerializedShape[7+i]));
                i++;
            }

            p.Id = Convert.ToInt32(splittedSerializedShape[1]);

            return p;
        }

        public override int Type
        {
            get { return Polygon._type; }
        }
    }
}
