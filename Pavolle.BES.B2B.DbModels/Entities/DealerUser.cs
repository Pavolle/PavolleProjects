﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.B2B.DbModels.Entities
{
    [Persistent("dealer_user")]
    public class DealerUser : BaseObject
    {
        public DealerUser(Session session) : base(session)
        {
        }

        [Persistent("dealer_oid")]
        public Dealer Dealer { get; set; }

        [Persistent("user_oid")]
        public long UserOid { get; set; }
    }
}
