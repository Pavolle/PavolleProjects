using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    public class Document : BaseObject
    {
        public Document(Session session) : base(session)
        {
        }

        public long? OwnedOrganizationOid { get; set; }

        public long? OwnedPersonOid { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public File File { get; set; }

        public PhysicalFile PhysicalFile { get; set; }
    }
}
