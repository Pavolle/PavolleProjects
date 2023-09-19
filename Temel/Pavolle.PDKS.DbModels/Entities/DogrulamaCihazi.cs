using DevExpress.Xpo;
using Pavolle.PDKS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.DbModels.Entities
{
    [Persistent("dogrulama_cihazlari")]
    public class DogrulamaCihazi:BaseObject
    {
        public DogrulamaCihazi(Session session) : base(session)
        {
        }

        [Persistent("cihaz_id")]
        public long CihazId { get; set; }

        [Persistent("dogrulama_cihaz_tipi_oid")]
        public DogrulamaCihazTipi DogrulamaCihazTipi { get; set; }

        //Bir cihazda n tane doğrulama yöntemi olabilir mi?
    }
}
