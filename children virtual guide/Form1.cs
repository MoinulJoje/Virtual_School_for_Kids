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
    public partial class Form1 : Form
    {
        Thread appThread;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
            appThread = new Thread(LaunchAdminApplication);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
            
        }
        private void LaunchAdminApplication()
        {
            Application.Run(new welcomeForm2());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
