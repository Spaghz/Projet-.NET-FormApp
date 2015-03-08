using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Forms
{
    /// <summary>
    /// No attribute to class to make it only available by same namespace (Group.cs)
    /// </summary>
    public class GroupEnum : IEnumerator
    {
        private List<Form>  _forms;
        int                 _pos;

        public GroupEnum(List<Form> forms)
        {
            _forms = forms;
            _pos = -1;
        }

        public Form Current
        {
            get 
            {
                try
                {
                    return _forms[_pos];
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
            return (_pos < _forms.Count);
        }

        public void Reset()
        {
            _pos = -1;
        }

        object IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }
    }
}
