using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSkinLib.Common;

namespace GSkinLib
{
    public class SkinButton : ButtonEx
    {
        bool m_enable = true;
        Bitmap[] bmp = new Bitmap[4];
        bool m_enableButtonExists = false;
        ACTIONS m_state;
        bool m_forePress = false;

        public void SetSkin(string dir, string name)
        {
            if (File.Exists(dir + name + "_normal.png"))
            {
                bmp[0] = new Bitmap(dir + name + "_normal.png");
            }
            else
            {
                throw (new SystemException("File: " + dir + name + "_normal.png" + " does not exists"));
            }

            if (File.Exists(dir + name + "_enter.png"))
            {
                bmp[1] = new Bitmap(dir + name + "_enter.png");
            }
            else
            {                
               throw (new SystemException("File: " + dir + name + "_enter.png" + " does not exists"));             
            }

            if (File.Exists(dir + name + "_press.png"))
            {
                bmp[2] = new Bitmap(dir + name + "_press.png");
            }
            else
            {
                throw (new SystemException("File: " + dir + name + "_press.png" + " does not exists"));
            }

            if (File.Exists(dir + name + "_disable.png"))
            {
                bmp[3] = new Bitmap(dir + name + "_disable.png");
                m_enableButtonExists = true;
            }
            else
            {
                m_enableButtonExists = false;
            }


            GuiBackground.CreateControlRegion(this, bmp[0]);
            m_state = ACTIONS.LEAVE; 

            this.MouseDown += SkinButton_MouseDown;
            this.MouseEnter += SkinButton_MouseEnter;
            this.MouseLeave += SkinButton_MouseLeave;
            this.MouseUp += SkinButton_MouseUp;

        }

        private void SkinButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_enable == false) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.UP]);
            m_state = ACTIONS.UP;
            if (pMouseAction != null)
            {
                pMouseAction(ACTIONS.UP);
            }
        }
        public delegate void MouseAction(ACTIONS action);

        MouseAction pMouseAction = null;
        public void AddAction(MouseAction p)
        {
            pMouseAction = p;
        }
        private void SkinButton_MouseLeave(object sender, EventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
            m_state = ACTIONS.LEAVE;
        }

        private void SkinButton_MouseEnter(object sender, EventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
            m_state = ACTIONS.ENTER;
        }

        private void SkinButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_enable == false) return;
            if (m_forePress == true) return;
            GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            m_state = ACTIONS.DOWN;
            if (pMouseAction != null)
            {
                pMouseAction(ACTIONS.DOWN);
            }
        }      
        
        public bool IsEnable()
        {
            return m_enable;
        } 
        public void Enable(bool b)
        {
            if (m_enableButtonExists == false) return;
            m_enable = b;
            if (b == false)
            {
                GuiBackground.CreateControlRegion(this, bmp[DISABLE]);
                m_state = ACTIONS.DISABLE;
            }
            else
            {
                if (m_state == ACTIONS.LEAVE)
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                if (m_state == ACTIONS.ENTER)
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);



            }
        }

        public void PressState()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
            m_state = ACTIONS.DOWN;
        }

        public void EnterState()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
            m_state = ACTIONS.ENTER;
        }
        public void NormalState()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
            m_state = ACTIONS.LEAVE;
        }

        public void UpdateSate()
        {
            switch (m_state)
            {
                case ACTIONS.LEAVE:
                    GuiBackground.CreateControlRegion(this, bmp[Common.LEAVE]);
                break;
                case ACTIONS.ENTER:
                    GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);
                break;
                case ACTIONS.DOWN:
                    GuiBackground.CreateControlRegion(this, bmp[Common.DOWN]);
                break;
                case ACTIONS.DISABLE:
                    GuiBackground.CreateControlRegion(this, bmp[Common.DISABLE]);
                break;

            }
        }

        public void ForcePress(bool value)
        {
            m_forePress = value;
            if (value == true) PressState();
            else NormalState();
            
        }
        public void SimulateEnter()
        {
            GuiBackground.CreateControlRegion(this, bmp[Common.ENTER]);

        }
    }
}
