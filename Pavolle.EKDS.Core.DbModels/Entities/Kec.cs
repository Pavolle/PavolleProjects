using DevExpress.Xpo;
using Pavolle.EKDS.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.EKDS.Core.DbModels.Entities
{
    public class Kec : BaseObject
    {
        public Kec(Session session) : base(session)
        {
        }

        [Persistent("kec_id")]
        public long KecId { get; set; }

        [Persistent("gem_id")]
        public long GemId { get; set; }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("status")]
        public EKecStatus Status { get; set; }
    }
}
