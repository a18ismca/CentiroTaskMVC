using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CentiroTaskMVC.Models
{
    public class Connect
    {
        
            private readonly string ConnectionString = "Server=localhost;Database=centirodb;User ID=root;Password=Pridvorci99;Pooling=false;SslMode=none;convert zero datetime=True;";


            public DataTable GetAllOrders()
            {
                MySqlConnection dbcon = new MySqlConnection(ConnectionString);
                dbcon.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from CentiroOrder order by OrderNumber;", dbcon);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "result");
                DataTable orderTable = ds.Tables["result"];
                dbcon.Close();

                return orderTable;

            }

        public DataTable GetAllDistinctOrderNumbers()
        {
            MySqlConnection dbcon = new MySqlConnection(ConnectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT DISTINCT OrderNumber FROM CentiroOrder; ", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable orderTable = ds.Tables["result"];
            dbcon.Close();

            return orderTable;

        }

        public DataTable GetOrderNumber(string orderNumber)
        {

            MySqlConnection dbcon = new MySqlConnection(ConnectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from CentiroOrder where OrderNumber=@OrderNumber order by OrderLineNumber;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@OrderNumber", orderNumber);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable specificOrderTable = ds.Tables["result"];
            dbcon.Close();

            return specificOrderTable;

        }

       
    }
}
