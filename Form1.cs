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

            button1.SetSkin(dir, "stow");
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
    }
}
