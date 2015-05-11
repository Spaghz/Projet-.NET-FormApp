using FormApp.Core.Shapes;
using FormApp.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FormApp.Core.Shapes
{
    public class Group : Shape, IEnumerable
    {
        /***********************************
         *  Members
         ***********************************/

        private List<Shape>  _forms;
        private bool        _singleColorGroup;
        private static readonly int _type = 5;

        /***********************************
         *  Constructor(s)
         ***********************************/
        public Group(string name) : base(name) 
        {
            _forms = new List<Shape>();
            _singleColorGroup = false;
        }

        public Group(string name, Color backgroundColor,Color edgeColor) : base(name, backgroundColor,edgeColor)
        {
            _forms = new List<Shape>();
            _singleColorGroup = true;
        }

        /***********************************
         *  Properties
         ***********************************/

        public override double Area
        {
            get
            {
                double area = 0;

                foreach (Shape f in this)
                    area += f.Area;

                return area;
            }
        }

        public override int Type
        {
            get { return _type; }
        }

        /***********************************
         *  Public methods
         ***********************************/
        public void AddForm(Shape f)
        {
            if (this.isPresent(f))
                throw new ArgumentException("Can not add a form that is already in the group.");
            if (f.Parent != null)
                throw new ArgumentException("Form already belongs to a group, you must detach it first.");

            _forms.Add(f);
        }

        /***********************************
         *  Private methods
         ***********************************/
        private bool isPresent(Shape f)
        {
            foreach(Shape groupForm in this)
                if (groupForm == f)
                    return true;

            return false;
        }

        protected override string ToJsonSpecific()
        {
            String res = "{\"groupData\":{";

            List<string> forms = new List<String>();

            foreach(Shape f in this)
            {
                forms.Add(f.ToJson());
            }

            return res + StringUtils.implode(forms, ',') + "}";
        }

        /***********************************
         * IEnumerable 
         ***********************************/

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public GroupEnum GetEnumerator()
        {
            return new GroupEnum(_forms);
        }


        /***********************************
        * Transformations
        ***********************************/

        public override void Translation(Vector v)
        {
            foreach (Shape s in _forms)
                s.Translation(v);
        }

        public override void Rotation(Point p, float angle_radiant)
        {
            foreach (Shape s in _forms)
                s.Rotation(p, angle_radiant);
        }

        public override void Homotethie(double rapport)
        {
            foreach (Shape s in _forms)
                s.Homotethie(rapport);
        }

        /***********************************
         *  Draw
         ***********************************/
        public override void Draw(System.Drawing.Graphics g, System.Drawing.Pen pen)
        {
            foreach (Shape fIn in _forms)
                fIn.Draw(g, pen);
        }

        /***********************************
         *  SetParameters
         ***********************************/
        public override void SetParamaters(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        /***********************************
         *  SetColors
         ***********************************/
        public override void SetColors(Color edgeColor, Color backgroundColor)
        {
            this.EdgeColor = edgeColor;
            this.BackgroundColor = backgroundColor;
        }

        /***********************************
         *  InitializeForm
         ***********************************/
        public override Shape InitializeForm()
        {
            return new Group("group");
        }

        /***********************************
        *  Create Form
        ***********************************/
        public override void Create(int x, int y, Color edgeColor, Color backgroundColor)
        {
            this.SetColors(edgeColor, backgroundColor);
        }
    }
}
