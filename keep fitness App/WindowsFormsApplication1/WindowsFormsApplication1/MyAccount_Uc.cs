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
using System.IO;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication1
{
    public partial class MyAccount_Uc : UserControl
    {
        string imgloc = "", pic;
        bool done = false;
        int id;
        public MyAccount_Uc()
        {
            InitializeComponent();
            
        }
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        int DropDownWidth(ComboBox myCombo)
        {


            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

     /*   void Connection()
        {
            connection.Open();
            string c = "SELECT ID FROM Online WHERE status = 'True' ";
            SqlCommand com1 = new SqlCommand(c, connection);
            SqlDataReader reader = com1.ExecuteReader();
            while (reader.Read())
            {

                id = reader.GetInt32(0);

            }


            connection.Close();
            reader.Close();

        }*/
        public void regex(string re, TextBox tb, Label lbl)
        {
            Regex regx = new Regex(re);
            if (regx.IsMatch(tb.Text))
            {
                lbl.ForeColor = Color.Teal;
                lbl.Text = " ";
            }
            else
            {
                lbl.ForeColor = Color.Red;
                lbl.Text = " In Vaild";
            }

        }

        private void UserNameBox_TextChanged(object sender, EventArgs e)
        {
            if (UserNameBox.Text != "")
            {
                label12.ForeColor = Color.Teal;
                label12.Text = "";
            }

            else
            {

                label12.ForeColor = Color.Red;
                label12.Text = " In Vaild";
            }
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            regex(@"([\w]+)@([\w]+)\.(com)$", EmailBox, label11);
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            Regex regx = new Regex("^.{6,}$");
            if (regx.IsMatch(PasswordBox.Text))
            {
                label13.ForeColor = Color.Teal;
                label13.Text = " ";
            }
            else
            {
                label13.ForeColor = Color.Red;
                label13.Text = " Tooo Short ! ";
            }
        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            regex(@"^01[0-2][0-9]{8}$", PhoneBox, label14);

        }

        private void AnsweBox_TextChanged(object sender, EventArgs e)
        {
            if (AnsweBox.Text != "")
            {
                label15.ForeColor = Color.Teal;
                label15.Text = "";
            }
            else
            {
                label15.ForeColor = Color.Red;
                label15.Text = " In Vaild";
            }
        }

        private void SecurityBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            SecurityBox.DropDownWidth = DropDownWidth(SecurityBox);

            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void SaveEdite_Click(object sender, EventArgs e)
        {
            if (label12.ForeColor == Color.Red || label13.ForeColor == Color.Red || label14.ForeColor == Color.Red || label11.ForeColor == Color.Red || label15.ForeColor == Color.Red)
            {
                
                message.Visible = true;
            }
            else
            {
                message.Visible = false;

                connection.Open();
                try
                {
                    string Q = " UPDATE user_account SET password = '" + PasswordBox.Text.ToString() + "' ,user_name = '" + UserNameBox.Text.ToString() + "',email = '" + EmailBox.Text.ToString() + "',phone = '" + PhoneBox.Text.ToString() + "',sec_Question = '" + SecurityBox.Text.ToString() + "',Answer = '" + AnsweBox.Text.ToString() + "' WHERE  id ='" + Program.ID+ "'";
                    SqlCommand com2 = new SqlCommand(Q, connection);
                    com2.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Write another user name !");
                    MessageBox.Show(ex.ToString());

                }
                connection.Close();
            }
        }

        private void MyAccount_Uc_Load(object sender, EventArgs e)
        {
            SecurityBox.DropDownWidth = DropDownWidth(SecurityBox);

            connection.Open();
            string q = " SELECT user_name, Gender,password ,email ,phone ,sec_Question,Answer,age ,weight ,target ,height, Before_pic from user_account where id ='" + Program.ID+ "'";
            SqlCommand com = new SqlCommand(q, connection);
            com.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Gender.Text = dr["Gender"].ToString();
                Age.Text = dr["age"].ToString();
                weight.Text = dr["weight"].ToString();
                targetW.Text = dr["target"].ToString();
                height.Text = dr["height"].ToString();
                pictureBox.Image = new Bitmap(dr["Before_pic"].ToString());
                UserNameBox.Text = dr["user_name"].ToString();
                PasswordBox.Text = dr["password"].ToString();
                EmailBox.Text = dr["email"].ToString();
                SecurityBox.Text = dr["sec_Question"].ToString();
                MessageBox.Show(dr["sec_Question"].ToString());
                MessageBox.Show(SecurityBox.Text);
                AnsweBox.Text = dr["Answer"].ToString();
                PhoneBox.Text = dr["phone"].ToString();

            }

            connection.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void picUploadBtn_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "jpg|*.jpg";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                done = true;
                pic = openFileDialog1.FileName;
                MessageBox.Show(pic + "");
                pictureBox.Image = new Bitmap(pic);
            }

            if (done == true)
            {
                try
                {
                    connection.Open();
                    string q = "update user_account set Before_pic ='" + pic + "' where id= '" +Program.ID + "' ";
                    SqlCommand cmd = new SqlCommand(q, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch { MessageBox.Show("wrong"); }
            }
        }
    }
}
