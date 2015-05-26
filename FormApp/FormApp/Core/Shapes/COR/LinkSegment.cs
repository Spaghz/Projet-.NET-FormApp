using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using FormApp.Core.Utils;
namespace FormApp.Core.Shapes.COR
{
    public class LinkSegment : CORShapeLink
    {
        public LinkSegment(CORShapeLink next = null) : base(next) { }

        protected override Shape CreateShape2(string[] splittedSerializedShape)
        {
            Point A = new Point(splittedSerializedShape[8]),
                    B = new Point(splittedSerializedShape[9]);

            Segment s = new Segment(
                splittedSerializedShape[2],
                new Color(Convert.ToInt32(splittedSerializedShape[5])),
                new Color(Convert.ToInt32(splittedSerializedShape[6])),
                A,
                B
                );

            s.Id = Convert.ToInt32(splittedSerializedShape[1]);

            return s;
        }

        public override int Type
        {
            get { return Segment._type; }
        }
    }
}
