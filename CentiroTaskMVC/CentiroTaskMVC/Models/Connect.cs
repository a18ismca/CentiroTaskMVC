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
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CentiroOrder ORDER BY OrderDate DESC, OrderLineNumber;", dbcon);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "result");
                DataTable orderTable = ds.Tables["result"];
                dbcon.Close();

                return orderTable;

            }

        internal void InsertOrder()
        {
            throw new NotImplementedException();
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

        public void InsertOrder(string orderNumber, string orderLineNumber, string productNumber, string quantity, 
            string name, string description, string price, 
            string productGroup, string orderDate, string customerName, string customerNumber)
        {
            MySqlConnection dbcon = new MySqlConnection(ConnectionString);
            dbcon.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = dbcon;
            cmd.CommandText = "insert into CentiroOrder(OrderNumber, OrderLineNumber, " +
                "ProductNumber, Quantity, Name, Description, Price, ProductGroup, OrderDate, " +
                "CustomerName, CustomerNumber) values (@OrderNo, @OrderLineNo, @ProductNo, @Quantity, " +
                "@Name, @Description, @Price, @ProductGrp, @OrderDate, @CustomerName, @CustomerNo)";
            cmd.Parameters.AddWithValue("@OrderNo", orderNumber);
            cmd.Parameters.AddWithValue("@OrderLineNo", orderLineNumber);
            cmd.Parameters.AddWithValue("@ProductNo", productNumber);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@ProductGrp", productGroup);
            cmd.Parameters.AddWithValue("@OrderDate", orderDate);
            cmd.Parameters.AddWithValue("@CustomerName", customerName);
            cmd.Parameters.AddWithValue("@CustomerNo", customerNumber);
            
            cmd.ExecuteNonQuery();

            dbcon.Close();

        }
    }
}
