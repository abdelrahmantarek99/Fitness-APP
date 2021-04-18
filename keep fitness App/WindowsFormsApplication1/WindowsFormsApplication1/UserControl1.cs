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
using System.Data.Sql;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class UserControl1 : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");
        SqlCommand cmd;
        public UserControl2 uc2 = new UserControl2();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            uc2.Visible = true;
            this.Controls.Add(uc2);
            uc2.Location = new Point(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserControl3 uc4 = new UserControl3();
            this.Controls.Clear();
            uc4.Visible = true;
            this.Controls.Add(uc4);
            uc4.Location = new Point(0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserControl4 uc5 = new UserControl4();
            this.Controls.Clear();
            uc5.Visible = true;
            this.Controls.Add(uc5);
            uc5.Location = new Point(0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete delete = new delete();
            this.Controls.Clear();
            delete.Visible = true;
            this.Controls.Add(delete);
            delete.Location = new Point(0, 0);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update user_account set online ='" + false + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1 f;
            f = (Form1)this.FindForm();
            f.WindowState = FormWindowState.Minimized;
        }
    }
}
