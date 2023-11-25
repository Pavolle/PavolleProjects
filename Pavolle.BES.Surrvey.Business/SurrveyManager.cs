using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.BES.Surrvey.DbModels;
using Pavolle.BES.Surrvey.DbModels.Entities;
using Pavolle.BES.Surrvey.ViewModels.Criteria;
using Pavolle.BES.Surrvey.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using Pavolle.BES.Surrvey.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.Surrvey.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Response;

namespace Pavolle.BES.Surrvey.Business
{
    //Araştırma bilgiler cache'de tutulacak.
    public class SurrveyManager : Singleton<SurrveyManager>
    {
        private SurrveyManager() { }

        public BesResponseBase Edit(long? oid, EditSurveyRequest request)
        {
            throw new NotImplementedException();
        }

        public BesResponseBase Add(AddSurveyRequest request)
        {
            throw new NotImplementedException();
        }

        public SurveyListResponse List(ListSurveyCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(LookupSurveyCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public SurveyDetailResponse Detail(long? oid, BesRequestBase request)
        {
            throw new NotImplementedException();
        }



        private Tuple<bool, string> GenerateSurveyCode(Session session)
        {
            bool isSuccess = false;
            string code = "";

            code = Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(2, 16);
            isSuccess = !session.Query<Survey>().Any(t => t.Code == code);
            if (!isSuccess) { code = ""; }

            return new Tuple<bool, string>(isSuccess, code);
        }

        public List<DailyTransactionCountViewData> GetDailyTransactionCountForSurvey(Session session, long surveyOid)
        {
            return session.Query<SurveyResult>()
                .Where(t=>t.Survey.Oid== surveyOid)
                .GroupBy(m => new { m.SurveyTime })
                .Select(t => new DailyTransactionCountViewData
                    {
                        Date = t.Key.SurveyTime,
                        TransactionCount=t.Count()
                    }).ToList();
        }
    }
}