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
    public partial class forget_pass : UserControl
    {
        public SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        public int Id;
        public string ques, answer,pass;

        public forget_pass()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void forget_pass_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Uc_log log = new Uc_log();
            this.Controls.Clear();
            log.Visible = true;
            this.Controls.Add(log);
            log.Location = new Point(0, 0);
        }

        private void btn_forget_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "SELECT user_name,sec_Question,Answer,password FROM user_account ";
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd = new SqlCommand(id, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Program.usrname = reader[0].ToString();
                    if (Program.usrname == name.Text)
                    {
                        ques = reader[1].ToString();
                        answer = reader[2].ToString();
                        pass = reader[3].ToString();

                        break;
                    }



                }
                reader.Close();
                
                if (que.Text.Length>0&&textBox1.Text.Length>0&&name.Text.Length>0 && ques == que.SelectedItem.ToString() && answer == textBox1.Text)
                {
                    MessageBox.Show("Your Password Is " + pass + " plz Don't forget it again");
                    MessageBox.Show("login successfully");
                    cmd = new SqlCommand("update user_account set online ='" + 1 + "'where user_name ='" + Program.usrname + "'", connection);
                    cmd.ExecuteNonQuery();

                   // MessageBox.Show("ONLINE");
                    this.Controls.Clear();
                    Home hom = new Home();
                    Form1 form;
                    form = (Form1)this.FindForm();
                    form.panel2.Show();
                    form.panel2.BringToFront();
                    hom.Location = new Point(175, 0);
                    this.Controls.Add(hom);
                    hom.BringToFront();
                    hom.Visible = true;
                }

                else
                    MessageBox.Show("Please Enter correct Answers");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        
    }

        private void name_TextChanged(object sender, EventArgs e)
        {
            ///ch1 = true;
        }
    }
}
