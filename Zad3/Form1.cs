using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad3
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

            ShopDB.CustomersDataTable customers = customersTableAdapter.GetData();
            ShopDB.OrdersDataTable orders = ordersTableAdapter.GetData();






            var query = from c in customers
                         join o in orders on c.CustomerNo equals o.CustomerNo
                         group o by c into g
                         select new  { City=g.Key.City,
                                       Countsale = g.Count(o=>o.CustomerNo==g.Key.CustomerNo)
                                     };
                         dataGridView1.DataSource = query.ToList();











            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[2].Visible = false;
            //dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[8].Visible = false;



        }
    }
}
