using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad2
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

            var employeesTableAdapter = new ShopDBTableAdapters.EmployeesTableAdapter();
            employeesTableAdapter.Fill(shopDB.Employees);

            var ordersTableAdapter = new ShopDBTableAdapters.OrdersTableAdapter();
            ordersTableAdapter.Fill(shopDB.Orders);

            ShopDB.EmployeesDataTable employees = employeesTableAdapter.GetData();
            ShopDB.OrdersDataTable orders = ordersTableAdapter.GetData();

            employees.Columns.Add("Count", typeof(int));
            foreach (DataRow employeeRow in employees.Rows)
            {
                employeeRow["Count"] = orders.Count(o => o.EmployeeID == (int)employeeRow["EmployeeID"]);

            }
            dataGridView1.DataSource = employees;
            this.dataGridView1.Columns["FName"].Visible = false;
            this.dataGridView1.Columns["LName"].Visible = false;
            this.dataGridView1.Columns["MName"].Visible = false;
            this.dataGridView1.Columns["Salary"].Visible = false;
            this.dataGridView1.Columns["PriorSalary"].Visible = false;
            this.dataGridView1.Columns["HireDate"].Visible = false;
            this.dataGridView1.Columns["TerminationDate"].Visible = false;
            this.dataGridView1.Columns["ManagerEmpID"].Visible = false;



        }
    }
}
