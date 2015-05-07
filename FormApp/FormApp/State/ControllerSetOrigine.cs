using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.State
{
    public class ControllerSetOrigine : ControllerState
    {
        public ControllerSetOrigine(ControllerState back, ControllerState next, ControllerState next2, Form1 drawWindow)
            : base(back, next, next2, drawWindow)
        {
        }

        public override void ButtonClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        public override void ButtonPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _drawWindow.setPointA(e.X, e.Y);
            _drawWindow.Next = this.Next;
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
