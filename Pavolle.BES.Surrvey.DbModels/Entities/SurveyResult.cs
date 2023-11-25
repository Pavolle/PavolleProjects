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
        public Survey Survey { get; set; }

        [Persistent("survey_time")]
        public DateTime SurveyTime { get; set; }

        [Persistent("anonymous")]
        public bool Anonymous { get; set; }

        [Persistent("total")]
        public double Total { get; set; }

        [Persistent("answering_organization_oid")]
        public long? AnsweringOrganizationOid { get; set; }

        [Persistent("answering_person_oid")]
        public long? AnsweringPersonOid { get; set; }
    }
}
