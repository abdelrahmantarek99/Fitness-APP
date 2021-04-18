using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class toka : UserControl
    {

        public Uc_log loginpage = new Uc_log();
        public Uc_reg registerpage = new Uc_reg();

        forget_pass forget = new forget_pass();
        static String sql = "Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true";
        SqlConnection connection = new SqlConnection(sql);
        public toka()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form;
            form = (Form1)this.FindForm();
          //  form.back.Visible = true;
          //  form.back.BringToFront();
            loginpage.Visible = true;
            this.Controls.Clear();
            this.Controls.Add(loginpage);
            loginpage.Location = new Point(0, 0);
            loginpage.BringToFront();
            //Program.v2 = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form;
            form = (Form1)this.FindForm();
            form.Show();
            this.Controls.Clear();
            this.Controls.Add(registerpage);
            registerpage.BringToFront();
            registerpage.Visible = true;
        }

        private void toka_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Uc_info ingg =new Uc_info();
            this.Controls.Add(ingg);
            ingg.BringToFront();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
