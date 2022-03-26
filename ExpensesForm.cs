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
    public partial class ExpensesForm : Form
    {
        Expensesclass expense = new Expensesclass();
        salesclass sales = new salesclass();
        public ExpensesForm()
        {
            InitializeComponent();
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            showTable();   
        }

        public void showTable()
        {
            DataGridView_expense.DataSource = expense.getExpensestList();
            DataGridView_expense.RowTemplate.Height = 100;
        }

        private void button_totalexp_Click(object sender, EventArgs e)
        {
            double my, ppd, adv, oth, ttlexp;
            double.TryParse(textBox_mayur.Text, out my);
            double.TryParse(textBox_patpedi.Text, out ppd);
            double.TryParse(textBox_advance.Text, out adv);
            double.TryParse(textBox_other.Text, out oth);

            ttlexp = my + ppd + adv + oth;
            textBox_totalexp.Text = ttlexp.ToString();

        }

        private void button_addexpense_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker_date3.Value;
            double mayur = Convert.ToDouble(textBox_mayur.Text);
            double patpedi = Convert.ToDouble(textBox_patpedi.Text);
            double advance = Convert.ToDouble(textBox_advance.Text);
            string advdetails = textBox_advdetails.Text;
            double other = Convert.ToDouble(textBox_other.Text);
            string othdetails = textBox_othrdetails.Text;
            double totalexp = Convert.ToDouble(textBox_totalexp.Text);
            
            if (verify())
            {
                try
                {
                    if (expense.insertExpense(date, mayur, patpedi, advance, advdetails, other,othdetails,totalexp))
                    {
                        MessageBox.Show("Expense details for the day added", "Add Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Expenses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        bool verify()
        {
            if ((textBox_advance.Text == "") || (textBox_advdetails.Text == "") || (textBox_mayur.Text == "") || (textBox_other.Text == "") || (textBox_othrdetails.Text == "")||(textBox_patpedi.Text=="")||(textBox_totalexp.Text==""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button_clearexpense_Click(object sender, EventArgs e)
        {
            
        }

        public void function()
        {
            var frm = this.Owner;
            var ctl = frm.Controls.Find("textBox_expense", true).FirstOrDefault() as Control;
            TextBox txt = (TextBox)ctl;
        }
    }
}
