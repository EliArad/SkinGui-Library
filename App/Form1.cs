using GSkinLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGuiSkin
{
    public partial class Form1 : Form
    {
    

        public Form1()
        {
            InitializeComponent();
             

            string dir = "Images\\";
            Bitmap back = new Bitmap(dir + "pedestal_back.png");
            GuiBackground.CreateControlRegion(this, back);
            
            // Button skin
            button1.SetSkin(dir, "stow");

            // Check boxskin
            chkbox.SetSkin(dir, "check1");

            skinCheckBox1.SetSkin(dir, "radio_6");
            skinCheckBox2.SetSkin(dir, "radio_6");
            skinCheckBox3.SetSkin(dir, "radio_6");

            chkButton.SetSkin(dir, "camera_btn", "Off");
            this.MouseDown += Form_MouseDown;

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void chkbox_Click(object sender, EventArgs e)
        {

            // how to check the check state in case you need
            //if (chkbox.GetChecked() == false)
            //  return;

            chkbox.Toggle((c) =>
            {
                if (c == true)
                {

                }
            });
        }

        private void skinCheckBox1_Click(object sender, EventArgs e)
        {
            skinCheckBox1.Checked(true);
            skinCheckBox2.Checked(false);
            skinCheckBox3.Checked(false);
        }

        private void skinCheckBox2_Click(object sender, EventArgs e)
        {
            skinCheckBox2.Checked(true);
            skinCheckBox1.Checked(false);
            skinCheckBox3.Checked(false);
         
        }

        private void skinCheckBox3_Click(object sender, EventArgs e)
        {
            skinCheckBox3.Checked(true);
            skinCheckBox1.Checked(false);
            skinCheckBox2.Checked(false);
        }

        private void chkButton_Click(object sender, EventArgs e)
        {
            if (chkButton.GetChecked() == false)
            {
                chkButton.Checked(true);
                chkButton.Text = "On";
            }
            else
            {
                chkButton.Checked(false);
                chkButton.Text = "Off";
            }
        }
    }
}
