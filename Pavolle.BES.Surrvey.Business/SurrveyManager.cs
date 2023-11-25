using DevExpress.Xpo;
using Pavolle.Core.Utils;
using Pavolle.BES.Surrvey.DbModels;
using Pavolle.BES.Surrvey.DbModels.Entities;

namespace Pavolle.BES.Surrvey.Business
{
    //Araştırma bilgiler cache'de tutulacak.
    public class SurrveyManager : Singleton<SurrveyManager>
    {
        private SurrveyManager() { }

        public Tuple<bool,string> GenerateSurveyCode(Session session)
        {
            bool isSuccess=false;
            string code = "";

            code = Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(2, 16);
            isSuccess = !session.Query<Survey>().Any(t => t.Code == code);
            if(!isSuccess) { code = ""; }

            return new Tuple<bool, string>(isSuccess, code);
        }
    }
}