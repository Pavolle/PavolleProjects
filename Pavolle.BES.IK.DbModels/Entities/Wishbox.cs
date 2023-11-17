using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    [Persistent("wishbox")]
    public class Wishbox : BaseObject
    {
        public Wishbox(Session session) : base(session)
        {
        }

        [Persistent("header")]
        public string Header { get; set; }

        [Persistent("content")]
        public string Content { get; set; }
    }
}
