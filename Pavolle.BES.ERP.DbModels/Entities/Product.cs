﻿using DevExpress.Xpo;
using Pavolle.BES.ERP.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.ERP.DbModels.Entities
{
    [Persistent("erp_product")]
    public class Product : BaseObject
    {
        public Product(Session session) : base(session)
        {
        }

        public string Name { get; set; }

        public EProductType ProductType { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
