using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes.COR
{
    abstract public class CORShape
    {
        public CORShape() { }
        public Shape CreateShape(string serializedShape)
        {
            string[] splittedSerializedShape = serializedShape.Split('\n');
            return CreateShape1(splittedSerializedShape);
        }

        abstract public Shape CreateShape1(string[] splittedSerializedShape);
    }
}
