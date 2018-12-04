using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       DataTable dt;
       DataRow dr;
        //string code;
       //DataColumn dc;

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 v = new Form2();
            v.Close();
           
            // TODO: This line of code loads data into the 'appDataSet5.Expense' table. You can move, or remove it, as needed.
            //this.expenseTableAdapter1.Fill(this.appDataSet5.Expense);
            // TODO: This line of code loads data into the 'appDataSet4.Expense' table. You can move, or remove it, as needed.
            //this.expenseTableAdapter.Fill(this.appDataSet4.Expense);
            // TODO: This line of code loads data into the 'appDataSet3.Income' table. You can move, or remove it, as needed.
            //this.incomeTableAdapter7.Fill(this.appDataSet3.Income);
            // TODO: This line of code loads data into the 'appDataSet2.Income' table. You can move, or remove it, as needed.
           // this.incomeTableAdapter6.Fill(this.appDataSet2.Income);
            // TODO: This line of code loads data into the 'appDataSet11.Income' table. You can move, or remove it, as needed.
            //this.incomeTableAdapter5.Fill(this.appDataSet11.Income);
            // TODO: This line of code loads data into the 'appDataSet.Income' table. You can move, or remove it, as needed.
            //this.incomeTableAdapter4.Fill(this.appDataSet.Income);
            // TODO: This line of code loads data into the 'expn_managerDataSet.Income' table. You can move, or remove it, as needed.
        
            
        
        }

        private void label5_Click(object sender, EventArgs e)
        {
           

        }

     

        private void button7_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
          
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\App.mdf;Integrated Security=True;User Instance=True";
                cn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from Income", cn);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet("Income");
                adapter.Fill(ds, "Income");
                DataRow row = ds.Tables["Income"].NewRow();
                row["Date"] = textBox1.Text;
                row["Amount"] = textBox2.Text;
                row["Payer"] = textBox3.Text;
                row["Category"] = comboBox1.SelectedItem;
                row["Payment Method"] = comboBox2.SelectedItem;
                row["Ref No"] = textBox6.Text;
                row["Description"] = textBox7.Text;
                row["Tax"] = textBox8.Text;
                ds.Tables["Income"].Rows.Add(row);
                adapter.Update(ds, "Income");
                cn.Close();
                label23.Text = "";
                MessageBox.Show("Details Entered Sucessfully ....");
                
            }
            catch
            {
                if (textBox1.Text != null)
                {
                    label23.Text = "Please fill the required data";
                    label23.ForeColor = Color.Red;
                }
             
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = textBox1.Text;
            dr = appDataSet3.Tables["Income"].Rows.Find(code);
            dr.Delete();
            incomeTableAdapter7.Update(appDataSet3);
            MessageBox.Show("Details deleted successfully");

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\App.mdf;Integrated Security=True;User Instance=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand("select SUM(Amount) from Income", cn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int tot;
                tot = Convert.ToInt32(sdr.GetSqlValue(0).ToString());
                textBox9.Text = tot.ToString();
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            dt = appDataSet3.Tables["Income"];
            incomeTableAdapter7.Update(appDataSet3);
            cmdUpdate.Enabled = true;
            MessageBox.Show("Details are updated successfully");
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s;
            float d, minus;
            s = int.Parse(textBox9.Text);
            d = float.Parse(textBox18.Text);
            minus = s - d;
            textBox19.Text = minus.ToString();
            if (s > d) 
            {
                textBox19.ForeColor = Color.Green;
            }
            else
            {
                textBox19.ForeColor = Color.Red;
            }


        }

        private void cmdExAdd_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\App.mdf;Integrated Security=True;User Instance=True";
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Expense", cn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet("Expense");
            sda.Fill(ds, "Expense");
            DataRow dr = ds.Tables["Expense"].NewRow(); 
            dr["Date"] = textBox10.Text;
            dr["Amount"] = textBox11.Text;
            dr["Payee"] = textBox12.Text;
            dr["Category"] = comboBox4.SelectedItem;
            dr["Payment Method"] = comboBox5.SelectedItem;
            dr["Ref No"] = textBox15.Text;
            dr["Description"] = textBox16.Text;
            dr["Tax"] = textBox17.Text;
            ds.Tables["Expense"].Rows.Add(dr);
            sda.Update(ds,"Expense");
            cn.Close();
            MessageBox.Show("Details of Expenses added successfully");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string code;
            code = textBox10.Text;
            dr = appDataSet5.Tables["Expense"].Rows.Find(code);
            dr.Delete();
            expenseTableAdapter1.Update(appDataSet5);
            MessageBox.Show("Details deleted successfully");
        }

        private void cmdExupdate_Click(object sender, EventArgs e)
        {
            dt = appDataSet5.Tables["Expense"];
            expenseTableAdapter1.Update(appDataSet5);
            MessageBox.Show("Details of Expenses updated successfully"); 
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\App.mdf;Integrated Security=True;User Instance=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand("select SUM(Amount) from Expense", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox18.Text = reader.GetSqlValue(0).ToString();

            }
           
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            int s;
            float d, minus;
            s = int.Parse(textBox9.Text);
            d = float.Parse(textBox18.Text);
            minus = s - d;
           
            /*
           
            */
        }

       

       
        
        
    }
}
