﻿using Pavolle.Core.Utils;
using Pavolle.BES.Surrvey.DbModels;
using Pavolle.BES.Surrvey.DbModels.Entities;
using Pavolle.BES.Surrvey.ViewModels.Criteria;
using Pavolle.BES.Surrvey.ViewModels.Response;
using Pavolle.Core.ViewModels.Response;
using Pavolle.BES.Surrvey.ViewModels.Request;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.Surrvey.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Response;
using log4net;
using DevExpress.Xpo;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.Core.ViewModels.Request;

namespace Pavolle.BES.Surrvey.Business
{
    //Araştırma bilgiler cache'de tutulacak.
    public class SurrveyManager : Singleton<SurrveyManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SurrveyManager));
        private SurrveyManager() { }

        public SurveyListResponse List(ListSurveyCriteria criteria)
        {
            var response = new SurveyListResponse();
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error("Unecpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }

        public LookupResponse Lookup(LookupSurveyCriteria criteria)
        {
            var response = new LookupResponse();
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error("Unecpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }

        public SurveyDetailResponse Detail(long? oid, BesRequestBase request)
        {
            var response = new SurveyDetailResponse();
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error("Unecpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }

        public BesResponseBase Add(AddSurveyRequest request)
        {
            var response=new BesResponseBase();
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error("Unecpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }

        public BesResponseBase Edit(long? oid, EditSurveyRequest request)
        {
            var response = new BesResponseBase();
            try
            {

            }
            catch (Exception ex)
            {
                _log.Error("Unecpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            return response;
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