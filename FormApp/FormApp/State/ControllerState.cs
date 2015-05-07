using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp.State
{
    public abstract class ControllerState
    {
        protected ControllerState _back, _next, _next2;
        protected Form1 _drawWindow;

        public ControllerState(ControllerState back, ControllerState next, ControllerState next2, Form1 drawWindow)
        {
            _back = back;
            _next = next;
            _next2 = next2;
            _drawWindow = drawWindow;
        }

        public ControllerState Back
        {
            get { return _back;}
            set { _back = value; }
        }

        public ControllerState Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public ControllerState Next2
        {
            get { return _next2; }
            set { _next2 = value; }
        }

        public Form1 DrawWindow
        {
            get { return _drawWindow; }
            set { _drawWindow = value; }
        }

        abstract public void ButtonClicked(object sender, MouseEventArgs e);
        abstract public void ButtonPressed(object sender, MouseEventArgs e);
        abstract public void ButtonReleased(object sender, MouseEventArgs e);
        abstract public void ButtonDragged(object sender, MouseEventArgs e);
        abstract public void ButtonDoubleClicked(object sender, MouseEventArgs e);
    }
}
