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
    public partial class delete : UserControl
    {
        SqlDataAdapter sda;

        DataTable dt;
        public delete()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_Load(object sender, EventArgs e)
        {
            String sql = "Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true";
            SqlConnection connection = new SqlConnection(sql);
            sda = new SqlDataAdapter(@"SELECT id,user_name,email,phone,Gender FROM user_account", connection);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                button22.Enabled = true;
            else
                button22.Enabled = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {

                int i = dataGridView1.SelectedCells[0].RowIndex;

                SqlConnection con = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");

                SqlCommand cmd = new SqlCommand();
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    cmd.CommandText = "DELETE FROM user_account WHERE id=" + dataGridView1.Rows[i].Cells[0].Value + "";
                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataGridView1.Rows.RemoveAt(i);
                    MessageBox.Show("Deleted Successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
