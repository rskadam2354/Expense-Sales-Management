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

namespace employee_payroll_management
{
    public partial class ManageExpensesForm : Form
    {
        Expensesclass expense = new Expensesclass();
        public ManageExpensesForm()
        {
            InitializeComponent();
        }

        private void ManageExpensesForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            DataGridView_manageexpense.DataSource = expense.getExpensestList();
            DataGridView_manageexpense.RowTemplate.Height = 100;
        }

        private void button_updateexpense_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_expid.Text);
            DateTime date = dateTimePicker_datemanage.Value;
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
                    if (expense.updateExpense(id,date, mayur, patpedi, advance, advdetails, other, othdetails, totalexp))
                    {
                        MessageBox.Show("Expense details for the day updated", "Update Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update Expenses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool verify()
        {
            if ((textBox_expid.Text=="")||(textBox_advance.Text == "") || (textBox_advdetails.Text == "") || (textBox_mayur.Text == "") || (textBox_other.Text == "") || (textBox_othrdetails.Text == "") || (textBox_patpedi.Text == "") || (textBox_totalexp.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button_searchExpenses_Click(object sender, EventArgs e)
        {
            DateTime searchdate = dateTimePicker_searchexp.Value;
            string strsearchdate = searchdate.ToString("yyyy-MM-dd");
            DataGridView_manageexpense.DataSource = expense.searchExpensedate(strsearchdate);
            DataGridView_manageexpense.RowTemplate.Height = 100;
        }

        private void button_clearexpense_Click(object sender, EventArgs e)
        {
            textBox_advance.Clear();
            textBox_advdetails.Clear();
            textBox_expid.Clear();
            textBox_mayur.Clear();
            textBox_other.Clear();
            textBox_othrdetails.Clear();
            textBox_patpedi.Clear();
            textBox_totalexp.Clear();
            dateTimePicker_datemanage.Value = DateTime.Now;
        }

        private void DataGridView_manageexpense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                        
                textBox_expid.Text = DataGridView_manageexpense.CurrentRow.Cells[0].Value.ToString();
                dateTimePicker_datemanage.Value = (DateTime)DataGridView_manageexpense.CurrentRow.Cells[1].Value;
                textBox_mayur.Text = DataGridView_manageexpense.CurrentRow.Cells[2].Value.ToString();
                textBox_patpedi.Text = DataGridView_manageexpense.CurrentRow.Cells[3].Value.ToString();
                textBox_advance.Text = DataGridView_manageexpense.CurrentRow.Cells[4].Value.ToString();
                textBox_advdetails.Text = DataGridView_manageexpense.CurrentRow.Cells[5].Value.ToString();
                textBox_other.Text = DataGridView_manageexpense.CurrentRow.Cells[6].Value.ToString();
                textBox_othrdetails.Text = DataGridView_manageexpense.CurrentRow.Cells[7].Value.ToString();
                textBox_totalexp.Text = DataGridView_manageexpense.CurrentRow.Cells[8].Value.ToString();

        }

        private void button_searchDetails_Click(object sender, EventArgs e)
        {
            DataGridView_manageexpense.DataSource = expense.searchExpenseDetails(textBox_searchExpenseDetails.Text);
            DataGridView_manageexpense.RowTemplate.Height = 100;
        }
    }
}
