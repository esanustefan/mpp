using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baschet
{
    public partial class Form1 : Form
    {
        private Service.Service mysService;
        public Form1(Service.Service service)
        {
            InitializeComponent();
            setService(service);
        }
        
        public void setService(Service.Service service)
        {
            this.mysService = service;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = passwordTextBox.Text;
            if (mysService.CheckifUserExists(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Login failed!");
            }
            //if login successful, open form2
            Form2 form2 = new Form2(mysService);
            form2.Show();
        }
        
        
    }
}