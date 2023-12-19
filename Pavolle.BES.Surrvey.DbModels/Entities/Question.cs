using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.DbModels.Entities
{
    [Persistent("questions")]
    public class Question : BaseObject
    {
        public Question(Session session) : base(session)
        {
        }

        [Persistent("question_group_oid")]
        public QuestionGroup QuestionGroup { get; set; }

        [Persistent("text")]
        public string Text { get; set; }

        [Persistent("base64_image_file_path")]
        public string Base64ImagePath { get; set; }

        [Persistent("use_for_analyze")]
        public bool UseForAnalyze { get; set; }

        [Persistent("show_only_image")]
        public bool ShowOnlyImage { get; set; }
    }
}
