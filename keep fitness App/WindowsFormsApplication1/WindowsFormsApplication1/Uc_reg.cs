using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Uc_reg : UserControl
    {

        public int ID;
        public string NAME;
        public Uc_reg()
        {
            InitializeComponent();
        }
        public class RegularExpression
        {
            public static bool checkemail(string email)
            {
                bool Isvalid = false;
                Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (r.IsMatch(email))
                {

                    Isvalid = true;

                }

                return Isvalid;


            }
        }
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd = new SqlCommand();
        string status;
        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            string user_name = "SELECT user_name FROM user_account ";
            SqlCommand cmd = new SqlCommand();
            connection.Open();
            cmd = new SqlCommand(user_name, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Name = reader[0].ToString();
                if (Name == textBox3.Text)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox3, "error");
                    label11.Visible = true;
                    break;

                }
                else
                {
                    errorProvider1.Clear();
                    label11.Visible = false;
                    e.Cancel = false;

                }

            }
            connection.Close();
            reader.Close();

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string email = "SELECT email FROM user_account ";
            SqlCommand cmd = new SqlCommand();
            connection.Open();
            cmd = new SqlCommand(email, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {  Name = reader[0].ToString();
                if (Name == textBox4.Text)
                {
                    e.Cancel = true;
                    errorProvider2.SetError(textBox4, "error");
                    label9.ForeColor = Color.DarkRed;
                    label9.Text = "invalid email";
                    break;


                }
                else if (Name != textBox4.Text && RegularExpression.checkemail(textBox4.Text.ToString()))
                {
                    e.Cancel = false;
                    label9.ForeColor = Color.Green;
                    label9.Text = "Valid email";
                    errorProvider2.Clear();
                }
                else if (Name != textBox4.Text && !RegularExpression.checkemail(textBox4.Text.ToString()))
                {
                    e.Cancel = true;
                    errorProvider2.SetError(textBox4, "error");
                    label9.ForeColor = Color.DarkRed;
                    label9.Text = "invalid email";
                    break;
                }

            }
            connection.Close();
            reader.Close();


        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.TextLength < 6 && textBox1.TextLength > 0)
            {
                label10.Text = "too short";
                errorProvider3.SetError(textBox1, "error");
                e.Cancel = true;
            }
            else if (textBox1.TextLength == 0)
            {
                label10.Text = "enter your password";
                errorProvider3.SetError(textBox1, "error");
                e.Cancel = true;
            }
            else
            {
                label10.ForeColor = Color.Green;
                label10.Text = "strong password";
                errorProvider3.Clear();
                e.Cancel = false;

            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text != textBox1.Text)
            {


                label12.Text = "wrong password";
                errorProvider4.SetError(textBox2, "error");
                e.Cancel = true;

            }
            else
            {
                label12.Text = null;
                errorProvider4.Clear();
                e.Cancel = false;

            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^(01)(([][0-9]{3}){3})$");
            if (!regex.IsMatch(textBox5.Text))
            {

                label13.Text = "Invalid number";
                errorProvider5.SetError(textBox5, "error");
                e.Cancel = true;
            }
            else
            {
                label13.Text = "";
                errorProvider5.Clear();
                e.Cancel = false;

            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                errorProvider6.SetError(comboBox1, "Select Question");
                e.Cancel = true;
            }
            else
            {
                errorProvider6.Clear();
                e.Cancel = false;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {

            if (textBox6.TextLength == 0)
            {
                errorProvider7.SetError(textBox6, "Enter the answer");
                e.Cancel = true;
            }
            else
            {
                errorProvider7.Clear();
                e.Cancel = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Program.gend = radioButton1.Text;
            checkBox1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Program.gend = radioButton2.Text;
            checkBox1.Visible = true;
        }

        private void btn2_Click(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                cmd = new SqlCommand("INSERT INTO user_account(user_name,password,email,phone,sec_Question,Answer,Gender) Values('" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + Program.gend + "')", connection);
                Program.usrname = textBox3.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("added succesfully");
              
                Uc_info info = new Uc_info();
                this.Controls.Clear();
                this.Controls.Add(info);

                /*
                string ss = "Select user_name,id FROM user_account";
                SqlCommand cmdd = new SqlCommand();

                cmdd = new SqlCommand(ss, connection);

                SqlDataReader reader = cmdd.ExecuteReader();
                while (reader.Read())
                {

                    Name = reader[0].ToString();
                    if (Name.Equals(NAME))
                    {
                        Program.reg.ID = (int)reader[1];
                        MessageBox.Show("YES");
                        MessageBox.Show(Program.reg.ID.ToString());
                        break;
                    }
                }
                reader.Close();
                connection.Close();
                try
                {
                    connection.Open();
                    cmd = new SqlCommand("INSERT INTO user_account(ID,status) VALUES('" + Program.reg.ID + "','" + 1 + "')", connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(Program.reg.ID.ToString());
                    MessageBox.Show("ONLINE");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //connection.Close();
                Uc_info info = new Uc_info();
                this.Controls.Clear();
                this.Controls.Add(info);
                connection.Close();

            }
          


    */
            }
            catch (Exception ex)
            {

                MessageBox.Show("please enter correct values ");
                MessageBox.Show(ex.Message);
            }

           
            connection.Close();
        }

        private void Uc_reg_Load(object sender, EventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                btn2.Enabled = true;
                errorProvider8.Clear();



            }
            else
            {
                errorProvider8.SetError(checkBox1, null);
                btn2.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            toka start = new toka();
            this.Controls.Clear();
            start.Visible = true;
            this.Controls.Add(start);
            start.Location = new Point(0, 0);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
        }
    }
}
