using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml.Linq;


namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        }

        private DataSet GetAllStudents()
        {
            da = new SqlDataAdapter("select * from Student1", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "student1");
            return ds;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllStudents();
                DataRow row = ds.Tables["student1"].NewRow();
                row["rollno"] = txtroll.Text;
                row["sname"] = txtname.Text;
                row["percentage"] = txtper.Text;
                // add new row in the dataset table
                ds.Tables["student1"].Rows.Add(row);
                int res = da.Update(ds.Tables["student1"]);
                if (res >= 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllStudents();
                DataRow row = ds.Tables["student1"].Rows.Find(txtroll.Text);
                if (row != null)
                {
                    txtname.Text = row["sname"].ToString();
                    txtroll.Text = row["rollno"].ToString();
                    txtper.Text = row["percentage"].ToString();
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

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllStudents();
                DataRow row = ds.Tables["student1"].Rows.Find(txtroll.Text);
                if (row != null)
                {
                    row["rollno"] = txtroll.Text;
                    row["sname"] = txtname.Text;
                    row["percentage"] = txtper.Text;
                    int res = da.Update(ds.Tables["student1"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record updated");
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

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllStudents();
                DataRow row = ds.Tables["student1"].Rows.Find(txtroll.Text);
                if (row != null)
                {
                    row.Delete();
                    int res = da.Update(ds.Tables["student1"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record deleted");
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

        }

        private void txtroll_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
