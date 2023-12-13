using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.DbModels.Entities
{
    [Persistent("districts")]
    public class District : BaseObject
    {
        public District(Session session) : base(session)
        {
        }

        [Persistent("name_td_oid")]
        public long NameTranslateDataOid { get; set; }

        [Persistent("city_oid")]
        public City City { get; set; }
    }
}
