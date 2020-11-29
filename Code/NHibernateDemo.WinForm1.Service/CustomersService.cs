using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernateDemo.Entity;
using NHibernateDemo.WinForm1.IService;

namespace NHibernateDemo.WinForm1.Service
{
    public class CustomersService : Service<Customers>, ICustomersService
    {

    }
}
