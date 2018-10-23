using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Zad2_
{
    class Program
    {
        static void Main(string[] args)
        {
            // string connectionString = @"Data Source=WKS456\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
            //string commandString = "SELECT EmployeeID FROM Employees; SELECT * FROM Orders;";
            DataSet simpleShopDb = new DataSet();
            simpleShopDb.ReadXmlSchema(@"E:\ADO.NET\DATA\ShopDbSchema.xml");
            simpleShopDb.ReadXml(@"E:\ADO.NET\DATA\ShopDBData.xml");


           // SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;/80890890
            //adapter.Fill(simpleShopDb);
            DataTable Employees = simpleShopDb.Tables[0];
            DataTable orders = simpleShopDb.Tables[1];
            simpleShopDb.Relations.Add("Employees_Orders", Employees.Columns["EmployeeID"], orders.Columns["EmployeeID"]);
            Employees.Columns.Add("CountSale", typeof(double), "Count(Child(Employees_Orders).EmployeeID)");

            foreach (DataRow EmployeesRow in Employees.Rows)
            {
                foreach (DataColumn EmployeesColumn in Employees.Columns)
                    Console.WriteLine("{0}: {1}", EmployeesColumn.ColumnName, EmployeesRow[EmployeesColumn]);

                Console.WriteLine();
            }


            ShopDB strongedShopDB = new ShopDB();
            strongedShopDB.Customers.Merge(simpleShopDb.Tables["Employees"]);
            

            foreach (DataRow row in strongedShopDB.Employees.Rows)
            {
                foreach (DataColumn column in strongedShopDB.Employees.Columns)
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);

                Console.WriteLine();
            }

            //var employeesTableAdapter = new ShopDBTableAdapters.EmployeesTableAdapter();
            //employeesTableAdapter.Fill(strongedShopDB.Employees);

            //var ordersTableAdapter = new ShopDBTableAdapters.OrdersTableAdapter();
            //ordersTableAdapter.Fill(strongedShopDB.Orders);

            //var orderDetailsTableAdapter = new ShopDBTableAdapters.OrderDetailsTableAdapter();
            //orderDetailsTableAdapter.Fill(strongedShopDB.OrderDetails);

            //ShopDB.EmployeesDataTable employees = employeesTableAdapter.GetData();
            //ShopDB.OrdersDataTable orders1 = ordersTableAdapter.GetData();
            //ShopDB.OrderDetailsDataTable orderDetails = orderDetailsTableAdapter.GetData();


          //  orders.Columns.Add("TotalSold", typeof(double), "SUM(Child(Orders_OrderDetails).TotalPrice)"); // добавление расчитываемого столбца, используемого связь 

            //shopDB.Relations.Add("Employees_Orders", employees.Columns["EmployeeID"], orders.Columns["EmployeeID"]);
            //employees.Columns.Add("AggregateColumn", typeof(double), "Count(Child(FK_Orders_Employees).EmployeeID)");

            // shopDB.Relations.Add("Employees_Orders", Employees.Columns["EmployeeID"], orders.Columns["EmployeeID"]);
            // Employees.Columns.Add("CountSale", typeof(double), "Count(Child(Employees_Orders).EmployeeID)");
            //employees.Columns.Add("AggregateColumn", typeof(double), "Count(Child(FK_Orders_Employees).EmployeeID)");
            //employees.Columns.Add("CountSale", typeof(double), "Count(Child(Employees_Orders).EmployeeID)");
            //foreach (DataRow employeeRow in employees.Rows)
            //{
            //    foreach (DataColumn employeeColumn in employees.Columns)
            //        Console.WriteLine("{0}: {1}", employeeColumn.ColumnName, employeeRow[employeeColumn]);

            //    Console.WriteLine();
            //}

            //foreach (var employee in shopDB.Employees)
            //{
            //    Console.WriteLine("{0} {1} {2}", employee.LName, employee.FName, employee.LName);
            //    Console.WriteLine();

            //    var orders1 = employee.GetOrdersRows();
            //    foreach (var order in orders1)
            //    {
            //        Console.WriteLine("\tOrderId:{0}, {1}", order.OrderID, order.OrderDate); //

            //    }
            //}
        }
    }
}
