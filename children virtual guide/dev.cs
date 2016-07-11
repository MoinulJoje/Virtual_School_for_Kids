using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace children_virtual_guide
{
    public partial class dev : Form
    {
        public dev()
        {
            InitializeComponent();
        }

        private void dev_Load(object sender, EventArgs e)
        {
            label2.Text = "Kazi Moinul Hossain.";
            label5.Text = "Institute of Information Technology, Jahangirnagar University.";
            label8.Text = "Syed Abdullah MAaz.";
            label9.Text = "Institute of Information Technology, Jahangirnagar University.";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
