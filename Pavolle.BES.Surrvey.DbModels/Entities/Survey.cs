using DevExpress.Xpo;
using Pavolle.BES.Surrvey.Common.Enums;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.DbModels.Entities
{
    [Persistent("surveys")]
    public class Survey : BaseObject
    {
        public Survey(Session session) : base(session)
        {
        }

        //Her araştırmaya özgü kod üretilecek. Bu kod daha sonra web sitelerinde kullanılabilmek için eklendi.
        [Persistent("code")]
        [Size(50)]
        public string Code { get; set; }

        [Persistent("encrypt_string_content")]
        public bool EncryptStringContent { get; set; }

        [Persistent("header")]
        [Size(500)]
        public string Header { get; set; }

        [Persistent("about")]
        [Size(2000)]
        public string About { get; set; }

        [Persistent("creator_organization_oid")]
        public long CreatorOrganizationOid { get; set; }

        [Persistent("research_owner_organization_oid")]
        public long? ResearchOwnerOrganizationOid { get; set; }

        [Persistent("creator_user_oid")]
        public long CreatorUserOid { get; set; }


        //Bütün string verileri translate servera atacak Cevaplar dışında
        //Aynı zamanda form oluştururken bu dilde veriler olacak.
        //Sadece belirli 
        [Persistent("multilanguage")]
        public bool MultiLanguage { get; set; } 

        [Persistent("createdlanguage")]
        public ELanguage? CreatedLanguage { get; set; }

        [Persistent("base64_image_file_path")]
        [Size(255)]
        public string Base64ImageFilePath { get; set; }


        [Persistent("approved")]
        public bool Approved { get; set; }

        [Persistent("approved_user_oid")]
        public long? ApprovedUserOid { get; set; }

        [Persistent("approved_time")]
        public DateTime? ApprovedTime { get; set; }


        [Persistent("started")]
        public bool Started { get; set; }

        [Persistent("transaction_count")]
        public long TransactionCount { get; set; }


        [Persistent("completed")]
        public bool Completed { get; set; }

        [Persistent("completed_user_oid")]
        public long? CompletedUserOid { get; set; }

        [Persistent("completed_time")]
        public DateTime? CompletedTime { get; set; }
    }
}
