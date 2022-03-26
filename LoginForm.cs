using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employee_payroll_management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox_usrname.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string user, pass;
                user = textBox_usrname.Text;
                pass = textBox_password.Text;
                if(user=="admin"&&pass=="admin")
                {
                    Main_form main = new Main_form();
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Your Username & Password does not exists", "wrong login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

               
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
