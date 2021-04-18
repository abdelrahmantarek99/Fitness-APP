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
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Meals : UserControl
    {
        public SqlConnection con = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        public SqlCommand cmd;
        public DateTime datetime = DateTime.Now;
        public UC UC_meals = new UC();
        public string type="";
        public string value;
        public string name;
        public string pic,call;
        public int cal;
        public Meals()
        {
            InitializeComponent();
        }

        private void Meals_Load(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            UC_meals.Controls.Clear();
            UC_meals.Visible = true;
            this.Controls.Add(UC_meals);
            UC_meals.Location = new Point(266, 50);
            UC_meals.BringToFront();
            try
            {
                string sql = "SELECT name,calory,pic FROM Meals";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0, j = 0;

                while (reader.Read())
                {
                    string text = reader[0].ToString();
                    if (text.Contains(searchBox.Text))
                    {
                        Button meal_btn = new Button();
                        meal_btn.BackColor = Color.Teal;
                        meal_btn.Location = new Point(0, i * 32);
                        meal_btn.Font = new Font("Bold", 10);
                        meal_btn.ForeColor = Color.Snow;
                        meal_btn.FlatStyle = FlatStyle.Flat;
                        meal_btn.Size = new Size(250, 30);

                        PictureBox pics = new PictureBox();
                        pics.BorderStyle = BorderStyle.None;
                        pics.Size = new Size(30, 30);
                        pics.Location = new Point(0, 1);
                        pics.BackColor = Color.White;
                        pics.SizeMode = PictureBoxSizeMode.StretchImage;
                        meal_btn.Text = text;
                        pic = reader[2].ToString();
                        meal_btn.Name = pic;
                        meal_btn.TabIndex =    (int)(reader[1]);
                        if (pic != "")
                        {
                            pics.Image = new Bitmap(pic);

                        }
                        else
                            pics.Image = null;

                        meal_btn.Controls.Add(pics);
                        UC_meals.Controls.Add(meal_btn);
                        i++;


                        meal_btn.MouseClick += (s, t) =>
                        {
                            UC_meals.Controls.Clear();
                            UC_meals.Visible = false;
                            meal_name.Text = meal_btn.Text;
                            quantity_txt.Text = "1";
                            calory_txt.Text = meal_btn.TabIndex.ToString();
                            cal = meal_btn.TabIndex;

                            if (pic != "")
                            {
                                mePictureBox.Image = new Bitmap(meal_btn.Name);

                            }
                            else
                                mePictureBox.Image = null;
                        };

                    }
                    else
                        continue;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR : " + ex.Message);
            }
            con.Close();

        }

        private void quantity_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (quantity_txt.Text != "")
                {
                    string gram = quantity_txt.Text;
                    double decimalgram = Convert.ToDouble(gram);
                    double total = decimalgram * cal;
                    calory_txt.Text = total.ToString();
                }
                else if (meal_name.Text == "")
                    calory_txt.Text = "";
                else
                {
                    calory_txt.Text = cal.ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            bool cheack = bunifuCheckbox4.Checked;

            if (bunifuCheckbox4.Checked == true)
            {

                type = label4.Text;

            }
            else
            {
                type = "";

            }


            bunifuCheckbox1.Enabled = !cheack;
            bunifuCheckbox2.Enabled = !cheack;
            bunifuCheckbox3.Enabled = !cheack;
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            bool cheack = bunifuCheckbox3.Checked;
            if (bunifuCheckbox3.Checked == true)
            {
                type = label3.Text;



            }
            else
            {
                type = "";
               /* bunifuCheckbox1.Enabled = !cheack;
                bunifuCheckbox4.Enabled = !cheack;
                bunifuCheckbox2.Enabled = !cheack;*/

            }
            bunifuCheckbox1.Enabled = !cheack;
            bunifuCheckbox4.Enabled = !cheack;
            bunifuCheckbox2.Enabled = !cheack;
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            bool cheack = bunifuCheckbox2.Checked;

            if (bunifuCheckbox2.Checked == true)
            {
                type = label2.Text;
            }
            else
            {
                type = "";

            }
            bunifuCheckbox1.Enabled = !cheack;
            bunifuCheckbox4.Enabled = !cheack;
            bunifuCheckbox3.Enabled = !cheack;
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            bool cheack = bunifuCheckbox1.Checked;

            if (bunifuCheckbox1.Checked == true)
            {
                type = label1.Text;



            }
            else
                type = "";
            bunifuCheckbox4.Enabled = !cheack;
            bunifuCheckbox2.Enabled = !cheack;
            bunifuCheckbox3.Enabled = !cheack;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {/*
            string qu = quantity_txt.Text;
            string calories = calory_txt.Text;
            decimal decimalQu = Convert.ToDecimal(qu);
            decimal decimalCalories = Convert.ToDecimal(calories);
            decimal total = decimalQu * decimalCalories;
            */
            if (meal_name.Text.Length >0 && type.Length>0)
            {


                try
                {
                    con.Open();
                    string sql1 = "select ID,name from Meals where name='" + meal_name.Text + "'";
                    cmd = new SqlCommand(sql1, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int ID = (int)reader[0];
                    reader.Close();
                    string sql = "INSERT INTO user_meal (ID,date,meal_ID,type_of_meal,quantity,cups_of_water) VALUES('" + Program.ID + "','" + datetime + "','" + ID + "','" + type + "', '" + quantity_txt.Text + "' ,'" + cups_txt.Text + "')";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
                meal_name.Text = "";
                quantity_txt.Text = cups_txt.Text = calory_txt.Text = "";
                mePictureBox.Image = null;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cups_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
