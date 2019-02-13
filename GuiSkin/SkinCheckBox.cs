using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSkinLib
{
    public class SkinCheckBox : Button
    {
        object m_lock = new object();
        // To store the location of previous mouse left click in the form
        // so that we can use it to calculate the new form location during dragging
        private Point prevLeftClick;

        // To determine if it is the first time entry for every dragging of the form
        private bool isFirst = true;

        // Acts like a gate to do allow or deny
        private bool toBlock = true;
        private Bitmap[] bmp = new Bitmap[4];
        bool m_isEnter = false;
        bool m_checked = false;
        bool m_checkedState = false;
        bool m_enable = true;
        bool m_disableButtonExists = false;

        public SkinCheckBox()
        {
        
        }

        public void SetSkin(string dir, string buttonName)
        {
            if (File.Exists(dir + buttonName + "_normal.png") == true)
                bmp[0] = new Bitmap(dir + buttonName + "_normal.png");
            else
                throw (new SystemException("File: " + dir + buttonName + "_normal.png" + " does not exists"));

            if (File.Exists(dir + buttonName + "_enter.png") == true)
                bmp[1] = new Bitmap(dir + buttonName + "_enter.png");
            else
                throw (new SystemException("File: " + dir + buttonName + "_enter.png" + " does not exists"));

            if (File.Exists(dir + buttonName + "_press.png") == true)
                bmp[2] = new Bitmap(dir + buttonName + "_press.png");
            else
                throw (new SystemException("File: " + dir + buttonName + "_press.png" + " does not exists"));

            if (File.Exists(dir + buttonName + "_disable.png") == true)
            {
                bmp[3] = new Bitmap(dir + buttonName + "_disable.png");
                m_disableButtonExists = true;
            }
            else
            {
                m_disableButtonExists = false;
            }
                

            this.MouseEnter += SkinCheckBox_MouseEnter;
            this.MouseLeave += SkinCheckBox_MouseLeave;

            GuiBackground.CreateControlRegion(this, bmp[0]);
        }


        public void UpdateSkin(int state, string dir, string buttonName)
        {
            if (state == 1)
            {
                bmp[2] = new Bitmap(dir +  buttonName + ".png");
            }
        }
        private void SkinCheckBox_MouseLeave(object sender, EventArgs e)
        {
            onEnter = false;
        }

        public void Toggle(Action<bool> cb)
        {
            if (m_enable == false) return;

            m_checked = !m_checked;            
            Checked(m_checked);
            cb(m_checked);
        }

        public void Toggle()
        {
            if (m_enable == false) return;

            m_checked = !m_checked;
            Checked(m_checked);
        }

        private void SkinCheckBox_MouseEnter(object sender, EventArgs e)
        {
            onEnter = true;
        }

        public bool onEnter
        {
            set
            {
                if (m_enable == false) return;
                m_isEnter = value;   
                if (m_isEnter == true && m_checked == false)
                {
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
                }
                if (m_isEnter == false && m_checked == false)
                {
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                }
            }
        }
        public void Checked(bool c, Action<bool> cb)
        {
            m_checkedState = c;
            if (m_enable == false) return;
            m_checked = c;
            if (m_checked == true)
            {
                GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[Common.UP]);
                else
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
            }
            cb(m_checked);
             
        }

        public bool GetChecked()
        {
            return m_checked;
        }
      
        public void Checked(bool c)
        {
            m_checkedState = c;
            if (m_enable == false) return;
            m_checked = c;
            if (c)
            {
                GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                else
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
            }           
        }

        public void Toogle()
        {

            if (m_enable == false) return;
            m_checked = !m_checked;
            if (m_checked)
            {
                GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                else
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
            }
        }

        public void Toogle(Action<bool> cb)
        {

            if (m_enable == false) return;
            m_checked = !m_checked;
            if (m_checked)
            {
                GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            }
            else
            {
                if (m_isEnter == false)
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                else
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
            }
            cb(m_checked);
        }

        public void Normal()
        {
            if (m_enable == true)
                GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
        }

        public bool IsEnable()
        {
            return m_enable;
        }
        public void Enable(bool b)
        {
            if (m_disableButtonExists == false)
                return;
            m_enable = b;
            if (b == false)
            {
                GuiBackground.CreateControlRegion(this, bmp[Common.DISABLE]);
            }
            else
            {
                if (m_checked == false && m_checkedState == true)
                    m_checked = m_checkedState;

                if (m_isEnter == false && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                if (m_isEnter == true && m_checked == false)
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
                if (m_checked == true)
                    GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            }           
        }
    }
}
