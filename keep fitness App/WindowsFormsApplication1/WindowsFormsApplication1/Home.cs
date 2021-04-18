using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Home : UserControl
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GB8C9AV\\SQLEXPRESS;Initial Catalog=Project.Sc;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        DateTime t;
        DateTime temp;
        TimeSpan span;
        public double total_used_cal, total_budget =0, duration = 0;
        public int diff_of_date,calory;
        public Home()
        {
            InitializeComponent();  


        }
        private void get_id()
        {

            con.Open();
            cmd = new SqlCommand("select  id,status  from user_account where online ='" + 1 + "'", con);
       
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Program.ID = (int)reader[0];
                Program.status = (bool)reader[1];
            }
            reader.Close();
            con.Close();
            MessageBox.Show(Program.ID + "");
        }
        void  check_diet()
        {
            con.Open();
            try
            {
                DateTime now = DateTime.Now; DateTime end_date = DateTime.Now;
                cmd = new SqlCommand("select end_date,cal_per_day from user_account where id ='" + Program.ID + "'",con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    total_budget = (double)reader[1];
                    //  label4.Text = reader[1].ToString();
                    end_date = (DateTime)reader[0];
                }
                if (now > end_date)
                {
                    MessageBox.Show("Congratulations");
                    Uc_end end = new Uc_end();
                    this.Controls.Clear();
                    end.Location = new Point(0, 0);
                    this.Controls.Add(end);
                    end.BringToFront();
                    ///code of before and after and delete acoount and close it and make hime offline
                }                    
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            reader.Close();
            con.Close();

        }
        private void get_home()
        {
            show_details();
            the_diet_sys();
        }
        private void show_details()
        {
            select_sum_query_exercise();
            select_sum_query_water();
            total_used_cal = 0;
            select_sum_query_meals("breakfast");
            select_sum_query_meals("lunch");
            select_sum_query_meals("dinner");
            select_sum_query_meals("snacks");


        }

        private void select_sum_query_exercise()
        {
            calory = 0; duration = 0;
            t = DateTime.Now;

            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * from ExerciseOfUser inner join Exercise on ExerciseOfUser.Exercise_ID=Exercise.ID inner join user_account on ExerciseOfUser.ID=user_account.ID  where user_account.id='" + Program.ID + "'order by ExerciseOfUser.Exercise_Time", con);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp = (DateTime)reader[3];
                    span = t - temp;
                    if (span.Days == diff_of_date)
                    {
                        double dur = (double)reader[2];

                        int cal = (int)reader[6];
                        double Tcal = dur * cal;
                        calory += (int)Tcal;
                        duration += (double)dur;
                    }

                }

                label2.Text = calory.ToString();
                label21.Text = duration.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            con.Close();
            reader.Close();
        }

        private void select_sum_query_water()
        {
            int water = 0;
            t = DateTime.Now;
            con.Open();
            cmd = new SqlCommand("select date,cups_of_water from user_meal where ID='" + Program.ID + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp = (DateTime)reader[0];
                span = t - temp;
                if (span.Days == diff_of_date)
                {
                    water += (int)reader[1];
                }
                label4.Text = water.ToString();
            }
            reader.Close();
            con.Close();
            ////
        }
        private void select_sum_query_meals(string type)
        {
            double break_fast = 0, lunch = 0, dinner = 0, snacks = 0;
            t = DateTime.Now;
            try
            {///"select date,calory from user_meal where ID='" + Program.ID + "'and type_of_meal ='" + type + "'"
                con.Open();
                cmd = new SqlCommand("SELECT * from user_meal inner join Meals on user_meal.meal_ID=Meals.id inner join user_account on user_meal.ID=user_account.ID  where user_account.id='" + Program.ID + "' and type_of_meal ='"+type +"'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    double quantity = (double)reader[4];
                     int calory = (int )reader[8];
                    double Tcalory = quantity * calory;
                    temp = (DateTime)reader[1];
                    span = t - temp;
                    if (span.Days == diff_of_date)
                    {
                        if (type == "breakfast")
                            break_fast += (double)Tcalory;
                        else if (type == "lunch")
                            lunch += (double)Tcalory;
                        else if (type == "dinner")
                            dinner += (double)Tcalory;
                        else
                            snacks += (double)Tcalory;

                        total_used_cal += (double)Tcalory;
                    }
                }
                if (type == "breakfast")
                    label8.Text = break_fast.ToString();
                else if (type == "lunch")
                    label6.Text = lunch.ToString();
                else if (type == "dinner")
                    label13.Text = dinner.ToString();
                else
                    label15.Text = snacks.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            reader.Close();
            con.Close();
        }
        public void the_diet_sys()
        {
            total_used_cal -= calory;
            int fi = (int)total_budget;
            int se = (int)total_used_cal;
            double val = total_used_cal / total_budget * 100;
            int v = 100 * se / fi;

            if (v > 100)
            {
                v = 100;
                MessageBox.Show("you have already exceeded the limit");
            }
            else if (v < 0)
            {
                v = 0;
                MessageBox.Show("some thing wrong check your diet system");
            }
          ///  bunifuGauge1.Value = v;
            bunifuCircleProgressbar1.Value = v;
            label11.Text = total_budget.ToString();
            label10.Text = total_used_cal.ToString();
            label17.Text = (total_budget - total_used_cal).ToString();
        }

        public void Home_Load(object sender, EventArgs e)
        {
              get_id();
              check_diet();
              get_home();


        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            //    linkLabel1.LinkVisited = true;
            //    System.Diagnostics.Process.Start("file:///C:/Users/dell/Desktop/prooooooj/WindowsFormsApplication1/GYM%20project/main%20page%20in%20gym%20site.html");
           
           
        }


    }
}
