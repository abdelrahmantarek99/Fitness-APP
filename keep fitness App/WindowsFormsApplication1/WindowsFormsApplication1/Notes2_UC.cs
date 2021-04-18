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
    public partial class Notes2_UC : UserControl
    {
        int id;
        public string Discription;
        public int sent;
        public bool IsSaveBtnCLicked = false;
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");

        public Notes2_UC()
        {
            InitializeComponent();
        }
        public void WhichOne(int pressed, string getst)
        {
            sent = pressed;
            Discription = getst;
        }

        private void SaveNoteeBtn_Click(object sender, EventArgs e)
        {

            notes_UC notes_UC = new notes_UC();
            if (sent == 1)
            {

                if (NotesTextbox.Text == " ")
                {
                    MessageBox.Show("Write Something !!");
                }
                else
                {
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {

                        string q = " INSERT INTO Notes(ID,date,discription)values(  '" + Program.ID + "','" + DateTime.Now + "','" + NotesTextbox.Text + "') ";
                        SqlCommand com = new SqlCommand(q, connection);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Data Saved");

                    }
                    connection.Close();
                }
            }
            else if (sent == 2)
            {

                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {

                    string q = " UPDATE Notes SET discription =( '" + NotesTextbox.Text + "') WHERE  date='" + Discription + "' and ID='" + Program.ID + "'";
                    SqlCommand com = new SqlCommand(q, connection);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Data Saved");

                }
                connection.Close();


            }
            try
            {
                notes_UC.FillListBox();
                this.Controls.Clear();
                this.Controls.Add(notes_UC);
                notes_UC.Location = new Point(0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Notes2_UC_Load(object sender, EventArgs e)
        {

        }
    }
}
