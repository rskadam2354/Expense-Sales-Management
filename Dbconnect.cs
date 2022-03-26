using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace employee_payroll_management
{
    //this class is used for the connection of this application with sql database

    class Dbconnect
    {
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=isurfcyber");
        public MySqlConnection GetConnection
        {
            get
            {
                return connect;
            }
        }
        public void openConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }

        public void closeConnect()
        {
            if(connect.State==System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }

        //to get employee table
        
    }

}
