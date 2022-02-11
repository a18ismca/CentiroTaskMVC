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

        // Get a specific order number.
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

        
        // When a new order is created, the method below will insert the specified order into the CentiroOrder table.
        public void InsertNewOrder(string orderNumber, string orderLineNumber, string productNumber, string quantity, 
            string name, string description, string price, 
            string productGroup, string orderDate, string customerName, string customerNumber)
        {
            MySqlConnection dbcon = new MySqlConnection(ConnectionString);
            dbcon.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = dbcon;
            cmd.CommandText = "insert into CentiroOrder(OrderNumber, OrderLineNumber, ProductNumber, Quantity, Name, Description, Price, ProductGroup, OrderDate, CustomerName, CustomerNumber) values (@ORDERNO, @ORDERLINENO, @PRODUCTNO, @QUANTITY, @NAME, @DESCRIPTION, @PRICE, @PRODUCTGRP, @ORDERDATE, @CUSTOMERNAME, @CUSTOMERNO)";
            cmd.Parameters.AddWithValue("@ORDERNO", orderNumber);
            cmd.Parameters.AddWithValue("@ORDERLINENO", orderLineNumber);
            cmd.Parameters.AddWithValue("@PRODUCTNO", productNumber);
            cmd.Parameters.AddWithValue("@QUANTITY", quantity);
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", description);
            cmd.Parameters.AddWithValue("@PRICE", price);
            cmd.Parameters.AddWithValue("@PRODUCTGRP", productGroup);
            cmd.Parameters.AddWithValue("@ORDERDATE", orderDate);
            cmd.Parameters.AddWithValue("@CUSTOMERNAME", customerName);
            cmd.Parameters.AddWithValue("@CUSTOMERNO", customerNumber);
            
            cmd.ExecuteNonQuery();

            dbcon.Close();

        }

        // The following method may not work properly.
        public void DeleteOrder(string orderNumber, string productNumber)
        {
            MySqlConnection dbcon = new MySqlConnection(ConnectionString);
            dbcon.Open();
            string deleteString = "delete from CentiroOrder where OrderNumber=@OrderNumber and ProductNumber=@ProductNumber;";
            MySqlCommand cmd = new MySqlCommand(deleteString, dbcon);
            cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
            cmd.Parameters.AddWithValue("@ProductNumber", productNumber);

            cmd.ExecuteNonQuery();
            dbcon.Close();
        }
    }
}
