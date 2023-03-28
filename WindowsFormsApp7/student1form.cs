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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from student1 where rollno=@rollno";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtroll.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtname.Text = dr["sname"].ToString();
                        txtper.Text = dr["percentage"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "update student1 set sname=@sname,percentage= @percentage where rollno=@rollno";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sname", txtname.Text);
                cmd.Parameters.AddWithValue("@percentage", Convert.ToInt32(txtper.Text));
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtroll.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record updated..");
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from student1 where rollno=@rollno";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rollno", Convert.ToInt32(txtroll.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >= 1)
                {
                    MessageBox.Show("Record deleted..");
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
