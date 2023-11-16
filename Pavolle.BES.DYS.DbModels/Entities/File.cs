using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("files")]
    public class File : BaseObject
    {
        public File(Session session) : base(session)
        {
        }

        [Persistent("owner_organization_oid")]
        public long OwnedOrganizationOid { get; set; }

        [Persistent("owner_person_oid")]
        public long? OwnedPersonOid { get; set; }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("parrent_folder")]
        public File ParrentFolder { get; set; }
    }
}
