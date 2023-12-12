﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.B2B.DbModels.Entities
{
    [Persistent("b2b_dealers")]
    public class Dealer : BaseObject
    {
        public Dealer(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("price_group_oid")]
        public long PriceGroupOid { get; set; }
    }
}
