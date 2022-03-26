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
    public partial class Main_form : Form
    {
        Employeeclass employee = new Employeeclass();
        public Main_form()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display the value 
            employeeCount();
        }

        // a function to display employee count
        private void employeeCount()
        {
            label_totalEmployee.Text = "Total Employees :" + employee.totalEmployee();
            label_totalMale.Text = "Male : " + employee.totalMaleEmployee();
            label_TotalFemale.Text = "Female :" + employee.totalFemaleEmployee();
        }
        private void customizeDesign()
        {
            panel_empsubmenu.Visible = false;
            panel_sales.Visible = false;
            panel_expenses.Visible = false;

        }
        private void hideSubmenu()
        {
            if (panel_empsubmenu.Visible == true)
                panel_empsubmenu.Visible = false;
            
            if (panel_sales.Visible == true)
                panel_sales.Visible = false;
            
            if (panel_expenses.Visible == true)
                panel_expenses.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_emp_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_empsubmenu);
        }

        #region employee 
        private void button_addemp_Click(object sender, EventArgs e)
        {
            openChildform(new RegistrationForm());
            //add code
            hideSubmenu();
        }

        private void button_mngemp_Click(object sender, EventArgs e)
        {
            openChildform(new ManageEmployeeForm());
            //add code
            hideSubmenu();
        }

        private void button_empsal_Click(object sender, EventArgs e)
        {
            //add code
            hideSubmenu();
        }

        private void button_printemp_Click(object sender, EventArgs e)
        {
            //add code
            
            hideSubmenu();
        }
        #endregion employee
        private void button_sales_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_sales);
        }
        #region sales
        private void button_addsales_Click(object sender, EventArgs e)
        {
            //add code
            openChildform(new AddDailySalesForm());
            hideSubmenu();
        }

        private void button_mngsales_Click(object sender, EventArgs e)
        {
            //add code
            openChildform(new ManageSalesForm());
            hideSubmenu();
        }

        private void button_printsales_Click(object sender, EventArgs e)
        {
            //add code
            hideSubmenu();
        }
        #endregion sales
        private void button_exp_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_expenses);
        }
        #region expenses
        private void button_addexp_Click(object sender, EventArgs e)
        {
            //add code
            openChildform(new ExpensesForm());
            hideSubmenu();
        }

        private void button_mngexp_Click(object sender, EventArgs e)
        {
            //add code
            openChildform(new ManageExpensesForm());
            hideSubmenu();
        }

        private void button_printexp_Click(object sender, EventArgs e)
        {
            //add code
            hideSubmenu();
        }
        #endregion expenses

        //to show register form in main form
        private Form activeForm = null;
        private void openChildform(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void button_dashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                panel_main.Controls.Add(panel_cover);
            }
            employeeCount();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
        }

        private void label_totalEmployee_Click(object sender, EventArgs e)
        {

        }

        private void button_printemp_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
        }
    }
}
