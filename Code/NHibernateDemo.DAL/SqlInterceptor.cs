using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.SqlCommand;

using Common;

namespace NHibernateDemo.DAL
{
    public class SqlInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            CommonLogger.WriteLog(
                ELogCategory.Sql,
                string.Format("NHibernate SQL: {0}", sql.ToString())
            );

            return base.OnPrepareStatement(sql);
        }
    }
}
