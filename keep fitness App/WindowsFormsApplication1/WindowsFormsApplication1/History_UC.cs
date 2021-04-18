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
    public partial class History_UC : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        DateTime dateTime;

        public History_UC()
        {
            InitializeComponent();
        }

        private void History_UC_Load(object sender, EventArgs e)
        {
            int count = 0;
            int j = -1;
            try
            {
                string sql = "SELECT * from ExerciseOfUser inner join Exercise on ExerciseOfUser.Exercise_ID=Exercise.ID inner join user_account on ExerciseOfUser.ID=user_account.ID  where user_account.online='" + true + "'order by ExerciseOfUser.Exercise_Time";
                connection.Open();
                SqlCommand cmd2 = new SqlCommand(sql, connection);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    count++;
                    Double dur = (Double)reader2[2];
                    DateTime date = (DateTime)reader2[3];
                    string name = reader2[5].ToString();
                    double cal = (double)reader2[6];
                    string pic = reader2[7].ToString();
                    double Tcal = dur * cal;
                    if (date >= dateTime && date < dateTime.AddDays(1) && count != 1)
                    {

                        treeView1.Nodes[j].Nodes.Add("Exercise Name: " + name + "   Calories: " + Tcal.ToString());
                    }
                    else
                    {
                        j++;
                        treeView1.Nodes.Add(date.ToString().Remove(10, date.ToString().Length-10));
                        treeView1.Nodes[j].Nodes.Add("Exercise Name: "+name + "   Calories: " + Tcal.ToString());

                        dateTime = date;
                    }
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
           
    }
}
