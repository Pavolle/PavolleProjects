﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    public class ProductVersion : BaseObject
    {
        public ProductVersion(Session session) : base(session)
        {
        }

        public Product Product { get; set; }
        public string VersionCode { get; set; }
    }
}
