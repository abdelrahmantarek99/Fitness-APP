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
    public partial class notes_UC : UserControl
    {
        int id;
        public int index = 0;
        int clk = 0;
        public string saved;
        public bool isclicked = false;
        public Label l;
        string the_selected_item;
        Notes2_UC Notes2_ = new Notes2_UC();

        public notes_UC()
        {
            InitializeComponent();
            FillListBox();

        }
        SqlConnection connection = new SqlConnection("Data Source = DESKTOP-GB8C9AV\\SQLEXPRESS; Initial Catalog = Project.Sc ; Integrated Security =true");

        public void FillListBox()
        {
            int count = 0;

            connection.Open();
            string q = " SELECT date from Notes where ID ='" + Program.ID + "'";
            SqlCommand com = new SqlCommand(q, connection);
            SqlDataReader reader = com.ExecuteReader();
            NotesList.Items.Clear();
            while (reader.Read())
            {
                count++;
                l = new Label();
                l.Text = "NOTE " + count + ":";
                if (count <= 9)
                {
                    NotesList.Items.Add(l.Text + "                               " + reader["date"].ToString());
                }
                else if (count > 9)
                    NotesList.Items.Add(l.Text + "                             " + reader["date"].ToString());


            }


            reader.Close();
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (isclicked == true)
            {

                connection.Open();
                the_selected_item = saved.Remove(0, (l.Text.Length) + 2);
                try
                {
                    string q = " SELECT discription from Notes where date ='" + the_selected_item.ToString() + "' and ID='" + Program.ID + "'";
                    SqlCommand com = new SqlCommand(q, connection);
                    com.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Notes2_.NotesTextbox.Text = dr["discription"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();

                Notes2_.NotesTextbox.Size = new System.Drawing.Size(565, 338);
                Notes2_.NotesTextbox.Location = new Point(1, 87);
                Notes2_.label1.Text = "This is Your Note in :\n" + the_selected_item.ToString();
                Notes2_.label1.Visible = true;
                Notes2_.WhichOne(3, the_selected_item);
                Notes2_.SaveNoteeBtn.Text = "Back";
                Notes2_.NotesTextbox.ReadOnly = true;
                Notes2_.NotesTextbox.BackColor = Color.White;
                this.Controls.Clear();
                this.Controls.Add(Notes2_);
                Notes2_.Location = new Point(0, 0);

            }
            isclicked = false;

        }

        private void AddNotesBtn_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Notes2_UC notes2_UC = new Notes2_UC();
            notes2_UC.WhichOne(1, the_selected_item);
            notes2_UC.Location = new Point(0, 0);
            this.Controls.Add(notes2_UC);
        }

        private void EditeNotesBtn_Click(object sender, EventArgs e)
        {
            if (isclicked == true)
            {


                connection.Open();
                the_selected_item = saved.Remove(0, (l.Text.Length) + 2);
                try
                {
                    string q = " SELECT discription from Notes where date ='" + the_selected_item.ToString() + "' and ID='" + Program.ID+ "'";
                    SqlCommand com = new SqlCommand(q, connection);
                    com.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Notes2_.NotesTextbox.Text = dr["discription"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();


                Notes2_.NotesTextbox.Size = new System.Drawing.Size(639, 385);
                Notes2_.NotesTextbox.Location = new Point(1, 1);
                Notes2_.label1.Visible = false;
                Notes2_.WhichOne(2, the_selected_item);
                this.Controls.Clear();
                this.Controls.Add(Notes2_);
                Notes2_.Location = new Point(0, 0);
            }
            isclicked = false;
        }

        private void DeleteNotesBtn_Click(object sender, EventArgs e)
        {

            if (isclicked == true)
            {
                connection.Open();
                the_selected_item = saved.Remove(0, (l.Text.Length) + 2);
                string q = " DELETE from Notes where date ='" + the_selected_item.ToString() + "' and ID =" +
                    "'" + Program.ID + "'";
                SqlCommand com1 = new SqlCommand(q, connection);
                com1.ExecuteNonQuery();
                connection.Close();
                FillListBox();
            }
            isclicked = false;
        }

        private void NotesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (NotesList.SelectedItem != null)
                {
                    isclicked = true;
                    clk++;
                    saved = NotesList.SelectedItem.ToString();
                    the_selected_item = (NotesList.SelectedItem.ToString()).Remove(0, (l.Text.Length) + 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void notes_UC_Load(object sender, EventArgs e)
        {
            FillListBox();
        }
    }
}
