using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Rate_feedback : UserControl
    {
        string T, T1;
        int col1, col2, col3, col4, col5;
        int newrate, oldrate = -1, val;
        int id2 = 2;
        string col;
        string old_col, new_col;
        int old_val;
        bool okay = false;
        int  r;
        int x, neval;
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        private void increament()
        {
            SqlCommand cmd4 = new SqlCommand(T, con);
            cmd4.ExecuteNonQuery();
        }
        private void decreament()
        {
            SqlCommand cmd26 = new SqlCommand(T1, con);
            cmd26.ExecuteNonQuery();
        }
        private void submitRate_Click(object sender, EventArgs e)
        {

            r = bunifuRating1.Value;
            con.Open();
            if (r > 0)
            {
                string qry1 = "select *from Average_rate";
                SqlCommand cmd1 = new SqlCommand(qry1, con);

                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    col1 = reader.GetInt32(0);
                    col2 = reader.GetInt32(1);
                    col3 = reader.GetInt32(2);
                    col4 = reader.GetInt32(3);
                    col5 = reader.GetInt32(4);
                    break;
                }
                reader.Close();
                ///
                MessageBox.Show(col1 + " " + col2 + " " + col3 + " " + col4 + " " + col5);
                if (r == 1)
                {
                    val = 1;
                    col = "one";
                    neval = col1 + 1;
                    string qry9 = "UPDATE Average_rate SET one = '" + (int)(neval) + "' ";
                    T = qry9;
                }
                else if (r == 2)
                {
                    val = 2;
                    col = "two";
                    neval = col2 + 1;
                    string qry10 = "UPDATE Average_rate SET two = '" + (int)(neval) + "' ";
                    T = qry10;
                }
                else if (r == 3)
                {
                    val = 3;
                    col = "three";
                    neval = col3 + 1;
                    string qry11 = "UPDATE Average_rate SET three = '" + (int)(neval) + "' ";
                    T = qry11;
                }
                else if (r == 4)
                {
                    val = 4;
                    col = "four";
                    neval = col4 + 1;
                    string qry12 = "UPDATE Average_rate SET four = '" + (int)(neval) + "' ";
                    T = qry12;
                }
                else if (r == 5)
                {
                    val = 5;
                    col = "five";
                    neval = col5 + 1;
                    string qry13 = "UPDATE Average_rate SET five = '" + (int)(neval) + "' ";
                    T = qry13;
                }

                ///
                MessageBox.Show(neval + "");

                string qry2 = "select rate from user_account where ID='" + Program.ID+ "'";
                SqlCommand cmd2 = new SqlCommand(qry2, con);
                SqlDataReader reader1 = cmd2.ExecuteReader();
                while (reader1.Read())
                { oldrate = (int)reader1.GetInt32(0);

                    if (oldrate!=0 )
                    {
                        okay = true;
                        break;
                    }
                    else
                        okay = false;
                }
                MessageBox.Show(oldrate + "");
                reader1.Close();

                if (oldrate == 1)
                { old_col = "one"; old_val = 1; neval = col1 - 1; string qry21 = "UPDATE Average_rate SET one ='" + (int)(neval) + "' "; T1 = qry21; }
                if (oldrate == 2)
                { old_col = "two"; old_val = 2; neval = col2 - 1; string qry22 = "UPDATE Average_rate SET two ='" + (int)(neval) + "' "; T1 = qry22; }
                if (oldrate == 3)
                { old_col = "three"; old_val = 3; neval = col3 - 1; string qry23 = "UPDATE Average_rate SET three ='" + (int)(neval) + "' "; T1 = qry23; }
                if (oldrate == 4)
                { old_col = "four"; old_val = 4; neval = col4 - 1; string qry24 = "UPDATE Average_rate SET four ='" + (int)(neval) + "' "; T1 = qry24; }
                if (oldrate == 5)
                { old_col = "five"; old_val = 5; neval = col5 - 1; string qry25 = "UPDATE Average_rate SET five ='" + (int)(neval) + "' "; T1 = qry25; }
                reader.Close();
                if (okay == false)
                {
                    try
                    {
                        string qry3 = "update user_account   set rate = '" + val + "'where id ='"+Program.ID+ "'";
                        SqlCommand cmd3 = new SqlCommand(qry3, con);
                        cmd3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    increament();
                }
                else
                {

                    string qry5 = "UPDATE user_account SET rate  = '" + val + "' WHERE ID = '" + Program.ID + "' ";
                    SqlCommand cmd5 = new SqlCommand(qry5, con);
                    cmd5.ExecuteNonQuery();
                    if (val == old_val)
                    { }
                    else
                    {
                        increament();
                        ///REMOVE
                        decreament();
                    }
                }

                MessageBox.Show("Rate saved sucessfully");
                con.Close();
            }
            con.Close();
        }

        private void submitFeedback_Click(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            con.Open();
            if (feedback.Text == "")
                MessageBox.Show("Please enter your feedback!");
            else
            {
                string qry = "Insert Into feedback(ID,feedback,date) values('" + Program.ID+ "','" + feedback.Text + "','" + datetime + "')";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your feedback saved sucessfully");
            }
            con.Close();
        }

        private void Rate_feedback_Load(object sender, EventArgs e)
        {

        }


        public Rate_feedback()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuRating1_onValueChanged(object sender, EventArgs e)
        {

        }
    }
}
