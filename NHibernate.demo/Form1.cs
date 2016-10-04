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
            var result = from orders in session.Query<Orders>()
                         join customer in session.Query<Customers>() on orders.CustomerId equals customer.CustomerId
                         select orders;
            var list = result.ToList<Orders>();
            Tool.FillListView<Orders>(list, listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Products").SetFirstResult((1 - 1) * 10).SetMaxResults(10);
            var list = query.List<Products>();
            Tool.FillListView<Products>(list, listView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var query = from o in session.Query<Orders>()
                        where o.CustomerId == "ALFKI"
                        select o;
            query = query.Skip((1 - 1) * 10).Take(10);
            var list = query.ToList();
            Tool.FillListView(list, listView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Customers c where c.CustomerID='ANATR'");
            IList<Customers> list = query.List<Customers>();
            Tool.FillListView(list, listView1);
            // 数学操作符：+, -, *, /
            // 真假比较操作符：=, >=, <=, <>, !=, like
            // 逻辑操作符：and, or, not
            // 字符串连接操作符：||  
            // SQL标量函数：upper(),lower() 
            // 没有前缀的( )：表示分组
            // in, between, is null
            // 位置参数：?
            // 命名参数：:name, :start_date, :x1
            // SQL文字：'foo', 69, '1970-01-01 10:00:01.0'
            // 枚举值或常量：Color.Tabby
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Customers as c");
            //IQuery query = session.CreateQuery("from Customers c");
            var list = query.List<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("select c from Customers c");
            IList<Customers> list = query.List<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("select c.CustomerId,c.CompanyName from Customers c");
            IList<object[]> list = query.List<object[]>();
            IList<Customers> list1 = new List<Customers>();
            foreach (var item in list)
            {
                list1.Add(new Customers
                {
                    CustomerId = (string)item[0],
                    CompanyName = (string)item[1]
                });
            }
            Tool.FillListView(list1, listView1);
        }
    }
}
