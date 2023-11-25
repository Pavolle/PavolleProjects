using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.DbModels.Entities
{
    [Persistent("survey_results")]
    public class SurveyResult : BaseObject
    {
        public SurveyResult(Session session) : base(session)
        {
        }

        [Persistent("survey_oid")]
        [Indexed(Name = "index_survey_results_survey", Unique = false)]
        public long SurveyOid { get; set; }

        [Persistent("question_oid")]
        [Indexed(Name = "index_survey_results_question", Unique = false)]
        public long QuestionOid { get; set; }

        [Persistent("answer_oid")]
        public long? AnswerOid { get; set; }

        [Persistent("answer_entry")]
        [Size(2000)]
        public string AnswerEntry { get; set; }
    }
}
