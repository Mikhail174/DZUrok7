using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Zad2_
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

            foreach (var employee in shopDB.Employees)
            {
                Console.WriteLine("{0} {1} {2}", employee.LName, employee.FName, employee.MName);
                Console.WriteLine();

                var orders = employee.GetOrdersRows();
                foreach (var order in orders)
                {
                    Console.WriteLine("\tOrderId:{0}, {1}", order.OrderID, order.OrderDate);

                }
            }
        }
    }
}
