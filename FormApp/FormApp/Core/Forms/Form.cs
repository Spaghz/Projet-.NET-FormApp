using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FormApp.Core.Forms
{
    [DataContractAttribute]
    abstract public class Form
    {
        /***********************************
         *  Members
         ***********************************/
        private Color   _backgroundColor=null,_edgeColor=null;

        private int     _id=-1;

        private Form    _parent=null;

        private int     _edgeSize=1;
        /***********************************
         *  Constructor(s)
         ***********************************/
        protected Form()
        {
        }

        protected Form(Color backgroundColor)
        {
            _backgroundColor = backgroundColor;
        }

        /***********************************
         *  Properties
         ***********************************/

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
        }

        public Color EdgeColor
        {
            get { return _edgeColor; }
        }

        public Form Parent
        {
            get { return _parent; }
        }

        public int EdgeSize
        {
            get { return _edgeSize; }
        }

        abstract public double Area
        {
            get;
        }

        /***********************************
         *  Methods
         ***********************************/

        public void Detach()
        {
            _parent = null;
        }

        public string ToJson()
        {
            return "{\"form\":{" + ToJsonSpecific() + ",\"globalData\":{\"BackgroundColor\":" + (BackgroundColor == null ? "null" : BackgroundColor.ToString()) + ",\"EdgeColor\":" + (EdgeColor == null ? "null" : EdgeColor.ToString()) + ",\"Parent\":" + (Parent == null ? "null" : Parent.ToString()) + ",\"EdgeSize\":" + (EdgeSize == null ? "null" : EdgeSize.ToString()) + "}}}";
        }

        protected abstract string ToJsonSpecific();
    }
}
