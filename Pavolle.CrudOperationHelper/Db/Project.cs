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
        [Size(255)]
        public string Name { get; set; }

        [Persistent("root")]
        [Size(255)]
        public string Root { get; set; }

        [Persistent("path")]
        [Size(255)]
        public string Path { get; set; }

        [Persistent("user_types")]
        [Size(255)]
        public string UserType { get; set; }

        [Persistent("intitialize")]
        public bool Intialize { get; set; }
    }
}
