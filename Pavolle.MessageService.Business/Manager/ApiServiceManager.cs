using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.Core.Enums;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System.Collections.Concurrent;

namespace Pavolle.MessageService.Business.Manager
{
    public class ApiServiceManager:Singleton<ApiServiceManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ApiServiceManager));
        ConcurrentDictionary<long, AuhtorizationCacheModel> _services;
        private ApiServiceManager()
        {
            LoadAuthorizations();
            _log.Debug("Inialize " + nameof(ApiServiceManager));
        }

        public void LoadAuthorizations()
        {
            try
            {
                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var services = session.Query<Auth>().Select(t => new AuhtorizationCacheModel
                    {
                        Oid = t.Oid,
                        ApiKey = t.ApiService.ApiKey,
                        IsAuthority = t.IsAuhtority,
                        UserGroupOid = t.UserGroup.Oid,
                        MethodType = t.ApiService.MethodType
                    }).ToList();

                    _services = new ConcurrentDictionary<long, AuhtorizationCacheModel>();
                    foreach (var item in services)
                    {
                        _services.TryAdd(item.Oid, item);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
            }
        }

        public ApiServiceListResponse List(ListApiServiceCriteria criteria)
        {
            var response=new ApiServiceListResponse();

            try
            {
                if (criteria == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (criteria.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    criteria.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    IQueryable<ApiService> query = session.Query<ApiService>();
                    if (!string.IsNullOrEmpty(criteria.ApiKeyContains))
                    {
                        query = query.Where(t => t.ApiKey.Contains(criteria.ApiKeyContains));
                    }
                    if (!string.IsNullOrEmpty(criteria.DefinitionContains))
                    {
                        query = query.Where(t => t.ApiDefinition.Contains(criteria.DefinitionContains));
                    }
                    response.DataList = query.Select(t => new ApiServiceViewData
                    {
                        Oid = t.Oid,
                        CreatedTime = t.CreatedTime,
                        LastUpdateTime = t.LastUpdateTime,
                        ApiKey = t.ApiKey,
                        ApiDefinition = t.ApiDefinition,
                        MethodType = t.MethodType,
                        EditableForAdmin = t.EditableForAdmin,
                        EditableForOrganization = t.EditableForOrganization,
                        Anonymous = t.Anonymous
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public ApiServiceDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            var response = new ApiServiceDetailResponse();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (request.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    request.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    response.Detail = session.Query<ApiService>().Where(t=>t.Oid==oid).Select(t=>new ApiServiceDetailViewData
                    {
                        Oid = t.Oid,
                        CreatedTime = t.CreatedTime,
                        LastUpdateTime = t.LastUpdateTime,
                        ApiKey = t.ApiKey,
                        ApiDefinition = t.ApiDefinition,
                        MethodType = t.MethodType,
                        EditableForAdmin = t.EditableForAdmin,
                        EditableForOrganization = t.EditableForOrganization,
                        Anonymous = t.Anonymous
                    }).FirstOrDefault();

                    if (response.Detail == null)
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.ApiService);
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public MessageServiceResponseBase Edit(long? oid, EditApiServiceRequest request)
        {
            var response = new ApiServiceDetailResponse();

            try
            {
                if (request == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                    _log.Error("Criteria is null");
                    return response;
                }

                if (request.Language == null)
                {
                    _log.Warn("Request language is null. Setted default language.");
                    request.Language = SettingManager.Instance.GetDefaultLanguage();
                }

                string checkResult = ValidationManager.Instance.CheckString(request.ApiDefinition, false, 5, 255, true, EMessageServiceMessageCode.ApiDefinition, request.Language.Value);
                if (checkResult != null)
                {
                    _log.Error("Request Validation Error: " + checkResult);
                    response.ErrorMessage = checkResult;
                    return response;
                }

                checkResult = ValidationManager.Instance.CheckForNull(request.Auhtorizations, EMessageServiceMessageCode.Auhtorizations, request.Language.Value);
                if (checkResult != null)
                {
                    _log.Error("Request Validation Error: " + checkResult);
                    response.ErrorMessage = checkResult;
                    return response;
                }
                checkResult = ValidationManager.Instance.CheckForOidNull(oid, EMessageServiceMessageCode.ApiService, request.Language.Value);
                if (checkResult != null)
                {
                    _log.Error("Request Validation Error: " + checkResult);
                    response.ErrorMessage = checkResult;
                    return response;
                }

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    var data = session.Query<ApiService>().FirstOrDefault(t => t.Oid == oid);

                    if (data == null)
                    {
                        response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageServiceMessageCode.ApiService);
                        return response;
                    }
                    session.BeginTransaction();

                    data.ApiDefinition = request.ApiDefinition;
                    data.LastUpdateTime = DateTime.Now;
                    data.Save();

                    foreach (var auth in request.Auhtorizations)
                    {
                        var dbAuthData = session.Query<Auth>().FirstOrDefault(t => t.UserGroup.Oid == auth.UserGroupOid && t.ApiService.Oid == oid);
                        if(dbAuthData == null)
                        {
                            var userGroup = session.Query<UserGroup>().FirstOrDefault(t => t.Oid == auth.UserGroupOid);
                            new Auth(session)
                            {
                                UserGroup = userGroup,
                                ApiService = data,
                                IsAuhtority = auth.IsAuthority
                            }.Save();
                        }
                        else
                        {
                            if (dbAuthData.IsAuhtority != auth.IsAuthority)
                            {
                                dbAuthData.IsAuhtority = auth.IsAuthority;
                                dbAuthData.LastUpdateTime = DateTime.Now;
                                dbAuthData.Save();
                            }
                        }
                    }

                    session.CommitTransaction();
                }

                LoadAuthorizations();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageServiceMessageCode.UnexpectedError, request.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        internal List<UserAuthViewData>? GetAuthList(long userGroupOid)
        {
            return _services.ToList().Where(t => t.Value.UserGroupOid == userGroupOid).Select(t => new UserAuthViewData
            {
                ApiKey = t.Value.ApiKey,
                IsAuthority = t.Value.IsAuthority
            }).ToList();
        }
    }
}
