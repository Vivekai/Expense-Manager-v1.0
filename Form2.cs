using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(ValidateChildren(ValidationConstraints.Enabled))
           {
               //MessageBox.Show(textBox1.Text, "demo app!");
               Form1 f = new Form1();
               f.Show();
           }
       
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
          if(string.IsNullOrWhiteSpace(textBox1.Text))
          {
              e.Cancel = true;
              textBox1.Focus();
              errorProvider1.SetError(textBox1,"Username is required");
              errorProvider1.SetError(textBox2, "password is required");
          }   
          else
          {
              e.Cancel = false;
              errorProvider1.SetError(textBox1,"");
              errorProvider1.SetError(textBox2, "");
          }
        
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Password is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }
        }
    
            /*
            {
                
            }
            else if (textBox2.TextLength >= 8)
            {
                MessageBox.Show("password should be equal to 8 characters and accepts alpha numeric characters");
            }
            else
            {
                Form1 f = new Form1();
                f.Show();
            }
            */
            
        }

        
    }

