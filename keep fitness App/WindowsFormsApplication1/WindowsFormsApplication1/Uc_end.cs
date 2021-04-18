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
    public partial class Uc_end : UserControl
    {
        string pic = " ";
        VideoCaptureDevice frame;
        FilterInfoCollection devices;
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        string imagelocation = " ";
        public Uc_end()
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
                pictureBox1.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Uc_end_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //start_cam();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try { frame.Stop(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           /*  folderBrowserDialog1.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName.ToString();
                    pictureBox1.ImageLocation = imagelocation;
                    pic = imagelocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading this image");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void update()
        {
            MessageBox.Show(pic);
            connection.Open();
            cmd=new SqlCommand("update user_account set  After_pic ='"+pic +"' where id='"+150+"'",connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (pic.Length > 5)
            {
                update();
                this.Controls.Clear();
                before_and_after bf = new before_and_after();
                this.Controls.Add(bf);
                bf.BringToFront();
            }
            else
            {
                MessageBox.Show("plz insert Your After Photo");
            }
        }
    }
}
