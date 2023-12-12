using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.B2C.DbModels.Entities
{
    [Persistent("b2c_customer")]
    public class B2CCustomer : BaseObject
    {
        public B2CCustomer(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public long UserOid { get; set; }
    }
}
