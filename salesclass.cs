using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace employee_payroll_management
{
    
    class salesclass
    {
        Dbconnect connect = new Dbconnect();
        public bool insertSales( DateTime date, double ofund, double exp, double upi, double cfund, double sales)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `sales`( `salesDate`, `OpeningFund`, `Expenses`, `UPI`, `ClosingFund`, `Sales`) VALUES (@date , @of, @exp , @upi , @cf , @sales)", connect.GetConnection);
            //@date , @of, @exp , @upi , @cf , @sales 
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@of", MySqlDbType.Float).Value = ofund;
            command.Parameters.Add("@exp", MySqlDbType.Float).Value = exp;
            command.Parameters.Add("@upi", MySqlDbType.Float).Value = upi;
            command.Parameters.Add("@cf", MySqlDbType.Float).Value = cfund;
            command.Parameters.Add("@sales", MySqlDbType.Float).Value = sales;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;

            }
            
        }
        public DataTable getSalestList()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `sales`", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateSales(int id,DateTime date, double ofund, double exp, double upi, double cfund, double sales)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `sales` SET `salesDate`=@date,`OpeningFund`=@of,`Expenses`=@exp,`UPI`=@upi,`ClosingFund`=@cf,`Sales`=@sales WHERE `salesid`=@id", connect.GetConnection);
            //@date , @of, @exp , @upi , @cf , @sales
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@of", MySqlDbType.Float).Value = ofund;
            command.Parameters.Add("@exp", MySqlDbType.Float).Value = exp;
            command.Parameters.Add("@upi", MySqlDbType.Float).Value = upi;
            command.Parameters.Add("@cf", MySqlDbType.Float).Value = cfund;
            command.Parameters.Add("@sales", MySqlDbType.Float).Value = sales;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;

            }

        }
        public DataTable searchSales(string searchdata)
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `sales` WHERE Date(`salesDate`) = '"+searchdata+"'", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
