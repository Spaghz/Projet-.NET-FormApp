using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.State
{
    public class ControllerDraw : ControllerState
    {
        public ControllerDraw(ControllerState back, ControllerState next, ControllerState next2, Form1 drawWindow)
            : base(back, next, next2, drawWindow)
        {
        }

        public override void ButtonClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        public override void ButtonPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        public override void ButtonReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_drawWindow.isFormPolygon)
            {
                _drawWindow.Next = this.Back;
                _drawWindow.setPointA(e.X, e.Y);
            }
            else
            {
                _drawWindow.addToList();
                _drawWindow.Next = this.Next;
            }
        }

        public override void ButtonDragged(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _drawWindow.setPointB(e.X, e.Y);
            _drawWindow.drawForm();
        }

        public override void ButtonDoubleClicked(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _drawWindow.addToList();
            _drawWindow.Next = this.Next;
        }
    }
}
