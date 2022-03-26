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
    public partial class ManageSalesForm : Form
    {
        salesclass sal = new salesclass();
        public ManageSalesForm()
        {
            InitializeComponent();
        }

        private void ManageSales_Load(object sender, EventArgs e)
        {
            ShowTable2();   
        }
        public void ShowTable2()
        {
            DataGridView_managesales.DataSource = sal.getSalestList();
            DataGridView_managesales.RowTemplate.Height = 100;
        }

        // display the data in the textbox from the grid view
        private void DataGridView_managesales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_salesID.Text = DataGridView_managesales.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker_date.Value = (DateTime)DataGridView_managesales.CurrentRow.Cells[1].Value;
            textBox_openfund.Text = DataGridView_managesales.CurrentRow.Cells[2].Value.ToString();
            textBox_expense.Text = DataGridView_managesales.CurrentRow.Cells[3].Value.ToString();
            textBox_upi.Text= DataGridView_managesales.CurrentRow.Cells[4].Value.ToString();
            textBox_closingfund.Text = DataGridView_managesales.CurrentRow.Cells[5].Value.ToString();
            textBox_sales.Text = DataGridView_managesales.CurrentRow.Cells[6].Value.ToString();
        }

        private void button_clearsales2_Click(object sender, EventArgs e)
        {
            textBox_closingfund.Clear();
            textBox_expense.Clear();
            textBox_openfund.Clear();
            textBox_sales.Clear();
            textBox_upi.Clear();
            textBox_salesID.Clear();
            dateTimePicker_date.Value = DateTime.Now;

        }
        // to update the sales 
        private void button_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_salesID.Text);
            DateTime date = dateTimePicker_date.Value;
            double ofund = Convert.ToDouble(textBox_openfund.Text);
            double expenses = Convert.ToDouble(textBox_expense.Text);
            double upi = Convert.ToDouble(textBox_upi.Text);
            double cfund = Convert.ToDouble(textBox_closingfund.Text);
            double sales = Convert.ToDouble(textBox_sales.Text);

            if (verify())
            {
                try
                {
                    if (sal.updateSales(id,date, ofund, expenses, upi, cfund, sales))
                    {
                        MessageBox.Show("Sales for the day updated", "Update Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        bool verify()
        {
            if ((textBox_salesID.Text=="")||(textBox_closingfund.Text == "") || (textBox_expense.Text == "") || (textBox_openfund.Text == "") || (textBox_sales.Text == "") || (textBox_upi.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button_calcsales_Click(object sender, EventArgs e)
        {
            double of, exp, upi, cf, sales, factor;
            double.TryParse(textBox_openfund.Text, out of);
            double.TryParse(textBox_expense.Text, out exp);
            double.TryParse(textBox_upi.Text, out upi);
            double.TryParse(textBox_closingfund.Text, out cf);
            double.TryParse(textBox_sales.Text, out sales);
            factor = of - exp - upi;


            if (factor >= 0)
            {

                sales = cf - factor;
                textBox_sales.Text = sales.ToString();
            }
            else if (factor < 0)
            {
                double a;
                a = factor * -1;
                sales = a + cf;
                textBox_sales.Text = sales.ToString();
            }
        }

        private void button_searchSales_Click(object sender, EventArgs e)
        {
            DateTime searchdate = dateTimePicker_search.Value;
            string strsearchdate = searchdate.ToString("yyyy-MM-dd");
            DataGridView_managesales.DataSource = sal.searchSales(strsearchdate);
            DataGridView_managesales.RowTemplate.Height = 100;
        }
    }
}
