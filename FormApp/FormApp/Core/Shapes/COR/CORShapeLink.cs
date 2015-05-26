using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Shapes.COR
{
    abstract public class CORShapeLink : CORShape
    {
        private CORShapeLink next;

        public CORShapeLink(CORShapeLink next = null) : base()
        {
            this.next = next;
        }

        public override Shape CreateShape1(string[] splittedSerializedShape)
        {
            if (Convert.ToInt32(splittedSerializedShape[0]) == Type)
                return CreateShape2(splittedSerializedShape);
            else if (this.next != null)
                return this.next.CreateShape1(splittedSerializedShape);
            return null;
        }

        abstract protected Shape CreateShape2(string[] splittedSerializedShape);

        abstract public int Type
        {
            get;
        }
    }
}
