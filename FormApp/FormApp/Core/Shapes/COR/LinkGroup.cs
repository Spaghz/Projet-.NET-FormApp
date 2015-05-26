using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormApp.Core.Shapes;
using FormApp.Core.Utils;
namespace FormApp.Core.Shapes.COR
{
    public class LinkGroup : CORShapeLink
    {
        public LinkGroup(CORShapeLink next = null) : base(next) { }

        protected override Shape CreateShape2(string[] splittedSerializedShape)
        {
            int i = 1, j = 1, k = 0, length = 0;
            string[] currentShape = new string[512];

            Group g = new Group(
                splittedSerializedShape[2],
                new Color(Convert.ToInt32(splittedSerializedShape[5])),
                new Color(Convert.ToInt32(splittedSerializedShape[6])));

            while (!splittedSerializedShape[7 + i].Equals("</FORMS>"))
            {
                while(!splittedSerializedShape[7+i+j].Equals("</FORM>"))
                {
                    currentShape[k] = splittedSerializedShape[7 + i + j];
                    k++;
                    j++;
                    length++;
                }
                g.AddForm(COR.Instance.CORShape.CreateShape1(currentShape));
                i += length+2;
                j = 0;
            }

            g.Id = Convert.ToInt32(splittedSerializedShape[1]);

            return g;
        }

        public override int Type
        {
            get { return Group._type; }
        }
    }
}
