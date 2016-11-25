using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.demo.Entity;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;

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
            Tool.FillListView(list, listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            ISQLQuery query = session.CreateSQLQuery("select * from Orders").AddEntity(typeof(Orders));
            var list = query.List<Orders>();
            Tool.FillListView(list, listView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          select c;
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Orders> query = from o in session.Query<Orders>()
                                       join c in session.Query<Customers>() on o.CustomerId equals c.CustomerId
                                       select o;
            IList<Orders> list = query.ToList<Orders>();
            Tool.FillListView(list, listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Products").SetFirstResult((1 - 1) * 10).SetMaxResults(10);
            var list = query.List<Products>();
            Tool.FillListView(list, listView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateSQLQuery("select * from Orders where OrderId=:OrderId").SetInt32("OrderId", 10248);
            ISQLQuery query1 = (ISQLQuery)query;
            query1 = query1.AddEntity(typeof(Orders));
            var list = query.List<Orders>();
            Tool.FillListView(list, listView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int index = 1;
            int size = 10;
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Orders> query = from o in session.Query<Orders>()
                                       select o;
            query = query.Skip((index - 1) * size).Take(size);
            IList<Orders> list = query.ToList();
            Tool.FillListView(list, listView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Customers c where c.CustomerId='ANATR'");
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

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Customers c where c.CustomerId=?").SetString(0, "ANATR");
            IList<Customers> list = query.List<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateQuery("from Customers c where c.CustomerId=:para1").SetString("para1", "BOLID");
            IList<Customers> list = query.List<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          join o in session.Query<Orders>() on c.CustomerId equals o.CustomerId into orders
                                          select c;
            IList<Customers> list = query.ToList();
            Tool.FillListView(list, listView1);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          orderby c.CustomerId
                                          select c;
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          select c;
            //只能通过方法语法，不能通过查询语法
            query = query.OrderByDescending(c => c.CustomerId);
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          orderby c.CustomerId
                                          select c;
            query = query.OrderBy(c => c.ContactName);

            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession(s => Console.WriteLine(s));
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          select c;
            query = query.OrderBy(c => c.CustomerId).ThenByDescending(c => c.ContactName);
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession(s => Console.WriteLine(s));
            var list = session.CreateQuery("from Employees").List<Employees>();
            Tool.FillListView(list, listView1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          where c.CustomerId == "ALFKI"
                                          select c;
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          where c.CustomerId == "ALFKI" || c.CustomerId == "ANATR"
                                          select c;
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Customers> query = from c in session.Query<Customers>()
                                          where c.CustomerId == "ALFKI" && c.ContactTitle == "Owner"
                                          select c;
            IList<Customers> list = query.ToList<Customers>();
            Tool.FillListView(list, listView1);
        }

        private void button24_Click(object sender, EventArgs e1)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Employees> query = from e in session.Query<Employees>()
                                          where e.EmployeeId > 1
                                          select e;
            IList<Employees> list = query.ToList<Employees>();
            Tool.FillListView(list, listView1);
        }

        private void button25_Click(object sender, EventArgs e1)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Employees> query = from e in session.Query<Employees>()
                                          where e.EmployeeId < 3
                                          select e;
            IList<Employees> list = query.ToList<Employees>();
            Tool.FillListView(list, listView1);
        }

        private void button26_Click(object sender, EventArgs e1)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Employees> query = from e in session.Query<Employees>()
                                          where e.BirthDate > DateTime.Now
                                          select e;
            IList<Employees> list = query.ToList<Employees>();
            Tool.FillListView(list, listView1);
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Orders> query = from o in session.Query<Orders>()
                                       join c in session.Query<Customers>()
                                            on new { p1 = o.CustomerId, p2 = o.ShipAddress } equals new { p1 = c.ContactTitle, p2 = c.ContactName }
                                       select o;
            IList<Orders> list = query.ToList<Orders>();
            Tool.FillListView(list, listView1);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQueryable<Employees> query = from c in session.Query<Customers>()
                                          select new Employees
                                          {
                                              Address = c.ContactName
                                          };
            IList<Employees> list = query.ToList<Employees>();
            Tool.FillListView(list, listView1);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            var query = from c in session.Query<Customers>()
                        select new
                        {
                            Address = c.ContactName
                        };
            var list = query.ToList();
            Tool.FillListView(list, listView1);
        }

        private void button29_Click(object sender, EventArgs e1)
        {
            ISession session = NHibernateHelper.CreateSession();
            var query = from e in session.Query<Employees>()
                        select new Employees
                        {
                            EmployeeId = (
                                       from o in session.Query<Orders>()
                                       where o.EmployeeId == e.EmployeeId
                                       select o.OrderId
                                     ).Sum()
                        };
            var list = query.ToList();
            Tool.FillListView(list, listView1);
        }

        private void button30_Click(object sender, EventArgs e1)
        {
            ISession session = NHibernateHelper.CreateSession();
            var query = from e in session.Query<Employees>()
                        select new Employees
                        {
                            EmployeeId = (
                                       from o in session.Query<Orders>()
                                       where o.EmployeeId == e.EmployeeId
                                       select o.OrderId
                                     ).Sum(),
                            Address = (
                                       from o in session.Query<Orders>()
                                       where o.EmployeeId == e.EmployeeId
                                       select o.OrderId
                                     ).Count().ToString(),
                            City = (
                                      from o in session.Query<Orders>()
                                      where o.EmployeeId == e.EmployeeId
                                      select o.OrderId
                                    ).FirstOrDefault().ToString(),
                            HomePhone = (
                                            from o in session.Query<Orders>()
                                            where o.EmployeeId == e.EmployeeId
                                            select o.OrderId
                                        ).Max().ToString(),
                            Country = (
                                      from o in session.Query<Orders>()
                                      where o.EmployeeId == e.EmployeeId
                                      select o.OrderId
                                    ).Min().ToString(),
                            Region = (
                                     from o in session.Query<Orders>()
                                     where o.EmployeeId == e.EmployeeId
                                     select o.OrderId
                            ).Average().ToString()
                        };
            var list = query.ToList();
            Tool.FillListView(list, listView1);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.CreateSQLQuery("select * from Orders where OrderId=?").SetInt32(0, 10248);
            ISQLQuery query1 = (ISQLQuery)query;
            query1 = query1.AddEntity(typeof(Orders));
            var list = query.List<Orders>();
            Tool.FillListView(list, listView1);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            string sql = @"
                INSERT INTO dbo.Animal
                        ( 
                          body_weight ,
                          SerialNumber 
                        )
                VALUES  ( 
                          101.0 , 
                          45678  
                        )
            ";
            ISQLQuery query = session.CreateSQLQuery(sql);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button33_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            string sql = @"
                INSERT INTO dbo.Animal
                        ( 
                          body_weight ,
                          SerialNumber 
                        )
                VALUES  ( 
                          ? , 
                          ?  
                        )
            ";
            IQuery query = session.CreateSQLQuery(sql).SetDouble(0, 111.1).SetInt32(1, 23);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button34_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            string sql = "UPDATE dbo.Animal SET body_weight=333.3 WHERE Id=10";
            ISQLQuery query = session.CreateSQLQuery(sql);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            string sql = "UPDATE dbo.Animal SET body_weight=? WHERE Id=10";
            IQuery query = session.CreateSQLQuery(sql).SetDouble(0, 444.4);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            string sql = "DELETE FROM dbo.Animal WHERE id=9";
            ISQLQuery query = session.CreateSQLQuery(sql);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            string sql = "DELETE FROM dbo.Animal WHERE id=?";
            IQuery query = session.CreateSQLQuery(sql).SetInt32(0, 8);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button38_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query1");
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button39_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query2").SetInt32(0, 10);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button40_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query3").SetInt32("id", 7);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button41_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query4").SetInt32("id", -1);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button42_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query5").SetString("serail", "0000");
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button44_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query6").SetInt32("return", -1);
            int n = query.ExecuteUpdate();
            MessageBox.Show(n.ToString());
        }

        private void button45_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query7");
            ISQLQuery query1 = (ISQLQuery)query;
            IList<Animal> list = query1.List<Animal>();
            Tool.FillListView(list, listView1);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IQuery query = session.GetNamedQuery("query8");
            ISQLQuery query1 = (ISQLQuery)query;
            IList<Entity.View.Class1> list = query1.List<Entity.View.Class1>();
            Tool.FillListView(list, listView1);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            Animal entity = new Animal
            {
                Description = "Description"
            };
            session.Save(entity);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            Animal entity = session.Get<Animal>(1);
            entity.Description = "dsdfsfg345gegfg";
            session.Update(entity);
            session.Flush();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession(s => Console.WriteLine(s));
            Animal entity = session.Get<Animal>(1007);
            session.Delete(entity);
            session.Flush();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            Animal entity = new Animal
            {
                Id = 1008
            };
            session.Delete(entity);
            session.Flush();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            Animal entity1 = new Animal
            {
                Id = 15,
                Description = "sddddddddddddddddd"
            };
            Animal entity2 = new Animal
            {
                Id = 16,
                Description = "sddddddddddddddddd"
            };
            Animal entity3 = new Animal
            {
                Description = "dfergeeeeeeeeeeeeee"
            };
            //session.Update(entity1);
            //session.Update(entity2);
            //session.Flush();

            Animal a = session.Get<Animal>(1);
            session.Save(entity3);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            ICriteria cri = session.CreateCriteria(typeof(Animal));
            cri = cri.SetFirstResult(0).SetMaxResults(10);
            IList<Animal> list = cri.List<Animal>();
            Tool.FillListView(list, listView1);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            ICriteria cri = session.CreateCriteria(typeof(Animal));
            Order or = new Order("Id", false);
            cri = cri.AddOrder(or);
            IList<Animal> list = cri.List<Animal>();
            Tool.FillListView(list, listView1);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            ICriteria cri = session.CreateCriteria(typeof(Animal));
            Order or1 = new Order("Id", false);
            Order or2 = new Order("body_weight", true);
            cri = cri.AddOrder(or1).AddOrder(or2);
            IList<Animal> list = cri.List<Animal>();
            Tool.FillListView(list, listView1);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IDbCommand cmd = session.Connection.CreateCommand();
            cmd.CommandText = "select * from animal";
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            DataColumn[] cols = new DataColumn[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                cols[i] = new DataColumn(reader.GetName(i));
            }
            dt.Columns.AddRange(cols);
            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                int n = reader.GetValues(values);
                DataRow dr = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dr[i] = values[i];
                }
                dt.Rows.Add(dr);
            }
            reader.Dispose();
            session.Disconnect();
            Tool.FillListView(dt, listView1);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            ISession session = NHibernateHelper.CreateSession();
            IDbCommand cmd = session.Connection.CreateCommand();
            cmd.CommandText = "delete from animal where id=0";
            cmd.CommandType = CommandType.Text;
            int n = cmd.ExecuteNonQuery();
            MessageBox.Show(n.ToString());
        }
    }
}
