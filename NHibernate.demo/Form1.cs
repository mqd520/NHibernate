using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.demo.Entity;
using NHibernate;
using NHibernate.Linq;

namespace NHibernate.demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var list = session.CreateQuery("from Employees").List<Employees>();
            Tool.FillListView<Employees>(list, listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var list = session.CreateSQLQuery("select * from Orders").AddEntity(typeof(Orders)).List<Orders>();
            Tool.FillListView<Orders>(list, listView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var result = (from order in session.Query<Customers>()
                          select order).ToList<Customers>();
            Tool.FillListView<Customers>(result, listView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var result = (from orders in session.Query<Orders>()
                          join customer in session.Query<Customers>() on orders.CustomerId equals customer.CustomerId
                          select orders).ToList<Orders>();
            Tool.FillListView<Orders>(result, listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var list = session.CreateQuery("from Products").SetFirstResult((1 - 1) * 10).SetMaxResults(10).List<Products>();
            Tool.FillListView<Products>(list, listView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
