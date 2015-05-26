using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using FormApp.Core.Utils;
namespace FormApp.Core.Shapes.COR
{
    public class LinkRectangle : CORShapeLink
    {
        public LinkRectangle(CORShapeLink next = null) : base(next) { }

        protected override Shape CreateShape2(string[] splittedSerializedShape)
        {
            Point A = new Point(splittedSerializedShape[8]),
                    B = new Point(splittedSerializedShape[9]),
                    C = new Point(splittedSerializedShape[10]),
                    D = new Point(splittedSerializedShape[11]);

            Rectangle r = new Rectangle(
                splittedSerializedShape[2],
                new Color(Convert.ToInt32(splittedSerializedShape[5])),
                new Color(Convert.ToInt32(splittedSerializedShape[6])),
                A,
                B,
                C,
                D
                );

            r.Id = Convert.ToInt32(splittedSerializedShape[1]);

            return r;
        }

        public override int Type
        {
            get { return Rectangle._type; }
        }
    }
}
