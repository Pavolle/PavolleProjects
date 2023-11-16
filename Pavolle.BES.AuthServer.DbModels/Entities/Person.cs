using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("people")]
    public class Person : BaseObject
    {
        public Person(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("surname")]
        [Size(255)]
        public string Surname { get; set; }

        [Persistent("birthday")]
        public DateTime? Birthday { get; set; }
    }
}
