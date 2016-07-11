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
    public partial class bng_quiz : Form
    {
        double rW = 0;
        double rH = 0;

        int fH = 0;
        int fW = 0;
        int i = 0;
        int j = 0;
        Thread appThread;
        public bng_quiz()
        {
            InitializeComponent();
            this.Resize += bng_quiz_Resize;
        }
        private void bng_quiz_Resize(object sender, EventArgs e)
        {
            rResize(this, true); //Call the routine
        }
        private void bng_quiz_Load(object sender, EventArgs e)
        {
            lb1();
            lb2();
            label2.Text = i.ToString();
            listBox1.SetSelected(0, true);
            listBox2.SetSelected(0, true);
            

            button5.Visible = false;
            button6.Visible = false;
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
        private void down()
        {
            if (j == 5)
            {
                axShockwaveFlash1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                //button5.Visible = false;
                button6.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
                label6.Text = "তোমার ফলাফলঃ " + i;
                if (i == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"0.wav");
                    player.Play();
                }
                if (i == 1)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"1.wav");
                    player.Play();
                }
                if (i == 2)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"2.wav");
                    player.Play();
                }
                if (i == 3)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"3.wav");
                    player.Play();
                }
                if (i == 4)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"4.wav");
                    player.Play();
                }
                if (i == 5)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"5.wav");
                    player.Play();
                }
            }

            if (listBox1.SelectedIndex == -1)
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
            else
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex++;
                    label5.Text = listBox1.SelectedIndex.ToString();
                    button5.Visible = true;
                }
            }
        }

        private void lb1()
        {
            Random random = new Random();
            int rand = random.Next(0, listBox1.Items.Count);
            //listBox1.SetSelected(0, true); 
            ListBox.ObjectCollection list = listBox1.Items;
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = (string)list[k];
                list[k] = list[n];
                list[n] = value;
            }

        }
        private void lb2()
        {
            Random random = new Random();
            int rand = random.Next(0, listBox2.Items.Count);
            //listBox2.SetSelected(0, true);
            ListBox.ObjectCollection list = listBox2.Items;
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = (string)list[k];
                list[k] = list[n];
                list[n] = value;
            }

        }
        private void lb4()
        {
            Random random = new Random();
            int rand = random.Next(0, listBox4.Items.Count);
            //listBox1.SetSelected(0, true); 
            ListBox.ObjectCollection list = listBox4.Items;
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = (string)list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = listBox1.SelectedItem.ToString();
            axShockwaveFlash1.Movie = Application.StartupPath + @a;
            ListBox l = sender as ListBox;

            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                listBox4.SelectedIndex = l.SelectedIndex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = button1.Text;
            string b = listBox2.SelectedItem.ToString();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"quizes/correct.wav");
            string c = listBox4.SelectedItem.ToString();
            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@c);

            if (a == b)
            {
                player.Play();
                MessageBox.Show("Correct Answer!!!");

                i++;
                j++;
                label2.Text = i.ToString();
                label4.Text = j.ToString();
                down();
            }
            else
            {
                player1.Play();
                MessageBox.Show("Wrong Answer!!!" + "Correct Answer is " + b);
                label2.Text = i.ToString();
                j++;
                label4.Text = j.ToString();
                down();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = button2.Text;
            string b = listBox2.SelectedItem.ToString();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"quizes/correct.wav");
            string c = listBox4.SelectedItem.ToString();
            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@c);

            if (a == b)
            {
                player.Play();
                MessageBox.Show("Correct Answer!!!");

                i++;
                j++;
                label2.Text = i.ToString();
                label4.Text = j.ToString();
                down();
            }
            else
            {
                player1.Play();
                MessageBox.Show("Wrong Answer!!!" + "Correct Answer is " + b);
                label2.Text = i.ToString();
                j++;
                label4.Text = j.ToString();
                down();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = button3.Text;
            string b = listBox2.SelectedItem.ToString();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"quizes/correct.wav");
            string c = listBox4.SelectedItem.ToString();
            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@c);

            if (a == b)
            {
                player.Play();
                MessageBox.Show("Correct Answer!!!");

                i++;
                j++;
                label2.Text = i.ToString();
                label4.Text = j.ToString();
                down();
            }
            else
            {
                player1.Play();
                MessageBox.Show("Wrong Answer!!!" + "Correct Answer is " + b);
                label2.Text = i.ToString();
                j++;
                label4.Text = j.ToString();
                down();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = button4.Text;
            string b = listBox2.SelectedItem.ToString();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"quizes/correct.wav");
            string c = listBox4.SelectedItem.ToString();
            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@c);

            if (a == b)
            {
                player.Play();
                MessageBox.Show("Correct Answer!!!");

                i++;
                j++;
                label2.Text = i.ToString();
                label4.Text = j.ToString();
                down();
            }
            else
            {
                player1.Play();
                MessageBox.Show("Wrong Answer!!!" + "Correct Answer is " + b);
                label2.Text = i.ToString();
                j++;
                label4.Text = j.ToString();
                down();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
            }
            else
            {
                if (listBox1.SelectedIndex != 0)
                {
                    listBox1.SelectedIndex--;
                    axShockwaveFlash1.Visible = true;
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    label3.Visible = true;
                    label6.Visible = false;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"done.wav");
                    player.Play();
                    label3.Text = "তুমি এই প্রশ্নের উত্তর দিয়ে ফেলেছ। উত্তর ছিল:" + listBox2.SelectedItem.ToString();
                    label5.Text = listBox1.SelectedIndex.ToString();
                    button6.Visible = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (j == 5)
            {
                //axShockwaveFlash1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                //button5.Visible = false;
                //button6.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                if (listBox1.SelectedIndex == 4)
                {
                    axShockwaveFlash1.Visible = false;
                    button6.Visible = false;
                    label3.Visible = false;
                    label6.Visible = true;
                    label6.Text = "তোমার ফলাফলঃ " + i;


                }
            }
            if (listBox1.SelectedIndex == -1)
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
            else
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    listBox1.SelectedIndex++;
                    label5.Text = listBox1.SelectedIndex.ToString();
                    if (j == listBox1.SelectedIndex)
                    {
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        label3.Visible = false;
                        button6.Visible = false;
                    }
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LaunchAdminApplication11()
        {
            Application.Run(new quiz());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            appThread = new Thread(LaunchAdminApplication11);
            appThread.SetApartmentState(ApartmentState.STA);
            appThread.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {

        }
    }
}
