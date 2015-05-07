using FormApp.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes
{
    public class PolygonEnum : IEnumerator
    {
        int         _pos;
        List<Point> _points;

        public PolygonEnum(List<Point> points)
        {
            _pos = -1;
            _points = points;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _points[_pos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            _pos++;
            return (_pos < _points.Count);
        }

        public void Reset()
        {
            _pos = -1;
        }
    }
}
