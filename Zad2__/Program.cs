using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Zad2__
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDB shopDB = new ShopDB();

            var employeesTableAdapter = new ShopDBTableAdapters.EmployeesTableAdapter();
            employeesTableAdapter.Fill(shopDB.Employees);

            var ordersTableAdapter = new ShopDBTableAdapters.OrdersTableAdapter();
            ordersTableAdapter.Fill(shopDB.Orders);

            var orderDetailsTableAdapter = new ShopDBTableAdapters.OrderDetailsTableAdapter();
            orderDetailsTableAdapter.Fill(shopDB.OrderDetails);

            ShopDB.EmployeesDataTable employees = employeesTableAdapter.GetData();
            ShopDB.OrdersDataTable orders = ordersTableAdapter.GetData();
    
            employees.Columns.Add("Count", typeof(int));
            foreach (DataRow employeeRow in employees.Rows)
            {
                employeeRow["Count"] = orders.Count(o => o.EmployeeID == (int)employeeRow["EmployeeID"]);

                foreach (DataColumn column in employees.Columns) {
                    if (column.ColumnName=="EmployeeID" || column.ColumnName == "Count")
                        Console.WriteLine("{0}: {1}", column.ColumnName, employeeRow[column]);
                }
                Console.WriteLine();
            }

        }
    }
}
