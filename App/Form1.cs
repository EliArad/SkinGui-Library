using GSkinLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGuiSkin
{
    public partial class Form1 : Form
    {
        private Point prevLeftClick;
        private bool isFirst = true;
        private bool toBlock = true;

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
            


        }
    
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if dragging of the form has occurred
            if (e.Button == MouseButtons.Left)
            {
                // If this is the first mouse move event for left click dragging of the form,
                // store the current point clicked so that we can use it to calculate the form's
                // new location in subsequent mouse move events due to left click dragging of the form
                if (isFirst == true)
                {
                    // Store previous left click position
                    prevLeftClick = new Point(e.X, e.Y);

                    // Subsequent mouse move events will not be treated as first time, until the
                    // left mouse click is released or other mouse click occur
                    isFirst = false;
                }

                // On subsequent mouse move events with left mouse click down. (During dragging of form)
                else
                {
                    // This flag here is to allow alternate processing for dragging the form because it
                    // causes serious flicking when u allow every such events to change the form's location.
                    // You can try commenting this out to see what i mean
                    if (toBlock == false)
                        this.Location = new Point(this.Location.X + e.X - prevLeftClick.X, this.Location.Y + e.Y - prevLeftClick.Y);

                    // Store new previous left click position
                    prevLeftClick = new Point(e.X, e.Y);

                    // Allow or deny next mouse move dragging event
                    toBlock = !toBlock;
                }
            }

            // This is a new mouse move event so reset flag
            else
                isFirst = true;
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
