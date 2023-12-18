using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("document_versions")]
    public class DocumentVersion : BaseObject
    {
        public DocumentVersion(Session session) : base(session)
        {
        }

        [Persistent("document_oid")]
        public Document Document { get; set; }


        [Persistent("secure_key")]
        [Size(8)]
        public string SecureKey { get; set; }


        [Persistent("version_code")]
        public string VersionCode { get; set; }


        [Persistent("unique_code")]
        [Size(100)]
        public string UniqueCode { get; set; }


        [Persistent("path")]
        [Size(255)]
        public string Path { get; set; }


        [Persistent("full_path")]
        [Size(255)]
        public string FullPath { get; set; }


        [Persistent("is_current_version")]
        public bool IsCurrentVersion { get; set; }
    }
}
