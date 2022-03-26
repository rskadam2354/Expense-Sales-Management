using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace employee_payroll_management
{
    class Expensesclass
    {
        Dbconnect connect = new Dbconnect();

        public bool insertExpense(DateTime date, double mayur, double patpedi, double advance, string advdetails, double other, string othrdetails, double totalexp)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `expenses`( `expdate`, `mayur`, `patpedi`, `advance`, `advdetails`, `other`, `othrdetails`, `totalexp`) VALUES (@date,@my,@ppd,@adv,@advdet,@oth,@othdet,@ttexp)", connect.GetConnection);
            //@date,@my,@ppd,@adv,@advdet,@oth,@othdet,@ttexp
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@my", MySqlDbType.Double).Value = mayur;
            command.Parameters.Add("@ppd", MySqlDbType.Double).Value = patpedi;
            command.Parameters.Add("@adv", MySqlDbType.Double).Value = advance;
            command.Parameters.Add("@advdet", MySqlDbType.VarChar).Value = advdetails;
            command.Parameters.Add("@oth", MySqlDbType.Double).Value = other;
            command.Parameters.Add("@othdet", MySqlDbType.VarChar).Value = othrdetails;
            command.Parameters.Add("@ttexp", MySqlDbType.Double).Value = totalexp;

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
        public DataTable getExpensestList()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `expenses`", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateExpense(int expid, DateTime date, double mayur, double patpedi, double advance, string advdetails, double other, string othrdetails, double totalexp)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `expenses` SET `expdate`=@date,`mayur`=@my,`patpedi`=@ppd,`advance`=@adv,`advdetails`=@advdet,`other`=@oth,`othrdetails`=@othdet,`totalexp`=@ttexp WHERE `expid`=@id", connect.GetConnection);
            //@id,@date,@my,@ppd,@adv,@advdet,@oth,@othdet,@ttexp
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = expid;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@my", MySqlDbType.Double).Value = mayur;
            command.Parameters.Add("@ppd", MySqlDbType.Double).Value = patpedi;
            command.Parameters.Add("@adv", MySqlDbType.Double).Value = advance;
            command.Parameters.Add("@advdet", MySqlDbType.VarChar).Value = advdetails;
            command.Parameters.Add("@oth", MySqlDbType.Double).Value = other;
            command.Parameters.Add("@othdet", MySqlDbType.VarChar).Value = othrdetails;
            command.Parameters.Add("@ttexp", MySqlDbType.Double).Value = totalexp;
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
        public DataTable searchExpensedate(string searchdata)
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `expenses` WHERE Date(`expdate`) = '" + searchdata + "'", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchExpenseDetails(string searchdetails)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `expenses` WHERE CONCAT(`advdetails`,`othrdetails`)LIKE '%" + searchdetails + "%'", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        



    }
}
