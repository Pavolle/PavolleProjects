using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.JobServer.DbModels.Entities
{
    [NonPersistent]
    public class BaseObject : XPBaseObject
    {
        public BaseObject(Session session) : base(session)
        {

        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            CreatedTime = DateTime.Now;
        }

        [Persistent("oid")]
        [Key(true)]
        public long Oid { get; set; }

        [Persistent("created_time")]
        public DateTime CreatedTime { get; set; }

        [Persistent("last_update_time")]
        public DateTime? LastUpdateTime { get; set; }
    }
}
