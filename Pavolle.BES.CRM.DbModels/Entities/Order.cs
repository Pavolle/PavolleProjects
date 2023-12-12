using DevExpress.Xpo;
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
    }
}
