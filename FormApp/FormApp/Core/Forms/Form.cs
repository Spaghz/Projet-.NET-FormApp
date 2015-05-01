using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FormApp.Core.Forms
{
    [DataContract]
    abstract public class Form
    {
        /***********************************
         *  Members
         ***********************************/
        private Color   _backgroundColor    =   new Color(Color.WHITE),
                        _edgeColor          =   new Color(Color.BLACK);

        private int     _id=-1;

        private Form    _parent=null;

        private int     _edgeSize=1;

        private string  _name;
        /***********************************
         *  Constructor(s)
         ***********************************/
        protected Form(string nom)
        {
            _name = nom;
        }

        protected Form(string name,Color backgroundColor,Color edgeColor)
        {
            _name = name;
            _backgroundColor = backgroundColor;
            _edgeColor = edgeColor;
        }

        /***********************************
         *  Properties
         ***********************************/

        [DataMember]
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
        }

        [DataMember]
        public Color EdgeColor
        {
            get { return _edgeColor; }
        }

        [DataMember]
        public Form Parent
        {
            get { return _parent; }
        }

        [DataMember]
        public int EdgeSize
        {
            get { return _edgeSize; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
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
            return "\"" + this.Name + "\":" + ToJsonSpecific() + ",\"globalData\":{\"BackgroundColor\":" + BackgroundColor.ToString() + ",\"EdgeColor\":" + EdgeColor.ToString() + ",\"Parent\":" + (Parent == null ? "null" : Parent.ToString()) + ",\"EdgeSize\":" + EdgeSize.ToString() + "}}";
        }

        protected abstract string ToJsonSpecific();




        /***********************************
         *  Operations
         ***********************************/

        public abstract Form Translation(Vector v);

        public abstract Form Rotation(Point p, float angle_radiant);

    
    }
}
