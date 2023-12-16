using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("supplera_document")]
    public class DocumentSupplera : Document
    {
        public DocumentSupplera(Session session) : base(session)
        {
        }

        public long ProductOid { get; set; }
        public long VersionOid { get; set; }
    }
}
