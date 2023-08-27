using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Db
{
    [Persistent("tables")]
    public class Table : BaseObject
    {
        public Table(Session session) : base(session)
        {
        }

        [Persistent("project_oid")]
        public Project Project { get; set; }

        [Persistent("class_name")]
        public string ClassName { get; set; }

        [Persistent("db_table_name")]
        public string DbName { get; set; }

        [Persistent("list_service")]
        public bool ListService { get; set; }

        [Persistent("lookup_service")]
        public bool LookupService { get; set; }

        [Persistent("detail_service")]
        public bool DetailService { get; set; }

        [Persistent("add_service")]
        public bool AddService { get; set; }

        [Persistent("edit_service")]
        public bool EditService { get; set; }

        [Persistent("delete_service")]
        public bool DeleteService { get; set; }
    }
}
