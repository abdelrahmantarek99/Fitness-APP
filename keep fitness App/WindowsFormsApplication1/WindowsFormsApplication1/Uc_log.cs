using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Uc_log : UserControl
    {

         public string Email, pass;
        bool status;
        panel2 panel = new panel2();
        Home hom = new Home();
      //  start stt = new start();
        public Uc_reg registerpage = new Uc_reg();
        forget_pass forget = new forget_pass();
        static String sql = "Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true";
        SqlConnection connection = new SqlConnection(sql);
        
        public Uc_log()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form;
            form = (Form1)this.FindForm();
            this.Controls.Clear();
            forget.Visible = true;
            forget.Location = new Point(0, 0);
            this.Controls.Add(forget);
          ///  Program.v3 = 1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            try
            {
                string Query = "SELECT user_name,password,status FROM user_account ";
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Name=reader.GetString(0);
                    Program.usrname = reader[0].ToString();
                    if (Program.usrname == textBox3.Text)
                    {
                        pass = reader[1].ToString();
                        status = (bool)reader[2];

                        break;
                    }
                }

                reader.Close();
                if (pass == textBox4.Text&&status==false)
                {
                    MessageBox.Show("login successfully");
                    try
                    {

                        cmd = new SqlCommand("update  user_account set online ='" + 1 + "' where user_name ='" + Program.usrname + "'", connection);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ONLINE");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                    this.Controls.Clear();
                    Form1 form;
                    form = (Form1)this.FindForm();
                    form.panel2.Show();
                   form.panel2.BringToFront();
                    hom.Location = new Point(175, 0);
                    this.Controls.Add(hom);
                    hom.BringToFront();
                    hom.Visible = true;
               



                }
                else if (pass == textBox4.Text && status == true)
                {
                    MessageBox.Show("login successfully");
                    try
                    {

                        cmd = new SqlCommand("update  user_account set online ='" + 1 + "' where user_name ='" + Program.usrname + "'", connection);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ONLINE");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this.Controls.Clear();
                    UserControl1 uc1 = new UserControl1();
                    uc1.Location = new Point(0, 0);
                    uc1.BringToFront();
                    this.Controls.Add(uc1);
                    uc1.Visible = true;
                }
                else
                {
                    MessageBox.Show(" incorrect User name Or Password  ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

        

        }

        private void Uc_log_Load(object sender, EventArgs e)
        {
            
        }

        private void btn1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Uc_log_Leave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
          
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Form1 form;
            form = (Form1)this.FindForm();
            form.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 form;
            form = (Form1)this.FindForm();
            form.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {/*
            if (Program.v2==1)
            {
               
                this.Controls.Clear();
                Program.s.Location = new Point(0, 0);
                //this.Controls.Add(Program.s);
              
                Program.s.BringToFront();
                Program.v2 = 0;




            }
           /* else if (loginpage.Visible == true)
            {
                this.Controls.Remove(Program.log);
                loginpage.Visible = false;
                this.Controls.Add(button1);
                this.Controls.Add(button3);
                linkLabel1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;

            }

            else if (forget.Visible == true)
            {
                this.Controls.Remove(Program.log);
                this.Controls.Remove(forget);
                linkLabel1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                this.Controls.Add(button1);
                this.Controls.Add(button3);



            }
            */
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            toka start = new toka();
            this.Controls.Clear();
            start.Visible = true;
            this.Controls.Add(start);
            start.Location = new Point(0, 0);
        }

        private void pic4_Click(object sender, EventArgs e)
        {

        }
    }
}
