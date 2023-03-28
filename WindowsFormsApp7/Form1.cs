using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                string query = "insert into student1 values(@rollno,@sname,@percentage)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtroll.Text));
                cmd.Parameters.AddWithValue("@sname", txtname.Text);
                cmd.Parameters.AddWithValue("@percentage", Convert.ToInt32(txtper.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
