using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes.COR
{
    public class COR
    {
        private static COR instance;
        private CORShape corShape;

        private COR() {
            LinkSegment linkSegment = new LinkSegment(null);
            LinkTriangle linkTriangle = new LinkTriangle(linkSegment);
            LinkCircle linkCircle = new LinkCircle(linkTriangle);
            LinkRectangle linkRectangle = new LinkRectangle(linkCircle);
            LinkPolygon linkPolygon = new LinkPolygon(linkRectangle);
            LinkGroup linkGroup = new LinkGroup(linkPolygon);
            corShape = linkGroup;
        }

        public static COR Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new COR();
                }
                return instance;
            }
        }

        public CORShape CORShape
        {
            get { return this.corShape; }
        }
    }
}
