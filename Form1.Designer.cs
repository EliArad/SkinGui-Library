using GSkinLib;

namespace TestGuiSkin
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
            this.button1 = new GSkinLib.SkinButton();
            this.chkbox = new GSkinLib.SkinCheckBox();
            this.skinCheckBox1 = new GSkinLib.SkinCheckBox();
            this.skinCheckBox2 = new GSkinLib.SkinCheckBox();
            this.skinCheckBox3 = new GSkinLib.SkinCheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.Location = new System.Drawing.Point(32, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkbox
            // 
            this.chkbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.chkbox.Location = new System.Drawing.Point(60, 172);
            this.chkbox.Name = "chkbox";
            this.chkbox.Size = new System.Drawing.Size(33, 33);
            this.chkbox.TabIndex = 1;
            this.chkbox.UseVisualStyleBackColor = false;
            this.chkbox.Click += new System.EventHandler(this.chkbox_Click);
            // 
            // skinCheckBox1
            // 
            this.skinCheckBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.skinCheckBox1.Location = new System.Drawing.Point(60, 233);
            this.skinCheckBox1.Name = "skinCheckBox1";
            this.skinCheckBox1.Size = new System.Drawing.Size(33, 33);
            this.skinCheckBox1.TabIndex = 2;
            this.skinCheckBox1.UseVisualStyleBackColor = false;
            this.skinCheckBox1.Click += new System.EventHandler(this.skinCheckBox1_Click);
            // 
            // skinCheckBox2
            // 
            this.skinCheckBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.skinCheckBox2.Location = new System.Drawing.Point(60, 272);
            this.skinCheckBox2.Name = "skinCheckBox2";
            this.skinCheckBox2.Size = new System.Drawing.Size(33, 33);
            this.skinCheckBox2.TabIndex = 3;
            this.skinCheckBox2.UseVisualStyleBackColor = false;
            this.skinCheckBox2.Click += new System.EventHandler(this.skinCheckBox2_Click);
            // 
            // skinCheckBox3
            // 
            this.skinCheckBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.skinCheckBox3.Location = new System.Drawing.Point(60, 316);
            this.skinCheckBox3.Name = "skinCheckBox3";
            this.skinCheckBox3.Size = new System.Drawing.Size(33, 33);
            this.skinCheckBox3.TabIndex = 4;
            this.skinCheckBox3.UseVisualStyleBackColor = false;
            this.skinCheckBox3.Click += new System.EventHandler(this.skinCheckBox3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 401);
            this.Controls.Add(this.skinCheckBox3);
            this.Controls.Add(this.skinCheckBox2);
            this.Controls.Add(this.skinCheckBox1);
            this.Controls.Add(this.chkbox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinButton button1;
        private SkinCheckBox chkbox;
        private SkinCheckBox skinCheckBox1;
        private SkinCheckBox skinCheckBox2;
        private SkinCheckBox skinCheckBox3;
    }
}

