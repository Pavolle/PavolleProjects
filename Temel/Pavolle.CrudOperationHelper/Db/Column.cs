using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Db
{
    [Persistent("columns")]
    public class Column : BaseObject
    {
        public Column(Session session) : base(session)
        {
        }

        [Persistent("table_oid")]
        public Table Table { get; set; }
    }
}
