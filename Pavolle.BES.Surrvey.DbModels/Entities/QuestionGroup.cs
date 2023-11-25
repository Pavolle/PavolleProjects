using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.DbModels.Entities
{
    [Persistent("question_groups")]
    public class QuestionGroup : BaseObject
    {
        public QuestionGroup(Session session) : base(session)
        {
        }

        [Persistent("survey_oid")]
        public Survey Survey { get; set; }

        [Persistent("group_name")]
        public string GroupName { get; set; }

        [Persistent("creater_user_oid")]
        public long CreaterUserOid { get; set; }

        [Persistent("group_order")]
        public int GroupOrder { get; set; }

        [Persistent("base64_image_file_path")]
        public string Base64ImageFilePath { get; set; }
    }
}
