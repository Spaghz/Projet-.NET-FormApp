﻿using FormApp.Core.Utils;
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
            set { _backgroundColor = value; }
        }

        [DataMember]
        public Color EdgeColor
        {
            get { return _edgeColor; }
            set { _edgeColor = value; }
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
            set { _name = value ;}
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


        /***********************************
         *  Draw
         ***********************************/
        public abstract void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen);

        /***********************************
         *  SetParameters
         ***********************************/
        public abstract void SetParamaters(int x1, int y1, int x2, int y2);

        /***********************************
         *  SetColors
         ***********************************/
        public abstract void SetColors(Color edgeColor, Color backgroundColor);

        /***********************************
         *  InitializeForm
         ***********************************/
        public abstract Form InitializeForm();

        /***********************************
        *  Create Form
        ***********************************/
        public abstract void Create(int x, int y, Color edgeColor, Color backgroundColor);
    }
}
