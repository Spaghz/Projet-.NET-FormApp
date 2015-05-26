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
using FormApp.Core.Shapes.COR;
using FormApp.Core.DAO;

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

        private List<Shape>                 shapes;
        private Shape                       shapeCurrent;
        
        private Color                       backgroundColor;
        private Color                       strokeColor;

        private Shape                       pulledShape;
       
       
        public Form1()
        {
            backgroundColor = new Color(Color.WHITE);
            strokeColor = new Color(Color.BLACK);
            int[] rgb = strokeColor.intToRgb();
            pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]), 1);

            shapes = new List<Shape>();

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

            shapeCurrent.Create(x1, y1, strokeColor, backgroundColor);
        }

        public void setPointB(int x2, int y2)
        {
            this.x2 = x2;
            this.y2 = y2;

            shapeCurrent.SetParamaters(this.x1, this.y1, this.x2, this.y2);
        }

        public void drawForm()
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(System.Drawing.Color.White);

            foreach (Shape sIn in shapes)
                sIn.Draw(g, pen);

            shapeCurrent.Draw(g, pen);
        }

         public void addToList()
         {
             if (x2 != 0 && y2 != 0)
             { 
                Console.WriteLine(shapeCurrent.ToString());
                shapes.Add(shapeCurrent);
                shapeCurrent = shapeCurrent.InitializeForm();
             }
         }

        public List<Shape> Shapes
        {
            get { return shapes; }
        }

        public System.Drawing.Graphics G
        {
            get { return g; }
        }

        public System.Drawing.Pen Pen
        {
            get { return pen; }
        }

        public System.Windows.Forms.Panel Panel1
        {
            get { return this.panel1; }
            set { this.panel1 = value; }
        }

         /***********************************
         *  MouseEventArgs
         ***********************************/
        private void pictureBox1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonPressed(sender, e);
        }

        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonReleased(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonDragged(sender, e);
        }

        private void pictureBox1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonDoubleClicked(sender, e);
        }


        /***********************************
         *  Define formCurrent
         ***********************************/
        private void btnRectangle_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            shapeCurrent = new Rectangle("rectangle");
            isFormPolygon = false; 
        }

        private void btnCircle_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            shapeCurrent = new Circle("circle");
            isFormPolygon = false;
        }

        private void btnSegment_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            shapeCurrent = new Segment("segment");
            isFormPolygon = false; 
        }

        private void btnPolygon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            shapeCurrent = new Polygon("polygon");
            isFormPolygon = true; 
        }

        private void btnTriangle_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            controllerCurrent.ButtonClicked(sender, e);
            shapeCurrent = new Triangle("triangle");
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

        private void btnGroup_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            this.panel1.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach(Shape s in Shapes)
                {
                    WebServiceManager.Instance.Save(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Length == 0)
                    throw new Exception("Please specifiy a number in the textbox next to pull button.");

                Convert.ToInt32(this.textBox1.Text);

                int shapeId = Convert.ToInt32(this.textBox1.Text);
                pulledShape = WebServiceManager.Instance.Load(shapeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
