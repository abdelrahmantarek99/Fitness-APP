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
namespace WindowsFormsApplication1
{
    public partial class Meals_Hist_UC : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        TreeView treeView;
        Label lbl;
        int i = 0;
        DateTime dateTime;
        public Meals_Hist_UC()
        {
            InitializeComponent();
        }

        private void Meals_Hist_UC_Load(object sender, EventArgs e)
        {

            int count = 0;

            try
            {
                string sql = "SELECT * from user_meal inner join Meals on user_meal.meal_ID=Meals.id inner join user_account on user_meal.ID=user_account.ID  where user_account.online='" + true + "'order by user_meal.date";
                connection.Open();
                SqlCommand cmd2 = new SqlCommand(sql, connection);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    count++;

                    DateTime date = (DateTime)reader2[1];
                    string meal = reader2[7].ToString();
                    string type = reader2[3].ToString();
                    double quantity = (double)reader2[4];
                    int cups = (int)reader2[5];
                    double calory = (double)reader2[8];
                    double Tcalory = quantity * calory;

                    if (date >= dateTime && date < dateTime.AddDays(1) && count != 1)
                    {
                        addChild(type, meal, quantity, Tcalory, cups);
                    }
                    else
                    {
                        createTree(date);
                        addChild(type, meal, quantity, Tcalory, cups);
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

        public void addChild(string type, string meal, double quantity, double Tcalory, double cups)
        {
            if (type == "Breakfast")
                treeView.Nodes[0].Nodes.Add("Name : "+meal + "          Quantity : " + quantity + "         Calories : " + Tcalory);
            else if (type == "Launch")
                treeView.Nodes[1].Nodes.Add("Name :"+meal + "          Quantity : " + quantity + "         Calories : " + Tcalory);
            else if (type == "Dinner")
                treeView.Nodes[2].Nodes.Add("Name :"+meal + "          Quantity : " + quantity + "         Calories : " + Tcalory);
            else if (type == "Snacks")
                treeView.Nodes[3].Nodes.Add("Name :"+meal + "          Quantity : " + quantity + "         Calories : " + Tcalory);
        }
        public void createTree(DateTime date)
        {
            lbl = new Label();
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Bold", 12);
            lbl.Location = new Point(17, 20 + i);

            lbl.Text = date.ToString().Remove(10, date.ToString().Length - 10);
            this.Controls.Add(lbl);

            treeView = new TreeView(); 
            treeView.BackColor = Color.Snow;
            treeView.ForeColor = Color.FromArgb(128, 64, 64);
            treeView.LineColor = Color.FromArgb(128, 64, 64);
            treeView.Font = new Font("Bold", 10);
            treeView.Size = new Size(480, 124);
            treeView.ItemHeight = 25;
            treeView.Location = new Point(20, 45 + i);
            treeView.Nodes.Add("Breakfast");
            treeView.Nodes.Add("Launch");
            treeView.Nodes.Add("dinner");
            treeView.Nodes.Add("Snacks");
            this.Controls.Add(treeView);
            i += 162;

        }
    }
}
