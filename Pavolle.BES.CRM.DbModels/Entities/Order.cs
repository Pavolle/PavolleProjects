using DevExpress.Xpo;
using Pavolle.BES.CRM.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.CRM.DbModels.Entities
{
    public class Order : BaseObject
    {
        public Order(Session session) : base(session)
        {
        }

        public string OrderCode { get; set; }
        public EOrderChannel OrderChannel { get; set; }
        public long? DealerOid { get; set; }
        public long? CustomerOid { get; set; }
        public long? UserOid { get; set; }
    }
}
