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
    public partial class ManageEmployeeForm : Form
    {
        Employeeclass emp = new Employeeclass();
        public ManageEmployeeForm()
        {
            InitializeComponent();
        }

        private void ManageEmployeeForm_Load(object sender, EventArgs e)
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
        // Display employee data from employee to textbox
        private void DataGridView_employee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Id.Text = DataGridView_employee.CurrentRow.Cells[0].Value.ToString();
            textBox_name.Text= DataGridView_employee.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker_dob.Value = (DateTime)DataGridView_employee.CurrentRow.Cells[2].Value;
            if (DataGridView_employee.CurrentRow.Cells[3].Value.ToString() == "Male")
            {
                radioButton_male.Checked = true;
            }
            textBox_phno.Text = DataGridView_employee.CurrentRow.Cells[4].Value.ToString();
            textBox_add.Text = DataGridView_employee.CurrentRow.Cells[5].Value.ToString();
            textBox_shift.Text = DataGridView_employee.CurrentRow.Cells[6].Value.ToString();
            textBox_salary.Text= DataGridView_employee.CurrentRow.Cells[7].Value.ToString();
            textBox_balsalary.Text = DataGridView_employee.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker_saldate.Value = (DateTime)DataGridView_employee.CurrentRow.Cells[9].Value;
            byte[] img=(byte[]) DataGridView_employee.CurrentRow.Cells[10].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox_photo.Image = Image.FromStream(ms);


        }

        private void button_clear2_Click(object sender, EventArgs e)
        {
            textBox_name.Clear();
            textBox_salary.Clear();
            textBox_balsalary.Clear();
            textBox_phno.Clear();
            textBox_add.Clear();
            textBox_shift.Clear();
            textBox_Id.Clear();     
            pictureBox_photo.Image = null;
            dateTimePicker_dob.Value = DateTime.Now;
            dateTimePicker_saldate.Value = DateTime.Now;
            radioButton_male.Checked = true;
        }

        private void button_upload2_Click(object sender, EventArgs e)
        {
            //browse photo
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_photo.Image = Image.FromFile(opf.FileName);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_employee.DataSource = emp.searchEmployee(textBox_search.Text);
            DataGridView_employee.RowTemplate.Height = 100;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_employee.Columns[10];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        bool verify()
        {
            if ((textBox_name.Text == "") || (textBox_salary.Text == "") || (textBox_phno.Text == "") || (textBox_add.Text == "") || (pictureBox_photo.Image == null) || (textBox_shift.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button_update_Click(object sender, EventArgs e)
        {

            // update employee
            int id = Convert.ToInt32(textBox_Id.Text);
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
                    MessageBox.Show("The employee must be between 16 to 44 ", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verify())
                {
                    try
                    {
                        //get photo from picturebox
                        MemoryStream im = new MemoryStream();
                        pictureBox_photo.Image.Save(im, pictureBox_photo.Image.RawFormat);
                        byte[] img = im.ToArray();
                        if (emp.updateEmployee(id, name, bdate, gender, phone, address, shift, salary, balsalary, saldate, img))
                        {
                            MessageBox.Show("Employee Details Updated", "Employee Updation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Empty Field", "Employee Updation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }
        //to delete an employee record

        private void button_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_Id.Text);
            if(MessageBox.Show("Are you sure you want to remove this employee","Remove Employee",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(emp.deleteEmployee(id))
                {
                    ShowTable();
                    MessageBox.Show("Student Removed","Remove Student",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    button_clear2.PerformClick();
                }
            }
        }
    }
}
