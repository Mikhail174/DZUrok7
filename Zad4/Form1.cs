using System;
using System.Windows.Forms;

namespace Zad4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ShopDB shopDB = new ShopDB();
            var customersTableAdapter = new ShopDBTableAdapters.CustomersTableAdapter();
            customersTableAdapter.Fill(shopDB.Customers);

            var ordersTableAdapter = new ShopDBTableAdapters.OrdersTableAdapter();
            ordersTableAdapter.Fill(shopDB.Orders);

            var employeesTableAdapter = new ShopDBTableAdapters.EmployeesTableAdapter();
            employeesTableAdapter.Fill(shopDB.Employees);

            shopDB.Orders.Columns.Add("SurnameEmployee", typeof(String));
            shopDB.Orders.Columns.Add("NameEmployee", typeof(String));
            shopDB.Orders.Columns.Add("SurnameCustomer", typeof(String));
            shopDB.Orders.Columns.Add("NameCustomer", typeof(String));

            foreach (var orderRow in shopDB.Orders)
            {
                orderRow["NameEmployee"] = orderRow.EmployeesRow.FName;
                orderRow["SurnameEmployee"] = orderRow.EmployeesRow.LName;
                orderRow["SurnameCustomer"] = orderRow.CustomersRow.FName;
                orderRow["NameCustomer"] = orderRow.CustomersRow.LName;

            }
            dataGridView1.DataSource = shopDB.Orders;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns["OrderDate"].Visible = false;

        }
    }
}
