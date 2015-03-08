using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormApp.Core.Forms
{
    abstract public class Form
    {
        /***********************************
         *  Members
         ***********************************/
        private Color   _color;
        private int     _id;
        private Form    _parent;

        /***********************************
         *  Constructor(s)
         ***********************************/
        protected Form()
        {
            //_color = Color.BLACK;
            _id     = -1;
            _parent = null;
        }

        protected Form(Color color)
        {
            _color = color;
        }

        /***********************************
         *  Properties
         ***********************************/

        public Color Color
        {
            get { return _color; }
        }

        public Form Parent
        {
            get { return _parent; }
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
    }
}
