using FormApp.Core.Shapes;
using FormApp.Core.Utils;
using FormApp.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private ControllerChoiceForm        controllerChoiceForm;
        private ControllerSetOrigine        controllerSetOrigine;
        private ControllerDraw              controllerDraw;
        private ControllerState             controllerCurrent;

        private int                         x1, x2, y1, y2;
        public bool                        isFormSelected;
        public bool                        isFormPolygon;

        private System.Drawing.Graphics     g;
        private System.Drawing.Pen          pen;

        private List<Shape>                  forms;
        private Shape                        formCurrent;
        
        private Color                       backgroundColor;
        private Color                       strokeColor;
       
       
        public Form1()
        {
            backgroundColor = new Color(Color.BLACK);
            int[] rgb = backgroundColor.intToRgb();
            pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]), 1);

            forms = new List<Shape>();

            InitializeStates();
            InitializeComponent();
        }

        private void InitializeStates()
        {
            controllerChoiceForm        = new ControllerChoiceForm(null, null, null, this);
            controllerSetOrigine        = new ControllerSetOrigine(null, null, null, this);
            controllerDraw              = new ControllerDraw(null, null, null, this);

            controllerChoiceForm.Next   = controllerSetOrigine;
            controllerChoiceForm.Next2  = controllerDraw;
            controllerSetOrigine.Next   = controllerDraw;
            controllerDraw.Next         = controllerChoiceForm;
            controllerDraw.Back         = controllerDraw;

            controllerCurrent           = controllerChoiceForm;
        }

        public ControllerState Next
        {
            set { controllerCurrent = value; }
        }

        public void setPointA(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;

            formCurrent.Create(x1, y1, backgroundColor, backgroundColor);
        }

        public void setPointB(int x2, int y2)
        {
            this.x2 = x2;
            this.y2 = y2;

            formCurrent.SetParamaters(this.x1, this.y1, this.x2, this.y2);
        }

        public void drawForm()
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(System.Drawing.Color.White);

            foreach (Shape fIn in forms)
                fIn.Draw(g, pen);

            formCurrent.Draw(g, pen);
        }

         public void addToList()
         {
             forms.Add(formCurrent);
             formCurrent = formCurrent.InitializeForm();
         }


         /***********************************
         *  MouseEventArgs
         ***********************************/
        private void pictureBox1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //System.Console.Write("MouseClick on " + controllerCurrent.GetType().ToString() + "\n");
            //controllerCurrent.LeftButtonClicked(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //System.Console.Write("MouseDown on " + controllerCurrent.GetType().ToString() + "\n");
            controllerCurrent.ButtonPressed(sender, e);
        }

        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //System.Console.Write("MouseUp on " + controllerCurrent.GetType().ToString() + "\n");
            controllerCurrent.ButtonReleased(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //System.Console.Write("MouseMove on " + controllerCurrent.GetType().ToString() + "\n");
            controllerCurrent.ButtonDragged(sender, e);
        }

        private void pictureBox1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //System.Console.Write("MouseDoubleClick on " + controllerCurrent.GetType().ToString() + "\n");
            controllerCurrent.ButtonDoubleClicked(sender, e);
        }


        /***********************************
         *  Define formCurrent
         ***********************************/
        private void btnRectangle_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            formCurrent = new Rectangle("rectangle");
            isFormPolygon = false; 
        }

        private void btnCircle_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            formCurrent = new Circle("cercle");
            isFormPolygon = false;
        }

        private void btnSegment_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            formCurrent = new Segment("segment");
            isFormPolygon = false; 
        }

        private void btnPolygon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            formCurrent = new Polygon("polygon");
            isFormPolygon = true; 
        }

        private void btnTriangle_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            formCurrent = new Triangle("triangle");
            isFormPolygon = true; 
        }

        /***********************************
         *  Define colorCurrent
         ***********************************/
        private void btnColorDialog_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            backgroundColor = new Color(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            this.btnColorDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorDialog.Color.R)))), ((int)(((byte)(colorDialog.Color.G)))), ((int)(((byte)(colorDialog.Color.B)))));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            strokeColor = new Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            this.btnStrokeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorDialog1.Color.R)))), ((int)(((byte)(colorDialog1.Color.G)))), ((int)(((byte)(colorDialog1.Color.B)))));
        }
        
    }
}
