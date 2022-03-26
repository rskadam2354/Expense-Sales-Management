using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace employee_payroll_management
{
    class Employeeclass
    {
        Dbconnect connect = new Dbconnect();
        public bool insertEmployee(string name,DateTime bdate,string gender, string phone,string address,string shift, string salary, string balsalary, DateTime saldate, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `employee`(`empname`, `empdob`, `empgender`, `empphone`, `empadd`, `empshift`, `empsalary`, `empbalsalary`, `empsaldate`, `empphoto`) VALUES (@name , @bd, @gn , @ph , @adr ,@shift, @sal ,@bal,@saldate, @img)", connect.GetConnection);
            //@name , @bd, @gn , @ph , @adr ,@shift, @sal ,@bal,@saldate, @img  
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@shift", MySqlDbType.VarChar).Value = shift;
            command.Parameters.Add("@sal", MySqlDbType.VarChar).Value = salary;
            command.Parameters.Add("@bal", MySqlDbType.VarChar).Value = balsalary;
            command.Parameters.Add("@saldate", MySqlDbType.Date).Value = saldate;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;
            

            connect.openConnect();
            if(command.ExecuteNonQuery()==1)
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
        // to get student table 
        public DataTable getEmployeeList(MySqlCommand command)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `employee`",connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        /// function to create a count query
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.GetConnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }
        //to get the total employee count
        public string totalEmployee()
        {
            return exeCount("SELECT COUNT(*) FROM employee");
        }
        // to get the male count
        public string totalMaleEmployee()
        {
            return exeCount("SELECT COUNT(*) FROM employee WHERE `empgender` = 'Male'");
        }
        // to get the female count 
        public string totalFemaleEmployee()
        {
            return exeCount("SELECT COUNT(*) FROM employee WHERE`empgender`='Female'");
        }

        // function for search for employee (first name , last name , address)
        public DataTable searchEmployee(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `employee` WHERE CONCAT(`empname`,`empadd`)LIKE '%"+searchdata+"%'", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateEmployee(int id, string name, DateTime bdate, string gender, string phone, string address, string shift, string salary, string balsalary, DateTime saldate, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `employee` SET `empname`=@name,`empdob`=@bd,`empgender`=@gn,`empphone`=@ph,`empadd`=@adr,`empshift`=@shift,`empsalary`=@sal,`empbalsalary`=@bal,`empsaldate`=@saldate,`empphoto`=@img WHERE `empid`=@id", connect.GetConnection);
            //@name ,@bd , @gn, @ph , @adr , @shift , @sal , @bal,@saldate,@img
            
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gn", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@shift", MySqlDbType.VarChar).Value = shift;
            command.Parameters.Add("@sal", MySqlDbType.VarChar).Value = salary;
            command.Parameters.Add("@bal", MySqlDbType.VarChar).Value = balsalary;
            command.Parameters.Add("@saldate", MySqlDbType.Date).Value = saldate;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

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
        public bool deleteEmployee(int id)
        {

            MySqlCommand command = new MySqlCommand("DELETE FROM `employee` WHERE `empid`=@id", connect.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
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
    }
}
