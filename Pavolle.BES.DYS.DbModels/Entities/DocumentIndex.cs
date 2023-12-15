using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("document_index")]
    public class DocumentIndex : BaseObject
    {
        public DocumentIndex(Session session) : base(session)
        {
        }

        [Persistent("document_oid")]
        public Document Document { get; set; }

        [Persistent("index_key")]
        public string IndexKey { get; set; }
    }
}
