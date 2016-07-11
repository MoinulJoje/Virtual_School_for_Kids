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
    public partial class banglaForm2 : Form
    {
        double rW = 0;
        double rH = 0;

        int fH = 0;
        int fW = 0;
        
        Thread appThread;
        public banglaForm2()
        {
            InitializeComponent();
            this.Resize += banglaForm2_Resize; 
        }

        private void banglaForm2_Resize(object sender, EventArgs e)
        {
            rResize(this, true); //Call the routine
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
        
        private void banglaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }
        private void LaunchAdminApplication()
        {
            Application.Run(new banglaForm2());
        }
        private void LaunchAdminApplication1()
        {
            Application.Run(new english());
        }
        private void LaunchAdminApplication2()
        {
            Application.Run(new Handwriting());
        }
        private void LaunchAdminApplication7()
        {
            Application.Run(new color());
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication1);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void wxitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void writingTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication2);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        
        private void LaunchAdminApplication3()
        {
            Application.Run(new welcomeForm2());
        }
        private void LaunchAdminApplication4()
        {
            Application.Run(new math());
        }
        private void LaunchAdminApplication8()
        {
            Application.Run(new bngcons());
        }
        private void LaunchAdminApplication9()
        {
            Application.Run(new bngvowel());
        }
        private void LaunchAdminApplication10()
        {
            Application.Run(new bngall());
        }
        private void LaunchAdminApplication11()
        {
            Application.Run(new welcomeForm2());
        }
        private void LaunchAdminApplication13()
        {
            Application.Run(new bngkar());
        }
        private void LaunchAdminApplication12()
        {
            Application.Run(new quiz());
        }

        private void mathematicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication4);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication8);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication9);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication10);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication13);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

       
        private void LaunchAdminApplication5()
        {
            Application.Run(new GK());
        }
        private void LaunchAdminApplication6()
        {
            Application.Run(new diction());
        }

        private void gKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication5);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void dictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication6);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void banglaForm2_Load(object sender, EventArgs e)
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

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication7);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            appThread = new Thread(LaunchAdminApplication11);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void quizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication12);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void developersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dev d = new dev();
            d.ShowDialog();
        }
    }
}
