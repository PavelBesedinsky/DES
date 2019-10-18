namespace DESApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.encodeBtn = new System.Windows.Forms.ToolStripButton();
            this.decodeBtn = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbKey = new System.Windows.Forms.Label();
            this.tBKey = new System.Windows.Forms.TextBox();
            this.rTBInput = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rTBOutput = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeBtn,
            this.decodeBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(810, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip";
            // 
            // encodeBtn
            // 
            this.encodeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.encodeBtn.Image = ((System.Drawing.Image)(resources.GetObject("encodeBtn.Image")));
            this.encodeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(23, 22);
            this.encodeBtn.Text = "Encode";
            this.encodeBtn.Click += new System.EventHandler(this.encodeBtn_Click);
            // 
            // decodeBtn
            // 
            this.decodeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.decodeBtn.Image = ((System.Drawing.Image)(resources.GetObject("decodeBtn.Image")));
            this.decodeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(23, 22);
            this.decodeBtn.Text = "Decode";
            this.decodeBtn.Click += new System.EventHandler(this.decodeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbKey);
            this.panel1.Controls.Add(this.tBKey);
            this.panel1.Controls.Add(this.rTBInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 245);
            this.panel1.TabIndex = 1;
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(12, 209);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(25, 13);
            this.lbKey.TabIndex = 2;
            this.lbKey.Text = "Key";
            // 
            // tBKey
            // 
            this.tBKey.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBKey.Location = new System.Drawing.Point(0, 225);
            this.tBKey.Name = "tBKey";
            this.tBKey.Size = new System.Drawing.Size(810, 20);
            this.tBKey.TabIndex = 1;
            // 
            // rTBInput
            // 
            this.rTBInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.rTBInput.Location = new System.Drawing.Point(0, 0);
            this.rTBInput.Name = "rTBInput";
            this.rTBInput.Size = new System.Drawing.Size(810, 176);
            this.rTBInput.TabIndex = 0;
            this.rTBInput.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rTBOutput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 276);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 297);
            this.panel2.TabIndex = 2;
            // 
            // rTBOutput
            // 
            this.rTBOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBOutput.Location = new System.Drawing.Point(0, 0);
            this.rTBOutput.Name = "rTBOutput";
            this.rTBOutput.Size = new System.Drawing.Size(810, 297);
            this.rTBOutput.TabIndex = 0;
            this.rTBOutput.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "DES";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.TextBox tBKey;
        private System.Windows.Forms.RichTextBox rTBInput;
        private System.Windows.Forms.RichTextBox rTBOutput;
        private System.Windows.Forms.ToolStripButton encodeBtn;
        private System.Windows.Forms.ToolStripButton decodeBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

