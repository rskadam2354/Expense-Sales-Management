using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace employee_payroll_management
{
    public partial class RegistrationForm : Form
    {
        Employeeclass emp = new Employeeclass();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            //browse photo
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_photo.Image = Image.FromFile(opf.FileName);

            
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // add new employee
            string name = textBox_name.Text;
            string salary = textBox_salary.Text;
            DateTime bdate = dateTimePicker_dob.Value;
            DateTime saldate = dateTimePicker_saldate.Value;
            string balsalary = textBox_balsalary.Text;
            string phone = textBox_phno.Text;
            string address = textBox_add.Text;
            string gender = radioButton_male.Checked ? "Male" : "Female";
            string shift = textBox_shift.Text;
            

            int born_year = dateTimePicker_dob.Value.Year;
            int this_year = DateTime.Now.Year;
            if((this_year-born_year)<16 || (this_year - born_year) > 45)
            {
                ShowTable();
                MessageBox.Show("The employee must be not between 16 to 44 ", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {
                    //get photo from picturebox
                    MemoryStream ms = new MemoryStream();
                    pictureBox_photo.Image.Save(ms, pictureBox_photo.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (emp.insertEmployee(name, bdate, gender, phone, address, shift, salary, balsalary,saldate,img))
                    {
                        MessageBox.Show("New Employee Added", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
        
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        bool verify()
        {
            if((textBox_balsalary.Text=="")||(textBox_name.Text=="")||(textBox_salary.Text=="")||(textBox_phno.Text=="")||(textBox_add.Text=="")||(pictureBox_photo.Image == null)||(textBox_shift.Text==""))
                    {
                return false;
                    }
            else
            {
                return true;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            // clear data entered
            textBox_balsalary.Clear();
            textBox_name.Clear();
            textBox_salary.Clear();
            textBox_phno.Clear();
            textBox_add.Clear();
            textBox_shift.Clear();
            pictureBox_photo.Image=null;
            textBox_shift.Clear();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            ShowTable();
        }

        // To show employee list in datgridView
       public void ShowTable()
        {
            DataGridView_employee.DataSource = emp.getEmployeeList(new MySqlCommand("SELECT * FROM 'employee'"));
            DataGridView_employee.RowTemplate.Height = 100;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_employee.Columns[10];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_upload_Click_1(object sender, EventArgs e)
        {
            //browse photo
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_photo.Image = Image.FromFile(opf.FileName);
        }

        private void button_clear_Click_1(object sender, EventArgs e)
        {
            // clear data entered
            textBox_name.Clear();
            textBox_salary.Clear();
            textBox_phno.Clear();
            textBox_add.Clear();
            textBox_shift.Clear();
            pictureBox_photo.Image = null;
            textBox_shift.Clear();
        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            // add new employee
            string name = textBox_name.Text;
            string salary = textBox_salary.Text;
            string balsalary = textBox_balsalary.Text;
            DateTime bdate = dateTimePicker_dob.Value;
            DateTime saldate = dateTimePicker_saldate.Value;
            string phone = textBox_phno.Text;
            string address = textBox_add.Text;
            string gender = radioButton_male.Checked ? "Male" : "Female";
            string shift = textBox_shift.Text;


            int born_year = dateTimePicker_dob.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 16 || (this_year - born_year) > 45)
            {
                ShowTable();
                MessageBox.Show("The employee must be not between 16 to 44 ", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {
                    //get photo from picturebox
                    MemoryStream ms = new MemoryStream();
                    pictureBox_photo.Image.Save(ms, pictureBox_photo.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (emp.insertEmployee(name,bdate,gender, phone, address, shift, salary, balsalary, saldate, img))
                    {
                        MessageBox.Show("New Employee Added", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DataGridView_employee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
