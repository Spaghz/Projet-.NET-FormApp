namespace FormApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxForm = new System.Windows.Forms.CheckedListBox();
            this.BtnValidation = new System.Windows.Forms.Button();
            this.btnStrokeColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // checkedListBoxForm
            // 
            this.checkedListBoxForm.CheckOnClick = true;
            this.checkedListBoxForm.FormattingEnabled = true;
            this.checkedListBoxForm.Location = new System.Drawing.Point(12, 25);
            this.checkedListBoxForm.Name = "checkedListBoxForm";
            this.checkedListBoxForm.Size = new System.Drawing.Size(502, 289);
            this.checkedListBoxForm.TabIndex = 0;
            this.checkedListBoxForm.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxForm_SelectedIndexChanged);
            // 
            // BtnValidation
            // 
            this.BtnValidation.Location = new System.Drawing.Point(261, 338);
            this.BtnValidation.Name = "BtnValidation";
            this.BtnValidation.Size = new System.Drawing.Size(75, 23);
            this.BtnValidation.TabIndex = 1;
            this.BtnValidation.Text = "Valider";
            this.BtnValidation.UseVisualStyleBackColor = true;
            this.BtnValidation.Click += new System.EventHandler(this.BtnValidation_Click);
            // 
            // btnStrokeColor
            // 
            this.btnStrokeColor.BackColor = System.Drawing.Color.Black;
            this.btnStrokeColor.Location = new System.Drawing.Point(537, 25);
            this.btnStrokeColor.Name = "btnStrokeColor";
            this.btnStrokeColor.Size = new System.Drawing.Size(64, 64);
            this.btnStrokeColor.TabIndex = 2;
            this.btnStrokeColor.UseVisualStyleBackColor = false;
            this.btnStrokeColor.Click += new System.EventHandler(this.btnStrokeColor_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 373);
            this.Controls.Add(this.btnStrokeColor);
            this.Controls.Add(this.BtnValidation);
            this.Controls.Add(this.checkedListBoxForm);
            this.Location = new System.Drawing.Point(600, 50);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Grouper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxForm;
        private System.Windows.Forms.Button BtnValidation;
        private System.Windows.Forms.Button btnStrokeColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}