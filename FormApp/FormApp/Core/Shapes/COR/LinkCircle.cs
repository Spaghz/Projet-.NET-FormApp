using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using FormApp.Core.Utils;
namespace FormApp.Core.Shapes.COR
{
    public class LinkCircle : CORShapeLink
    {
        public LinkCircle(CORShapeLink next = null) : base(next) { }

        protected override Shape CreateShape2(string[] splittedSerializedShape)
        {
            Point A = new Point(splittedSerializedShape[8]),
                    B = new Point(splittedSerializedShape[9]);

            Circle c = new Circle(
                splittedSerializedShape[2],
                new Color(Convert.ToInt32(splittedSerializedShape[5])),
                new Color(Convert.ToInt32(splittedSerializedShape[6])),
                A,
                B
                );

            c.Id = Convert.ToInt32(splittedSerializedShape[1]);

            return c;
        }

        public override int Type
        {
            get { return Circle._type; }
        }
    }
}
