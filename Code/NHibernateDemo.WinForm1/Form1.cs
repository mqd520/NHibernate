﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;

using NHibernateDemo.DAL;
using NHibernateDemo.Entity;
using NHibernateDemo.IRepository;
using NHibernateDemo.Repository;
using NHibernateDemo.WinForm1.IService;
using NHibernateDemo.WinForm1.Service;

using NHibernateDemo.WinForm1._02_Common;

namespace NHibernateDemo.WinForm1
{
    public partial class Form1 : Form
    {
        #region Field
        private ICustomersRepostory _customersRepostory = new CustomersRepostory();

        private ICustomersService _customersService = new CustomersService();
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        #region Query
        private void button1_Click_1(object sender, EventArgs e)
        {
            var ls = _customersRepostory.QueryAll();

            Tool.FillListView(ls, listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ls = _customersRepostory.QueryAll(x => x.Address, true);

            Tool.FillListView(ls, listView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ls = _customersRepostory.QueryAll(x => x.Country == "USA");

            Tool.FillListView(ls, listView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var lsWhere = new List<Expression<Func<Customers, bool>>>();
            lsWhere.Add(x => x.Country == "USA");
            lsWhere.Add(x => x.PostalCode.StartsWith("9"));
            var ls = _customersRepostory.QueryAll(lsWhere);

            Tool.FillListView(ls, listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ls = _customersRepostory.QueryAll(x => x.Country == "USA", x => x.ContactTitle, true);

            Tool.FillListView(ls, listView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int count = 0;
            var ls = _customersRepostory.QueryPaging(1, 10, out count);

            Tool.FillListView(ls, listView1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int count = 0;
            var ls = _customersRepostory.QueryPaging(1, 10, out count, x => x.CompanyName, true);

            Tool.FillListView(ls, listView1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int count = 0;
            var ls = _customersRepostory.QueryPaging(1, 10, out count, x => x.Country == "USA");

            Tool.FillListView(ls, listView1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int count = 0;
            var lsWhere = new List<Expression<Func<Customers, bool>>>();
            lsWhere.Add(x => x.Country == "USA");
            lsWhere.Add(x => x.PostalCode.StartsWith("9"));
            var ls = _customersRepostory.QueryPaging(1, 10, out count, lsWhere);

            Tool.FillListView(ls, listView1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int count = 0;
            var lsWhere = new List<Expression<Func<Customers, bool>>>();
            lsWhere.Add(x => x.Country == "USA");
            lsWhere.Add(x => x.PostalCode.StartsWith("9"));
            var ls = _customersRepostory.QueryPaging(1, 10, out count, lsWhere, x => x.CompanyName, true);

            Tool.FillListView(ls, listView1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int count = 0;
            var ls = _customersRepostory.QueryPaging(1, 10, out count, x => x.Country == "USA", x => x.CompanyName, true);

            Tool.FillListView(ls, listView1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var customer = _customersRepostory.QuerySingle("ANATR");
            var ls = new List<Customers>();
            ls.Add(customer);

            Tool.FillListView(ls, listView1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var ls = new List<Customers>();
            var customer = _customersRepostory.QuerySingle(x => x.CustomerId == "BERGS");
            ls.Add(customer);

            Tool.FillListView(ls, listView1);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            var ls = new List<Customers>();
            var wheres = new List<Expression<Func<Customers, bool>>>();
            wheres.Add(x => x.Country == "USA");
            wheres.Add(x => x.CustomerId == "GREAL");
            var customer = _customersRepostory.QuerySingle(wheres);
            ls.Add(customer);

            Tool.FillListView(ls, listView1);
        }
        #endregion


        #region Add
        private void button13_Click(object sender, EventArgs e)
        {
            var entity = new Customers
            {
                Address = "sdsdcfsds",
                City = "USA",
                CompanyName = "CompanyName1",
                ContactName = "6hgyu fyfg",
                ContactTitle = "sdsdsds",
                Country = "USA",
                CustomerId = RandTool.RandNumberString(5),
                Fax = "98787878",
                Phone = "222232323",
                PostalCode = "56567",
                Region = "sadjajdk"
            };
            object obj = _customersRepostory.Add(entity);

            MessageBox.Show(obj.ToString());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            IList<Customers> entities = new List<Customers>();
            entities.Add(new Customers
            {
                Address = "ascdsafc dfddffd",
                City = "USA",
                CompanyName = "CompanyName1",
                ContactName = "6hgyu fyfg",
                ContactTitle = "sdsdsds",
                Country = "USA",
                CustomerId = RandTool.RandNumberString(5),
                Fax = "98787878",
                Phone = "222232323",
                PostalCode = "56567",
                Region = "sadjajdk"
            });
            entities.Add(new Customers
            {
                Address = "ascdsafc dfddffd",
                City = "USA",
                CompanyName = "CompanyName1",
                ContactName = "6hgyu fyfg",
                ContactTitle = "sdsdsds",
                Country = "USA",
                CustomerId = RandTool.RandNumberString(5),
                Fax = "98787878",
                Phone = "222232323",
                PostalCode = "56567",
                Region = "sadjajdk"
            });

            var ls1 = _customersRepostory.Add(entities);

            string str = ls1.ConcatElement(Environment.NewLine);
            MessageBox.Show(str);
        }
        #endregion


        #region Update
        private void button15_Click(object sender, EventArgs e)
        {
            var entity = new Customers
            {
                CustomerId = "ALFKI",
                Address = "sdss",
                City = "2d3d3d",
                CompanyName = "AAAAAAAAAAAAA",
                ContactName = "kjioio",
                ContactTitle = "bnbvb",
                Country = "USA",
                Fax = "56757",
                Phone = "676786",
                PostalCode = "78678",
                Region = "sdsds"
            };

            _customersRepostory.Update(entity);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var entities = new List<Customers>();
            var entity = new Customers
            {
                CustomerId = "ALFKI",
                Address = "sdss",
                City = "2d3d3d",
                CompanyName = "sdsds",
                ContactName = "kjioio",
                ContactTitle = "bnbvb",
                Country = "USA",
                Fax = "56757",
                Phone = "676786",
                PostalCode = "78678",
                Region = "sdsds"
            };
            entities.Add(entity);

            _customersRepostory.Update(entities);
        }
        #endregion


        #region Delete
        private void button17_Click(object sender, EventArgs e)
        {
            var entity = new Customers
            {
                CustomerId = "04826",
                Address = "sdss",
                City = "2d3d3d",
                CompanyName = "sdsds",
                ContactName = "kjioio",
                ContactTitle = "bnbvb",
                Country = "USA",
                Fax = "56757",
                Phone = "676786",
                PostalCode = "78678",
                Region = "sdsds"
            };

            _customersRepostory.Delete(entity);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            _customersRepostory.Delete("25062");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var ls = new List<Customers>();
            ls.Add(new Customers
            {
                CustomerId = "22658",
                Address = "sdss",
                City = "2d3d3d",
                CompanyName = "sdsds",
                ContactName = "kjioio",
                ContactTitle = "bnbvb",
                Country = "USA",
                Fax = "56757",
                Phone = "676786",
                PostalCode = "78678",
                Region = "sdsds"
            });
            ls.Add(new Customers
            {
                CustomerId = "25111",
                Address = "sdss",
                City = "2d3d3d",
                CompanyName = "sdsds",
                ContactName = "kjioio",
                ContactTitle = "bnbvb",
                Country = "USA",
                Fax = "56757",
                Phone = "676786",
                PostalCode = "78678",
                Region = "sdsds"
            });

            _customersRepostory.Delete(ls);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var ls = new List<string>();
            ls.Add("33310");
            ls.Add("35058");

            _customersRepostory.Delete(ls);
        }
        #endregion
    }
}
