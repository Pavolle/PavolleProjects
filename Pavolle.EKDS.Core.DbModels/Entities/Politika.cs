﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    [Persistent("politikalar")]
    public class Politika : BaseObject
    {
        public Politika(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }
    }
}
