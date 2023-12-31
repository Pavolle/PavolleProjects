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
using System.ComponentModel.DataAnnotations;
using Pavolle.BES.RequestValidation;
using Pavolle.BES.LogServer.ClientLib;
using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.BES.AuthServer.ClientLib;
using Pavolle.Core.ViewModels.ViewData;

namespace Pavolle.BES.Surrvey.Business
{
    //Araştırma bilgiler cache'de tutulacak.
    public class SurveyManager : Singleton<SurveyManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SurveyManager));
        private SurveyManager() { }

        public SurveyListResponse List(ListSurveyCriteria criteria)
        {
            var response = new SurveyListResponse();
            try
            {
                using(Session session = XpoManager.Instance.GetNewSession())
                {
                    IQueryable<Survey> query = session.Query<Survey>();
                    long? organizationOid = criteria.OrganizationOid;
                    if(criteria.UserType==EUserType.Admin ||criteria.UserType==EUserType.SystemAdmin)
                    {
                        if (criteria.SelectedOrganizationOid != null)
                        {
                            query = query.Where(t => t.CreatorOrganizationOid == criteria.SelectedOrganizationOid);
                        }
                    }
                    else
                    {
                        query = query.Where(t => t.CreatorOrganizationOid == criteria.OrganizationOid);
                    }

                    if(criteria.StatusList !=null && criteria.StatusList.Count> 0)
                    {
                        query=query.Where(t=>criteria.StatusList.Contains(t.Status));
                    }

                    var dataList = query.Select(t => new
                    {
                        t.Oid,
                        t.CreatedTime,
                        t.LastUpdateTime,
                        t.Code,
                        t.Status,
                        t.CreatorOrganizationOid,
                        t.ResearchOwnerOrganizationOid,
                        t.CreatorUserOid,
                        t.MultiLanguage,
                        t.TransactionCount,
                        t.Header
                    }).ToList();


                    response.DataList = new List<SurveyViewData>();
                    foreach (var item in dataList)
                    {
                        var data = new SurveyViewData();
                        data.Oid = item.Oid;
                        data.CreatedTime = item.CreatedTime;
                        data.LastUpdateTime = item.LastUpdateTime;
                        data.Code = item.Code;
                        data.Status = item.Status;
                        data.Multilanguage = item.MultiLanguage;
                        data.TransactionCount=item.TransactionCount;

                        if (item.MultiLanguage)
                        {
                            data.Header= TranslateServiceManager.Instance.GetMessage(item.Header, criteria.Language.Value);
                        }
                        else
                        {
                            data.Header=item.Header;
                        }

                        data.OrganizationName = AuthServerOrganizationServiceManager.Instance.GetOrganizationNameFromOid(item.CreatorOrganizationOid);
                        data.CreatorUser= AuthServerUserServiceManager.Instance.GetUserNameAndSurnameFromOid(item.CreatorUserOid);
                        data.SurveyOwnerOrganizationName = item.ResearchOwnerOrganizationOid.HasValue ? AuthServerOrganizationServiceManager.Instance.GetOrganizationNameFromOid(item.ResearchOwnerOrganizationOid.Value) : "";

                        response.DataList.Add(data);

                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                LogServiceManager.Instance.SystemError("Unexpected error occured! Message: " + ex.Message + " StackTrace: " + ex.StackTrace);
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
                using(Session session =XpoManager.Instance.GetNewSession())
                {
                    IQueryable<Survey> query = session.Query<Survey>();
                    long? organizationOid = criteria.OrganizationOid;
                    if (criteria.UserType == EUserType.Admin || criteria.UserType == EUserType.SystemAdmin)
                    {
                        if (criteria.SelectedOrganizationOid != null)
                        {
                            query = query.Where(t => t.CreatorOrganizationOid == criteria.SelectedOrganizationOid);
                        }
                    }
                    else
                    {
                        query = query.Where(t => t.CreatorOrganizationOid == criteria.OrganizationOid);
                    }

                    var dataList = query.Select(t => new
                    {
                        t.Oid,
                        t.CreatedTime,
                        t.LastUpdateTime,
                        t.Code,
                        t.Status,
                        t.CreatorOrganizationOid,
                        t.ResearchOwnerOrganizationOid,
                        t.CreatorUserOid,
                        t.MultiLanguage,
                        t.TransactionCount,
                        t.Header
                    }).ToList();

                    //TODO Kontrol edip gerekirse burada foreach ile döneceğiz.
                    response.DataList = dataList.Select(t => new LookupViewData
                    {
                        IsDefault = false,
                        Key = t.Oid,
                        Value = TranslateServiceManager.Instance.GetMessage(t.Header, criteria.Language.Value),
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
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
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }

        public BesResponseBase Add(AddSurveyRequest request)
        {
            var response=new BesResponseBase();

            //Request Check
            BesValidationResult validationResult = new BesValidationResult();
            validationResult = StringValidationManager.Instance.Validate(request.Header, false, 2, 500, EMessageCode.Header, request.Language);
            if(!validationResult.Validated)
            {
                return new BesResponseBase
                {
                    ErrorMessage = validationResult.Message,
                    StatusCode = 400
                };
            }

            try
            {
                using(Session session= XpoManager.Instance.GetNewSession())
                {
                    string code = "";
                    do
                    {
                        code = GenerateSurveyCode(session).Item2;
                    } while (!string.IsNullOrWhiteSpace(code));

                    if(code != null)
                    {
                        //TODO multilanguage altyapısı eklenmemiş
                        var survey = new Survey(session)
                        {
                            Header = request.Header,
                            About = request.About,
                            MultiLanguage = request.MultiLanguage,
                            CreatedLanguage = request.CreatedLanguage,
                            EncryptStringContent = request.EncryptStringContent,
                            CreatorOrganizationOid = request.OrganizationOid.Value,
                            ResearchOwnerOrganizationOid = request.ResearchOwnerOrganizationOid,
                            Code = code,
                            Approved=false,
                            Completed=false,
                            Started=false,
                            TransactionCount=0
                        };

                        if(request.MultiLanguage)
                        {
                            //TODO Bu kısım değiştirildi. Bakılması lazım.
                            var addStatus = TranslateServiceManager.Instance.SaveNewData(request.Header, request.Language, BES.Common.Enums.EBesAppType.Surrvey).Success;
                        }


                        if (!string.IsNullOrEmpty(request.Base64Image))
                        {
                            string fileName = Guid.NewGuid().ToString() + ".besdata";
                            File.AppendAllText(fileName, request.Base64Image);
                            survey.Base64ImageFilePath = fileName;
                        }
                        survey.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
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
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var survey = session.Query<Survey>().FirstOrDefault(t=>t.Oid == oid);
                    if(survey == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 400;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }
            return response;
        }

        private Tuple<bool, string> GenerateSurveyCode(Session session)
        {
            bool isSuccess = false;
            string? code = null;

            code = Guid.NewGuid().ToString().ToLower().Replace("-", "").Substring(2, 16);
            isSuccess = !session.Query<Survey>().Any(t => t.Code == code);
            if (!isSuccess) { code = string.Empty; }

            return new Tuple<bool, string>(isSuccess, code);
        }

        private List<DailyTransactionCountViewData> GetDailyTransactionCountForSurvey(Session session, long surveyOid)
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