using DevExpress.Xpo;
using Pavolle.BES.IK.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    public class FamilyInfo : BaseObject
    {
        public FamilyInfo(Session session) : base(session)
        {
        }

        public long PersonOid { get; set; }
        public IdentificationInfo IdentificationInfo { get; set; }
        public PassportInfo PassportInfo { get; set; }
        public EFamilyMember FamilyMember { get; set; }
        public MarriageCertificate MarriageCertificate { get; set; }
        public bool IsALive { get; set; }

    }
}
