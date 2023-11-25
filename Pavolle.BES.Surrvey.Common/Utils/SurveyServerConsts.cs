using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.Common.Utils
{
    public class SurveyServerConsts
    {
        public class SurveyIntegrationServiceConsts
        {
            public const string SurveyRoute = "api/surveyintegrationservice/survey";
            public const string PrintSurveyRoute = "api/surveyintegrationservice/printsurvey";
            public const string AnswerRoute= "api/surveyintegrationservice/answer";
            public const string QuestionRoute = "api/surveyintegrationservice/question";
            public const string QuestionGroupRoute = "api/surveyintegrationservice/questiongroup";
            public const string ServerStatusRoute = "api/surveyintegrationservice/serverstatus";
        }


        public class SurveyConsts
        {
            public const string AddRoutePrefix = "add";
            public const string EditRoutePrefix = "edit/{oid}";
            public const string DetailRoutePrefix = "detail/{oid}";
            public const string ApproveRoutePrefix = "approve/{oid}";
            public const string CompleteRoutePrefix = "complete/{oid}";
        }
    }
}
