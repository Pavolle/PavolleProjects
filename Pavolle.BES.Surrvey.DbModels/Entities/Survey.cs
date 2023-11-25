﻿using DevExpress.Xpo;
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

        [Persistent("code")]
        [Size(50)]
        //Her araştırmaya özgü kod üretilecek. Bu kod daha sonra web sitelerinde kullanılabilmek için eklendi.
        public string Code { get; set; }

        [Persistent("header")]
        [Size(500)]
        public string Header { get; set; }

        [Persistent("about")]
        [Size(2000)]
        public string About { get; set; }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }


        //Bütün string verileri translate servera atacak
        //Aynı zamanda form oluştururken bu dilde veriler olacak.
        [Persistent("multilanguage")]
        public bool MultiLanguage { get; set; } 

        [Persistent("createdlanguage")]
        public ELanguage? CreatedLanguage { get; set; }

        [Persistent("creater_user_oid")]
        public long CreaterUserOid { get; set; }

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


        [Persistent("completed")]
        public bool Completed { get; set; }

        [Persistent("completed_user_oid")]
        public long? CompletedOid { get; set; }

        [Persistent("completed_time")]
        public DateTime? CompletedTime { get; set; }
    }
}