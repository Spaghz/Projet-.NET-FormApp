using FormApp.Core.Shapes;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class Form2 : Form
    {
        private Color   strokeColor;
        Form1           form1;
        List<Shape>     shapes;

        public Form2()
        {
            InitializeComponent();
            strokeColor = new Color(Color.BLACK);
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
            strokeColor = new Color(Color.BLACK);
            form1 = f;
            InitializeList();
            if (shapes.Count == 0)
                this.BtnValidation.Enabled = false;
        }

        private void btnStrokeColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            strokeColor = new Color(colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
            this.btnStrokeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorDialog1.Color.R)))), ((int)(((byte)(colorDialog1.Color.G)))), ((int)(((byte)(colorDialog1.Color.B)))));
        }

        public void InitializeList()
        {
            shapes = form1.Shapes;
            checkedListBoxForm.Items.Clear();
            foreach (Shape sIn in shapes)
                checkedListBoxForm.Items.Add(sIn.Name.ToString());

        }

        private void BtnValidation_Click(object sender, EventArgs e)
        {
            Group group = new Group("group");
            group.SetColors(strokeColor, strokeColor);
            int index;
            Shape shape;
            for (int i = 0; i <= checkedListBoxForm.CheckedItems.Count - 1; i++)
            {
                index = checkedListBoxForm.CheckedIndices[i];
                shape = shapes.ElementAt(index);
                //shape.SetColors(strokeColor, strokeColor);
                group.AddForm(shape);
            }
            for (int i = checkedListBoxForm.CheckedItems.Count - 1; i >= 0 ; i--)
            {
                index = checkedListBoxForm.CheckedIndices[i];
                form1.Shapes.RemoveAt(index);
            }
            form1.Shapes.Add(group);

            form1.G.Clear(System.Drawing.Color.White);
            foreach (Shape sIn in shapes)
                sIn.Draw(form1.G, form1.Pen);

            InitializeList();
        }

        private void checkedListBoxForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int[] rgb = strokeColor.intToRgb();
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(rgb[0], rgb[1], rgb[2]), 3);

            form1.G.Clear(System.Drawing.Color.White);
            foreach (Shape sIn in shapes)
                sIn.Draw(form1.G, form1.Pen);

            for (int i = 0; i <= checkedListBoxForm.CheckedItems.Count - 1; i++)
            {
                index = checkedListBoxForm.CheckedIndices[i];
                form1.Shapes.ElementAt(index).Draw(form1.G, pen);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Panel1.Enabled = true;
        }
    }
}
