using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class UserControl2 : UserControl
    {
        static string sqll = "Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true";
        string pic, qry;
        bool done = false;
        SqlConnection conn = new SqlConnection(sqll);
        SqlCommand cmd;
        public UserControl2()
        {
            InitializeComponent();
        }
        private void show_success()
        {
            success sc = new success();
            sc.Location = new Point(450, 150);
         //   sc.ShowDialog();



        }
        private void open_photo()
        {

            openFileDialog1.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                done = true;
                pic = openFileDialog1.FileName;
                MessageBox.Show(pic + "");
                pictureBox1.Image = new Bitmap(pic);
            }

            ///save image in data base by image

        }
        private void UserControl2_Load(object sender, EventArgs e)
        {

        }
        private bool find(string name)
        {
            string select = "select name from Meals";
            conn.Open();

            SqlCommand cmd2 = new SqlCommand(select, conn);
            SqlDataReader reader = cmd2.ExecuteReader();

            while (reader.Read())
            {
                if (reader[0].ToString() == name)
                { conn.Close(); return true; }
            }
            conn.Close();
            return false;
        }

        private void delete_item()
        {
            if (find(textBox3.Text))
            {
                conn.Open();
                string qry = "DELETE FROM Meals WHERE name ='" + textBox3.Text+ "' ;";
                cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                show_success();
            }
            else
            {
                MessageBox.Show("the item doesn't Exist  :(");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            insert_item();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open_photo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete_item();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 f;
            f = (Form1)this.FindForm();
            f.WindowState = FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            UserControl1 uc8 = new UserControl1();

            this.Controls.Clear();
            this.Hide();
            Form1 form;
            form = (Form1)this.FindForm();
            form.Controls.Add(uc8);
            uc8.Visible = true;
            uc8.BringToFront();
        }

        private void insert_item()
        {

            double dou; int intt;

            if (done && double.TryParse(textBox2.Text, out dou) == true && Int32.TryParse(textBox1.Text, out intt) == false && textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                if (!find(textBox1.Text))
                {
                    conn.Open();

                    qry = "Insert Into Meals(name,calory,pic) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + pic + "')";
                    cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    show_success();
                }
                else
                {
                    MessageBox.Show("the item is already Exist !");
                }
            }
            else
            {
                MessageBox.Show("please enter correct values");
            }

        }

    }
}
