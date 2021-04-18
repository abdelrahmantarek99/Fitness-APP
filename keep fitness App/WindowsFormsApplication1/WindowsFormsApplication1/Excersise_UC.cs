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
    public partial class Excersise_UC : UserControl
    {
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        public DateTime datetime = DateTime.Now;
        public Good_UC gj = new Good_UC();
        string pic;
        string dur;
        string calories;
        decimal decimalDur;
        decimal decimalCalories;
        decimal TotalCal;
        int calo;
        public Excersise_UC()
        {
            InitializeComponent();
        }

        private void Excersise_UC_Load(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Visible = true;

            try
            {


                string sql = "SELECT Type,pic,calory FROM Exercise ";
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;

                while (reader.Read())
                {
                    string text = reader[0].ToString();
                    if (text.Contains(searchBox.Text))
                    {
                        Button exercise = new Button();
                        exercise.BackColor = Color.FromArgb(128, 64, 64);
                        exercise.Location = new Point(0, i * 32);
                        exercise.Font = new Font("Bold", 10);
                        exercise.ForeColor = Color.Snow;
                        exercise.FlatStyle = FlatStyle.Flat;
                        exercise.Size = new Size(205, 32);

                        PictureBox pics = new PictureBox();
                        pics.BorderStyle = BorderStyle.None;
                        pics.Size = new Size(30, 30);
                        pics.Location = new Point(0, 1);
                        pics.BackColor = Color.White;
                        pics.SizeMode = PictureBoxSizeMode.StretchImage;
                        exercise.Text = text;
                        pic = reader[1].ToString();
                        exercise.Name = pic;
                        exercise.TabIndex = (int)(reader[2]);


                        if (pic != "")
                        {
                            pics.Image = new Bitmap(pic);
                        }
                        else
                            pics.Image = null;

                        exercise.Controls.Add(pics);
                        panel1.Controls.Add(exercise);

                        i++;
                        exercise.MouseClick += (s, t) =>
                        {
                            panel1.Controls.Clear();
                            panel1.Visible = false;
                            ExNameTextBox.Text = exercise.Text;
                            TimeTextBox.Text = DateTime.Now.ToLongTimeString();
                            CalTextBox.Text = exercise.TabIndex.ToString();
                             calo = exercise.TabIndex;

                            if (exercise.Name != "")
                            {
                                ExPictureBox.Image = new Bitmap(exercise.Name);
                            }
                            else
                                ExPictureBox.Image = null;

                        };
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("some errors ocurred :" + ex.Message);
            }

            connection.Close();
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dur = ExDurTextBox.Text;
                calories = CalTextBox.Text;
                decimalDur = Convert.ToDecimal(dur);
                decimalCalories = Convert.ToDecimal(calories);
                TotalCal = decimalDur * decimalCalories;
            }
            catch
            {
                MessageBox.Show("Enter a valid value");
            }
            try
            {
                connection.Open();
                string sql = "select ID,Type from Exercise where Type='" + ExNameTextBox.Text + "'";
                cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int ExID = (int)reader[0];
                reader.Close();

                string sql1 = "INSERT INTO ExerciseOfUser (ID,Exercise_ID,exercise_duration,Exercise_Time) VALUES ('" + Program.ID + "','" + ExID + "','" + decimalDur + "','" + datetime + "')";
                cmd = new SqlCommand(sql1, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            ExNameTextBox.Text = "";
            ExDurTextBox.Text = TimeTextBox.Text = CalTextBox.Text = "";
            ExPictureBox.Image = null;


        }

        private void ExDurTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ExDurTextBox.Text != "")
            {
                string dur = ExDurTextBox.Text;
                double decimaldur = Convert.ToDouble(dur);
                double total = decimaldur * calo;
                CalTextBox.Text = total.ToString();
            }
            else if (ExNameTextBox.Text == "")
                CalTextBox.Text = "1";
            else
            {
                CalTextBox.Text = calo.ToString();
            }
        }
    }
}
