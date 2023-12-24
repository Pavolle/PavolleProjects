using DevExpress.Xpo;
using Pavolle.BES.TeknikDestek.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TeknikDestek.DbModels.Entities
{
    public class TechnicalSupportRecord : BaseObject
    {
        public TechnicalSupportRecord(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("support_id")]
        public string SupportID { get; set; }

        [Persistent("technical_support_type")]
        public ETechnicalSupportType TechnicalSupportType { get; set; }
    }
}
