using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp.State
{
    class ControllerChoiceForm : ControllerState
    {
        public ControllerChoiceForm(ControllerState back, ControllerState next, ControllerState next2, Form1 drawWindow)
            :base(back, next, next2, drawWindow)
        {
        }

        public override void ButtonClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _drawWindow.Next = this.Next;
            _drawWindow.isFormSelected = true;
        }

        public override void ButtonPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _drawWindow.setPointA(e.X, e.Y);
            _drawWindow.Next = (_drawWindow.isFormSelected) ? this.Next2 : this.Next;
        }

        public override void ButtonReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        public override void ButtonDragged(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        public override void ButtonDoubleClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }
    }
}
