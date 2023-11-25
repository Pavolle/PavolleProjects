using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.DbModels.Entities
{
    [Persistent("answers")]
    public class Answer : BaseObject
    {
        public Answer(Session session) : base(session)
        {
        }

        [Persistent("text")]
        public string Text { get; set; }

        [Persistent("correct_answer")]
        public bool CorrectAnswer { get; set; }

        [Persistent("base64_image_file_path")]
        public string Base64ImagePath { get; set; }
    }
}
