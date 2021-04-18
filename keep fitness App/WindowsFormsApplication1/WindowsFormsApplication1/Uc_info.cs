using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.Sql;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Uc_info : UserControl
    {
        
        string pic=" ";
        VideoCaptureDevice frame;
        FilterInfoCollection devices;
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd = new SqlCommand();
        string imagelocation = " ";
        double constant1, constant2;
        int age;
        Home home = new Home();
        double weight, target;

        public Uc_info()
        {
            InitializeComponent();
        }
        void start_cam()
        {
            devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            frame = new VideoCaptureDevice(devices[0].MonikerString);
            frame.NewFrame += new AForge.Video.NewFrameEventHandler(Newframe_event);
            frame.Start();
            
        }

        string output;
        void Newframe_event(object send, NewFrameEventArgs e)
        {
            try
            {
                pictureBox2.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Uc_info_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName.ToString();
                    pictureBox2.ImageLocation = imagelocation;
                    pic = imagelocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading this image");
            }
            button3.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            start_cam();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           //folderBrowserDialog1.ShowDialog();
           // textBox5.Text = folderBrowserDialog1.SelectedPath;
           //  output = folderBrowserDialog1.SelectedPath;
           //pic = textBox5.Text;
           // button3.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          /*  if (textBox5.TextLength > 0)
            {
                start_cam();
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frame.Stop();
           /* folderBrowserDialog1.ShowDialog();
            output = folderBrowserDialog1.SelectedPath;
            pic = output;
            MessageBox.Show(output);
            if (output.Length>1)
            {
                
                try
                {
                    
                    if (pictureBox2.Image != null)
                    {
                        frame.Stop();
                        pictureBox2.Image.Save(output + "\\Image.png");

                    }
                   
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                
            }*/
        }

        private void Uc_info_ControlRemoved(object sender, ControlEventArgs e)
        {
           
        }
        private void system()
        {
           

            if (Program.gend == "Female")
            {
                if (age >= 3 && age <= 10)
                {
                    constant1 = 22.5;
                    constant2 = 499;

                }
                else if (age > 10 && age <= 17)
                {

                    constant1 = 12.5;
                    constant2 = 746;
                }
                else if (age > 17 && age <= 29)
                {

                    constant1 = 14.7;
                    constant2 = 496;
                }
                else if (age > 29 && age <= 60)
                {

                    constant1 = 8.7;
                    constant2 = 829;
                }
                else if (age > 60)
                {
                    constant1 = 10.5;
                    constant2 = 596;
                }


            }
            else if (Program.gend == "Male")
            {


                if (age >= 3 && age <= 10)
                {
                    constant1 = 22.7;
                    constant2 = 495;

                }
                else if (age > 10 && age <= 17)
                {

                    constant1 = 17.5;
                    constant2 = 651;
                }
                else if (age > 17 && age <= 29)
                {

                    constant1 = 15.3;
                    constant2 = 679;
                }
                else if (age > 29 && age <= 60)
                {

                    constant1 = 11.6;
                    constant2 = 879;
                }
                else if (age > 60)
                {
                    constant1 = 13.5;
                    constant2 = 487;
                }

            }
            double normal = (constant1 * weight) + constant2;
            double calory_per_day = normal - 250;
            int NumOfDays =(int) (weight - target) * 7;
            DateTime t = DateTime.Now;
            string qry = "update user_account set cal_per_day='"+calory_per_day+"', end_date='"+t.AddDays(NumOfDays) +"'where user_name= '"+Program.usrname+"'" ;
            SqlCommand cmd = new SqlCommand(qry, connection);
            cmd.ExecuteNonQuery();
        }
        private void btn_sub_Click(object sender, EventArgs e)
        {
              double dou; 

              if (pic.Length>3&&double.TryParse(textBox2.Text, out dou) == true && double.TryParse(textBox1.Text, out dou) == true && double.TryParse(textBox4.Text, out dou) == true && double.TryParse(textBox3.Text, out dou) == true && textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0 && textBox3.TextLength > 0)
              {
                  age = Convert.ToInt32(textBox1.Text.ToString());
                  weight = Convert.ToDouble(textBox2.Text.ToString());
                  target = Convert.ToDouble(textBox4.Text.ToString());
                  try
                  {
                      connection.Open();
                      MessageBox.Show(pic);
                      string sql = "update  user_account set age ='" + age + "' ,  weight='" + weight + "' , target ='" + target + "' , height ='" + textBox3.Text + "' , country='" + comboBox1.Text + "' ,date ='" + DateTime.Now + "',Before_pic = '" + pic + "' , online='" + 1 + "' ,  status='" + 0 + "' where user_name ='" + Program.usrname + "'";

                      cmd = new SqlCommand(sql, connection);

                      cmd.ExecuteNonQuery();
                      system();

                      this.Controls.Clear();
                      Form1 form;
                      form = (Form1)this.FindForm();
                      form.panel2.Show();
                      form.panel2.BringToFront();
                      home.Location = new Point(175, 0);
                      this.Controls.Add(home);
                      home.BringToFront();
                      home.Visible = true;

                      MessageBox.Show("saved");

                  }
                  catch (Exception ex)
                  {

                      MessageBox.Show(ex.Message);
                  }
                  finally
                  {
                      connection.Close();
                  }
              }
              else
              {
                  MessageBox.Show("plz insert correct values");
              }
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
