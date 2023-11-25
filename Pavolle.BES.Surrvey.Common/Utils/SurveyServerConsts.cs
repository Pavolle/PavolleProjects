using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.Surrvey.Common.Utils
{
    public class SurveyServerConsts
    {
        public const string ListRoutePrefix = "list";
        public const string LookupRoutePrefix = "lookup";
        public const string ImageLookupRoutePrefix = "imagelookup";
        public const string AddRoutePrefix = "add";
        public const string EditRoutePrefix = "edit/{oid}";
        public const string DetailRoutePrefix = "detail/{oid}";

        public class ServerStatusUrlConst
        {
            public const string BaseRoute = "api/surrveyserver/serverstatus";

            public const string ServerDetailRoutePrefix = "detail";
            public const string ServerSettingsRoutePrefix = "settings";
        }


        public class DefinitionConsts
        {
            public const string BaseRoute = "api/surrveyserver/definition";
        }

        public class AnswerConsts
        {
            public const string BaseRoute = "api/surrveyserver/answer";
        }

        public class QuestionConsts
        {
            public const string BaseRoute = "api/surrveyserver/question";
        }

        public class PrintSurveyConsts
        {
            public const string BaseRoute = "api/surrveyserver/printsurvey";
        }

        public class QuestionGroupConsts
        {
            public const string BaseRoute = "api/surrveyserver/questiongroup";
        }

        public class SurveyConsts
        {
            public const string BaseRoute = "api/surrveyserver/survey";

            public const string ApproveRoutePrefix = "approve/{oid}";
            public const string CompleteRoutePrefix = "complete/{oid}";
            public const string ResultRoutePrefix = "result";
        }
    }
}
