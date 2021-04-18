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
    public partial class UserControl4 : UserControl
    {

        int ID = 1;
        int id;
        string feedbacks, dates;
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        public UserControl4()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlDataReader myReader = null;
            try
            {
                con.Open();

                SqlCommand myCommand = new SqlCommand("select * from Average_rate", con);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    rate1_show.Text = myReader[0].ToString();
                    rate2_show.Text = myReader[1].ToString();
                    rate3_show.Text = myReader[2].ToString();
                    rate4_show.Text = myReader[3].ToString();
                    rate5_show.Text = myReader[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                myReader.Close();
            }
        }
private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da;
            da = new SqlDataAdapter(@"SELECT ID,feedback,date FROM feedback", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            feedbacksdata.DataSource = dt;
            con.Close();
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

        private void feedbacksdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(feedbacksdata.Rows[e.RowIndex].Cells["ID1"].Value.ToString());
            id_text.Text = id.ToString();
            feedback_text.Text = feedbacksdata.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
            date_text.Text = feedbacksdata.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
        }

        private void feedback_text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
