using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Db
{
    [Persistent("projects")]
    public class Project : BaseObject
    {
        public Project(Session session) : base(session)
        {
        }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("root")]
        public string Root { get; set; }

        [Persistent("path")]
        public string Path { get; set; }
    }
}
