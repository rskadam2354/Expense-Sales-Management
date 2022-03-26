using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace employee_payroll_management
{
    

    public partial class AddDailySalesForm : Form
    {
        public static string abc = "";
        salesclass sal = new salesclass();
        public AddDailySalesForm()
        {
            InitializeComponent();
        }

        private void button_calcsales_Click(object sender, EventArgs e)
        {
            double of, exp, upi, cf,sales,factor;
            double.TryParse(textBox_openfund.Text, out of);
            double.TryParse(textBox_expense.Text, out exp);
            double.TryParse(textBox_upi.Text, out upi);
            double.TryParse(textBox_closingfund.Text, out cf);
            double.TryParse(textBox_sales.Text, out sales);
            factor = of - exp - upi ;
            

            if(factor>=0)
            {
                
                sales =  cf - factor;
                textBox_sales.Text = sales.ToString();
            }
            else if(factor<0)
            {
                double a;
                a = factor * -1;
                sales = a + cf;
                textBox_sales.Text = sales.ToString();
            }

        }
       

        private void button_addsales_Click(object sender, EventArgs e)
        {
            DateTime date  = dateTimePicker_date.Value;
            double  ofund= Convert.ToDouble (textBox_openfund.Text);
            double  expenses=Convert.ToDouble(textBox_expense.Text);
            double upi = Convert.ToDouble(textBox_upi.Text);
            double cfund =Convert.ToDouble(textBox_closingfund.Text);
            double sales =Convert.ToDouble(textBox_sales.Text);

            if(verify())
            {
                try
                {
                    if (sal.insertSales(date,ofund,expenses,upi,cfund,sales))
                    {
                        MessageBox.Show("Sales for the day added", "Add Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool verify()
        {
            if ((textBox_closingfund.Text == "") || (textBox_expense.Text == "") || (textBox_openfund.Text == "") || (textBox_sales.Text == "") || (textBox_upi.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //to show data in data grid view
        private void AddDailySales_Load(object sender, EventArgs e)
        {
            
            ShowTable2();
        }
        public void ShowTable2()
        {
            DataGridView_sales.DataSource = sal.getSalestList();
            DataGridView_sales.RowTemplate.Height = 100;
        }

        private void button_clearsales_Click(object sender, EventArgs e)
        {
            textBox_closingfund.Clear();
            textBox_expense.Clear();
            textBox_openfund.Clear();
            textBox_sales.Clear();
            textBox_upi.Clear();
            dateTimePicker_date.Value = DateTime.Now;
        }

       
       
    }
    
}
