using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.DbModels.Entities
{
    [Persistent("cities")]
    public class City : BaseObject
    {
        public City(Session session) : base(session)
        {
        }

        [Persistent("name_td_oid")]
        public long NameTranslateDataOid { get; set; }

        [Persistent("country_oid")]
        public Country Country { get; set; }
    }
}
