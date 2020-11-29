using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernateDemo.Entity;
using NHibernateDemo.IRepository;

namespace NHibernateDemo.Repository
{
    public class CustomersRepostory : Repository<Customers>, ICustomersRepostory
    {

    }
}
