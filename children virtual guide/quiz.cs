using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace children_virtual_guide
{
    public partial class quiz : Form
    {
        double rW = 0;
        double rH = 0;

        int fH = 0;
        int fW = 0;
        Thread appThread;
        public quiz()
        {
            InitializeComponent();
            this.Resize += quiz_Resize;
        }
        private void quiz_Resize(object sender, EventArgs e)
        {
            rResize(this, true); //Call the routine
        }
        private void wxitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LaunchAdminApplication10()
        {
            Application.Run(new welcomeForm2());
        }
        private void LaunchAdminApplication11()
        {
            Application.Run(new color_xm());
        }
        private void LaunchAdminApplication12()
        {
            Application.Run(new bng_quiz());
        }
        private void LaunchAdminApplication13()
        {
            Application.Run(new eng_quiz());
        }
        private void LaunchAdminApplication14()
        {
            Application.Run(new math_quiz());
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication10);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication11);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication12);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication13);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication14);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void quiz_Load(object sender, EventArgs e)
        {
            rW = this.Width;
            rH = this.Height;

            fW = this.Width;
            fH = this.Height;


            // Loop through the controls inside the  form i.e. Tabcontrol Container
            foreach (Control c in this.Controls)
            {
                c.Tag = c.Name + "/" + c.Left + "/" + c.Top + "/" + c.Width + "/" + c.Height + "/" + (int)c.Font.Size;

                // c.Anchor = (AnchorStyles.Right |  AnchorStyles.Left ); 

                if (c.GetType() == typeof(TabControl))
                {

                    foreach (Control f in c.Controls)
                    {

                        foreach (Control j in f.Controls) //tabpage
                        {
                            j.Tag = j.Name + "/" + j.Left + "/" + j.Top + "/" + j.Width + "/" + j.Height + "/" + (int)j.Font.Size;
                        }
                    }
                }
            }

        }
        private void rResize(Control t, bool hasTabs) // Routine to Auto resize the control
        {
            // option 1:
            /* if (this.Width < fW)
            {
                this.Width = (int)fW;
                return;
            }
            if (this.Height < fH)
            {
                this.Height = (int)fH;
                return;
            } */

            // Option 2:    
            // this will return to normal default size when 1 of the conditions is met

            string[] s = null;

            if (this.Width < fW || this.Height < fH)
            {
                this.Width = (int)fW;
                this.Height = (int)fH;
                return;
            }

            foreach (Control c in t.Controls)
            {
                // Option 1:
                double rRW = (t.Width > rW ? t.Width / (rW) : rW / t.Width);
                double rRH = (t.Height > rH ? t.Height / (rH) : rH / t.Height);

                // Option 2:
                //  double rRW = t.Width / rW;
                //  double rRH = t.Height / rH;

                s = c.Tag.ToString().Split('/');
                if (c.Name == s[0].ToString())
                {

                    //Use integer casting
                    c.Width = (int)(Convert.ToInt32(s[3]) * rRW);
                    c.Height = (int)(Convert.ToInt32(s[4]) * rRH);
                    c.Left = (int)(Convert.ToInt32(s[1]) * rRW);
                    c.Top = (int)(Convert.ToInt32(s[2]) * rRH);
                    c.Font = new Font(this.Font.FontFamily, (float)(Convert.ToInt32(s[5]) * rRH));
                }
                if (hasTabs)
                {
                    if (c.GetType() == typeof(TabControl))
                    {

                        foreach (Control f in c.Controls)
                        {
                            foreach (Control j in f.Controls) //tabpage
                            {
                                s = j.Tag.ToString().Split('/');

                                if (j.Name == s[0].ToString())
                                {

                                    j.Width = (int)(Convert.ToInt32(s[3]) * rRW);
                                    j.Height = (int)(Convert.ToInt32(s[4]) * rRH);
                                    j.Left = (int)(Convert.ToInt32(s[1]) * rRW);
                                    j.Top = (int)(Convert.ToInt32(s[2]) * rRH);
                                    j.Font = new Font(this.Font.FontFamily, (float)(Convert.ToInt32(s[5]) * rRH));
                                }
                            }
                        }
                    }
                }

            }
        }

        private void developersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dev d = new dev();
            d.ShowDialog();
        }
    }
}
