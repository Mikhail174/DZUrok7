using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad0
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
            ShopDB.CustomersDataTable customers = customersTableAdapter.GetData();
            dataGridView1.DataSource = customers;

            var employeesTableAdapter = new ShopDBTableAdapters.EmployeesTableAdapter();
            ShopDB.EmployeesDataTable employees = employeesTableAdapter.GetData();
            dataGridView2.DataSource = employees;

        }
    }
}
