using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class before_and_after : UserControl
    {

        static string sqll = "Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true";
        string pic, qry;
        int increament = 0;
        SqlConnection conn = new SqlConnection(sqll);
        SqlCommand cmd;
        public before_and_after()
        {
            InitializeComponent();
        }
        public void insert_group_box(string user_name, string pic1_name, string pic2_name, double old_weight, double new_weight, string country_name)
        {
            PictureBox pic1 = new PictureBox();
            PictureBox pic2 = new PictureBox();
            pic1.Image = new Bitmap(pic1_name);
            pic2.Image = new Bitmap(pic2_name);

            pic1.Size = new Size(150, 150);
            pic1.Location = new Point(55, 70);
            pic2.Size = new Size(150, 150);
            pic2.Location = new Point(350, 70);
            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            pic2.SizeMode = PictureBoxSizeMode.StretchImage;
            //
            Label lab1 = new Label();
            Label lab2 = new Label();
            Label lab3 = new Label();
            Label lab4 = new Label();
            Label lab5 = new Label();
            Label lab6 = new Label();
            Label lab7 = new Label();
            Label lab8 = new Label();


            lab1.Text = "Before";
            lab1.Font = new Font("Bold", 13); ;
            lab1.Size = new Size(100, 25);
            lab1.Location = new Point(100, 35);
            lab1.ForeColor = Color.Teal;

            lab2.Text = "After";
            lab2.Font = new Font("Bold", 13); ;
            lab2.Size = new Size(100, 25);
            lab2.Location = new Point(400, 35);
            lab2.ForeColor = Color.Teal;

            lab3.Text = "Country :";
            lab3.ForeColor = Color.Teal;
            lab3.Font = new Font("Bold", 13); ;
            lab3.Size = new Size(100, 25);
            lab3.Location = new Point(5, 280);


            lab4.Text = country_name;
            lab4.Font = new Font("Bold", 13); ;
            lab4.Size = new Size(250, 30);
            lab4.Location = new Point(110, 278);
            lab4.ForeColor = Color.Black;

            lab5.Text = old_weight.ToString();
            lab5.Font = new Font("Bold", 12); ;
            lab5.Size = new Size(100, 30);
            lab5.Location = new Point(100, 230);
            lab5.ForeColor = Color.Black;

            lab6.Text = new_weight.ToString();
            lab6.Font = new Font("Bold", 12); ;
            lab6.Size = new Size(100, 30);
            lab6.Location = new Point(400, 230);
            lab6.ForeColor = Color.Black;
            GroupBox gb = new GroupBox();
            gb.BackColor = Color.Honeydew;

            lab7.Text = "Username:";
            lab7.ForeColor = Color.Teal;
            lab7.Font = new Font("Bold", 13);
            // lab7.Size = new Size(100, 45);
            lab7.Location = new Point(5, 255);

            lab8.Text = user_name;
            lab8.ForeColor = Color.Black;
            lab8.Font = new Font("Bold", 13);
            lab8.Location = new Point(110, 255);

            gb.Controls.Add(pic1);
            gb.Controls.Add(pic2);
            gb.Controls.Add(lab1);
            gb.Controls.Add(lab2);
            gb.Controls.Add(lab3);
            gb.Controls.Add(lab4);
            gb.Controls.Add(lab5);
            gb.Controls.Add(lab6);
            gb.Controls.Add(lab7);
            gb.Controls.Add(lab8);
            gb.Name = "gb";
            gb.Location = new Point(0, 32);
            gb.Size = new Size(582, 305);
            gb.Top = increament * 300;


            // gb.Text = user_name;
            //gb.Font = new Font("Eelephant,Bold", 17);
            gb.FlatStyle = FlatStyle.Standard;
            this.Controls.Add(gb);
            increament++;
        }

        private void before_and_after_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            try
            {
                conn.Open();
                qry = "select user_name,Before_pic,After_pic,weight ,country,target from user_account";
                cmd = new SqlCommand(qry, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string u_n = reader.GetString(0);
                    string b_pic = reader.GetString(1);
                    string a_pic = reader.GetString(2);
                    double o_weight = reader.GetDouble(3);
                    string country = reader.GetString(4);
                    double target = reader.GetDouble(5);
                    if (a_pic.Length > 5)
                    insert_group_box(u_n, b_pic, a_pic, o_weight, target, country);
                    button2.Visible = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
