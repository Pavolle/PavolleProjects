using DevExpress.Xpo;
using Pavolle.BES.DYS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.DbModels.Entities
{
    [Persistent("folders")]
    public class Folder : BaseObject
    {
        public Folder(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long? OrganizationOid { get; set; }


        [Persistent("name")]
        public string Name { get; set; }


        [Persistent("parent_folder_oid")]
        public long? ParentFolderOid { get; set; }


        [Persistent("folder_type")]
        public EFolderType FolderType { get; set; }


        [Persistent("full_path")]
        public string FullPath { get; set; }


        [Persistent("can_transfer")]
        public bool CanTransfer { get; set; }
    }
}
