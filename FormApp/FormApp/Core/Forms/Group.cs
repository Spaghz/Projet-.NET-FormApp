using FormApp.Core.Forms;
using FormApp.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace FormApp.Core.Forms
{
    public class Group : Form, IEnumerable
    {
        /***********************************
         *  Members
         ***********************************/

        private List<Form>  _forms;
        private bool        _singleColorGroup;

        /***********************************
         *  Constructor(s)
         ***********************************/
        public Group(string name) : base(name) 
        {
            _forms = new List<Form>();
            _singleColorGroup = false;
        }

        public Group(string name, Color backgroundColor,Color edgeColor) : base(name, backgroundColor,edgeColor)
        {
            _forms = new List<Form>();
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

                foreach (Form f in this)
                    area += f.Area;

                return area;
            }
        }

        /***********************************
         *  Public methods
         ***********************************/
        public void AddForm(Form f)
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
        private bool isPresent(Form f)
        {
            foreach(Form groupForm in this)
                if (groupForm == f)
                    return true;

            return false;
        }

        protected override string ToJsonSpecific()
        {
            String res = "{\"groupData\":{";

            List<string> forms = new List<String>();

            foreach(Form f in this)
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
        * Functions
        ***********************************/

        public override Form Translation(Vector v)
        {
            throw new NotImplementedException();
        }

        public override Form Rotation(Point p, float angle_radiant)
        {
            throw new NotImplementedException();
        }

        public override int Type
        {
            get { throw new NotImplementedException(); }
        }
    }
}
