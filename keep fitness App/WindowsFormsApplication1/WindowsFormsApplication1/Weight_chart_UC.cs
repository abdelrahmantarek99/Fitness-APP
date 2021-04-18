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
namespace WindowsFormsApplication1
{
    public partial class Weight_chart_UC : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        int i = 1;
        double weight, FirstWeight, target;
        DateTime dateTime = DateTime.Now, date;
        public Records_UC R = new Records_UC();
        private void DoneBtn_Click(object sender, EventArgs e)
        {
            this.chart1.Series["My Weight"].Points.Clear();
            try
            {

                SqlDataReader reader;
                connection.Open();
                string query2 = "insert into weight_chart(ID,new_weight,date)values('" + Program.ID + "','" + WeightTextBox.Text + "','" + DateTime.Now + "')";
                cmd = new SqlCommand(query2, connection);
                cmd.ExecuteNonQuery();


                string sql = "select ID,new_weight,date from weight_chart order by date";
                cmd = new SqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader[0];
                    if (id == Program.ID)
                    {
                        weight = (double)reader[1];
                        date = (DateTime)(reader[2]);
                        this.chart1.Series["My Weight"].Points.AddY(weight);
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            i += 20;
            WeightTextBox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            R.Location = new Point(0, 0);
            this.Controls.Clear();
            this.Controls.Add(R);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double intW1 = Convert.ToDouble(textBox1.Text) - ((Convert.ToDouble(textBox2.Text) - 100 - Convert.ToDouble(textBox1.Text)) / 2);
                double intW2 = Convert.ToDouble(textBox2.Text) - 100 + Convert.ToDouble(textBox1.Text) / 10;
                label4.Text = intW1.ToString() + " : " + intW2.ToString() + "  Kg";
                label4.Visible = true;
            }
            catch
            {
                MessageBox.Show("Enter a valid numbers ");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            string sql = "select ID,new_weight,date from weight_chart order by date";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader[0];
                if (id == Program.ID)
                {
                    double weightt = (double)reader[1];
                    date = (DateTime)(reader[2]);
                    this.chart1.Series["My Weight"].Points.AddY(weightt);

                    i += 20;
                }
            }
            reader.Close();
            connection.Close();
        }

        
        public Weight_chart_UC()
        {
            InitializeComponent();
        }

        private void Weight_chart_UC_Load(object sender, EventArgs e)
        {
            string sql = "select ID,new_weight,date from weight_chart order by date";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader[0];
                if (id == Program.ID)
                {
                    double weightt = (double)reader[1];
                    date = (DateTime)(reader[2]);
                    this.chart1.Series["My Weight"].Points.AddY(weightt);

                    i += 20;
                }
            }
            reader.Close();
            connection.Close();
        }
    }
}
