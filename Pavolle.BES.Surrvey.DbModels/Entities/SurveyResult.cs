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

        [Persistent("anonymous")]
        public bool Anonymous { get; set; }

        [Persistent("answering_organization_oid")]
        public long? AnsweringOrganization { get; set; }

        [Persistent("answering_person_oid")]
        public long? AnsweringPerson { get; set; }
    }
}
