using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        UserControl1 uc1 = new UserControl1();
        Uc_end end = new Uc_end();
        Uc_log loginpage = new Uc_log();
        Home hom = new Home();
        Uc_reg registerpage = new Uc_reg();
        forget_pass forget = new forget_pass();
         ///start2 s = new start2();
        toka tt = new toka();
        Rate_feedback rate = new Rate_feedback();
        Meals meals = new Meals();
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        SqlDataReader reader;
        DateTime t;
        DateTime temp;
        TimeSpan span;
        public double total_used_cal, total_budget = 10000, calory = 0, duration = 0;
        public int diff_of_date;
        before_and_after bf = new before_and_after();
        MyAccount_Uc acc = new MyAccount_Uc();
        Notes2_UC notes2 = new Notes2_UC();
        notes_UC notes = new notes_UC();
        Weight_chart_UC weight = new Weight_chart_UC();
        History_UC history = new History_UC();
        Meals_Hist_UC meals_UC = new Meals_Hist_UC();
        Excersise_UC excersise = new Excersise_UC();
        public string History;
        public Form1()
        {
            InitializeComponent();
            loginpage.Visible = false;
            registerpage.Visible = false;
            forget.Visible = false;
         

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

      /*  private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            if (Program.v1 == 1)
            {
                Program.v1 = 0;
                MessageBox.Show("reg");
                Program.reg.Hide();
                Program.s.Location = new Point(0, 0);
                this.Controls.Add(Program.s);
                Program.s.BringToFront();



            }
            else if (Program.v2==1)
            {
                Program.log.Hide();
               //panel1.SendToBack();
               
                //s.BringToFront();
                /* Program.log.Controls.Clear();
                 Program.s.Location = new Point(0, 0);
                 this.Controls.Add(Program.s);
                 Program.s.BringToFront();*/


                /* Program.s.Show();
                 Program.log.SendToBack();
                 Program.log.Hide();*/
               
        /////////Program.v2 = 0;

                /*Program.v2 = 0;
                Program.log.SendToBack();
                MessageBox.Show("log");
                
                this.Controls.Add(Program.s);
                Program.s.BringToFront();
              //  Program.log.Controls.Clear();*/

/*
            }
        }
*/
        private void back_Click(object sender, EventArgs e)
        {
            /*if (Program.v2==1)
            {
                while (Program.v2!=0)
                {
                    loginpage.Visible = false;
                    Program.log.Controls.Clear();
                    Program.log.SendToBack();
                    Program.s.Location = new Point(0, 0);
                    this.Controls.Add(Program.s);
                    Program.s.BringToFront();
                    Program.v2 = 0;
                }

            }*/
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            excersise.Location = new Point(175, 0);
            this.Controls.Add(excersise);
            excersise.BringToFront();
        }

        private void before_aft_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            bf.Location = new Point(175, 0);
            this.Controls.Add(bf);
            bf.BringToFront();
          
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            acc.Location = new Point(175, 0);
            this.Controls.Add(acc);
            acc.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            weight.Location = new Point(175, 0);
            this.Controls.Add(weight);
            weight.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            acc.SendToBack();
            end.SendToBack();
            weight.SendToBack();
            notes.SendToBack();
            history.SendToBack();
            meals.SendToBack();
            rate.SendToBack();
            bf.SendToBack();
            excersise.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            hom.Location = new Point(172, 0);
            this.Controls.Add(hom);
            hom.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            meals.Location = new Point(175, 0);
            this.Controls.Add(meals);
            meals.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            notes.Location = new Point(175, 0);
            this.Controls.Add(notes);
            notes.BringToFront();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            meals_UC.Location = new Point(175, 0);
            this.Controls.Add(meals_UC);
            meals_UC.BringToFront();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            rate.Location = new Point(175, 0);
            this.Controls.Add(rate);
            rate.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            hom.SendToBack();
            panel2.Show();
            panel2.BringToFront();
            history.Location = new Point(175, 0);
            this.Controls.Add(history);
            history.BringToFront();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            get_id();
            if (Program.ID == 0)
            {
                MessageBox.Show("login");
               tt.Location = new Point(0, 0);
               this.Controls.Add(tt);
               tt.BringToFront();
    
            }
            else if(Program.status==false)
            {
                MessageBox.Show(Program.ID + "");
                this.Controls.Add(hom);
                hom.BringToFront();
            }
            else
            {
                uc1.Location = new Point(0, 0);
                this.Controls.Add(uc1);
                uc1.BringToFront();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Click Yes if you want to logout from your email  ","Exit",MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                con.Open();
                cmd =new SqlCommand("update user_account set online ='"+false+"'",con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            this.Close();
           
        }
    }
}
