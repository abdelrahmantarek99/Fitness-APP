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
    public partial class Records_UC : UserControl
    {
        public Records_UC()
        {
            InitializeComponent();
        }

        private void Records_UC_Load(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
            string sql = "select ID,new_weight,date from weight_chart order by date";
            SqlCommand cmd;
            DateTime date;
            int i = 3;
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

                    Label lbl1 = new Label();
                    lbl1.Location = new Point(13, 35 + i);
                    lbl1.Text = date.ToString().Remove(10,date.ToString().Length-10);
                    lbl1.ForeColor = Color.FromArgb(128, 64, 64);
                    lbl1.Font = new Font("Bold", 12);
                    this.Controls.Add(lbl1);

                    Label lbl2 = new Label();
                    lbl2.Location = new Point(110, 35 + i);
                    lbl2.Text = ":you became ";
                    lbl2.ForeColor = Color.FromArgb(128, 64, 64);
                    lbl2.Font = new Font("Bold", 12);
                    this.Controls.Add(lbl2);

                    Label lbl3 = new Label();
                    lbl3.Location = new Point(210, 35 + i);
                    lbl3.Text = weightt.ToString() + " Kg";
                    lbl3.ForeColor = Color.FromArgb(128, 64, 64);
                    lbl3.Font = new Font("Bold", 12);
                    this.Controls.Add(lbl3);


                    i += 50;
                }
            }
            reader.Close();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Weight_chart_UC weight_Chart_UC = new Weight_chart_UC();
            weight_Chart_UC.Location = new Point(0, 0);
            this.Controls.Add(weight_Chart_UC);
        }
    }
}
