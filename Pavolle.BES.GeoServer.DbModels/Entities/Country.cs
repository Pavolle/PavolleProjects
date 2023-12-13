using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.DbModels.Entities
{
    [Persistent("countries")]
    public class Country : BaseObject
    {
        public Country(Session session) : base(session)
        {
        }
        //Bunlar multilanguage olacak

        [Persistent("name_td_oid")]
        public long NameTranslateDataOid { get; set; }

        [Persistent("iso_code2")]
        public string IsoCode2 { get; set; }

        [Persistent("iso_code3")]
        public string IsoCode3 { get; set; }

        [Persistent("phone_code")]
        public string PhoneCode { get; set; }
    }
}
