using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pavolle.MessageService.Business.Manager
{
    public class SettingServiceManager : Singleton<SettingServiceManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SettingServiceManager));
        private SettingServiceManager() 
        { 
        }

        public SettingListResponse List(ListSettingCriteria criteria)
        {
            var response = new SettingListResponse();
            if (criteria == null)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                _log.Error("Criteria is null");
                return response;
            }

            if (criteria.Language == null)
            {
                _log.Warn("Request language is null. Setted default language.");
                criteria.Language = SettingManager.Instance.GetDefaultLanguage();
            }

            response = new SettingListResponse
            {
                DataList = SettingManager.Instance.GetSettings().Select(t => new SettingViewData
                {
                    Oid = t.Oid,
                    Value = t.Value,
                    SettingName = t.SettingName,
                    CreatedTime = t.CreatedTime,
                    LastUpdateTime = t.LastUpdateTime
                }).ToList()
            };
            return response;
        }

        public SettingDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            var response = new SettingDetailResponse();
            if (request == null)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                _log.Error("Request is null");
                return response;
            }

            if (request.Language == null)
            {
                _log.Warn("Request language is null. Setted default language.");
                request.Language = SettingManager.Instance.GetDefaultLanguage();
            }

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var data = session.Query<Setting>().FirstOrDefault(t => t.Oid == oid);
                if (data == null)
                {
                    response.ErrorMessage = TranslateManager.Instance.GetXNotFoundMessage(request.Language.Value, EMessageCode.City);
                    return response;
                }

                response.Detail = new SettingDetailViewData
                {
                    Oid = data.Oid,
                    CreatedTime = data.CreatedTime,
                    LastUpdateTime = data.LastUpdateTime,
                    SettingName = data.SettingName,
                    SettingType = data.SettingType,
                    Value = data.Value
                };

                response.ChangeLogs = session.Query<SettingChangeLog>().Where(t => t.Setting.Oid == data.Oid).Select(t => new SettingChangeLogViewData
                {
                    Oid = t.Oid,
                    CreatedTime = t.CreatedTime,
                    LastUpdateTime = t.LastUpdateTime,
                    NewValue = t.NewValue,
                    OldValue = t.OldValue,
                    User = t.User.Name + " " + t.User.Surname
                }).ToList();
            }
            return response;
        }

        public MessageServiceResponseBase Edit(long? oid, EditSettingRequest request)
        {
            var response = new MessageServiceResponseBase();
            if (request == null)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, SettingManager.Instance.GetDefaultLanguage());
                _log.Error("Request is null");
                return response;
            }

            if (request.Language == null)
            {
                _log.Warn("Request language is null. Setted default language.");
                request.Language = SettingManager.Instance.GetDefaultLanguage();
            }
            return response;
        }
    }
}
