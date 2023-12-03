using DevExpress.Xpo;
using log4net;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.DbModels;
using Pavolle.BES.SettingServer.DbModels.Entities;
using Pavolle.BES.SettingServer.ViewModels.Model;
using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Business
{
    public class SettingsServerManager : Singleton<SettingsServerManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SettingsServerManager));
        private ConcurrentDictionary<ESettingType, SettingCacheModel> _settings;
        private SettingsServerManager()
        {

        }

        public void Initialize()
        {
            _log.Debug("Starting Initialize " + nameof(SettingsServerManager));

            _settings = new ConcurrentDictionary<ESettingType, SettingCacheModel>();

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var settingList = session.Query<Setting>().Select(t => new SettingCacheModel
                {
                    Oid = t.Oid,
                    SettingType = t.SettingType,
                    Value = t.Value,
                    SettingName = t.SettingType.Description(),
                    CreatedTime = t.CreatedTime,
                    LastUpdateTime = t.LastUpdateTime,
                    BesAppType = t.BesAppType
                });

                foreach (var setting in settingList)
                {
                    _settings.TryAdd(setting.SettingType, setting);
                }
                _settings.TryAdd(ESettingType.DbConnection, new SettingCacheModel
                {
                    CreatedTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Oid = 0,
                    SettingType = ESettingType.DbConnection,
                    SettingName = "Db Connection",
                    Value = SettingsServerDbManager.Instance.GetConnectionString(),
                });

            }
            _log.Debug("Done Initialize " + nameof(SettingsServerManager));
        }

        public SettingDetailResponse Detail(int setting_type, IntegrationAppRequestBase request)
        {
            var response = new SettingDetailResponse()
            {
                Detail = new SettingViewData(),
                ChangeLogs = new List<SettingChangeLogViewData>()
            };

            using (Session session = XpoManager.Instance.GetNewSession())
            {
                response.Detail = session.Query<Setting>().Where(t => t.SettingType == (ESettingType)setting_type)
                    .Select(t => new SettingViewData
                    {
                        SettingType = t.SettingType,
                        Value = t.Value,
                        SettingTypeName = t.SettingType.Description()
                    }).FirstOrDefault();

                response.ChangeLogs = session.Query<SettingChangeLog>().Where(t => t.Setting.SettingType == (ESettingType)setting_type).Select(t => new SettingChangeLogViewData
                {
                    ChangeTime = t.CreatedTime,
                    OldValue = t.OldValue,
                    NewValue = t.NewValue,
                }).ToList();
            }

            return response;
        }

        public ResponseBase Edit(int setting_type, SettingRequest request)
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                if(setting_type== (int)ESettingType.DbConnection)
                {
                    return new ResponseBase
                    {
                        ErrorMessage = "Db Connection can not be changed!"
                    };
                }


                var setting = session.Query<Setting>().FirstOrDefault(t => t.SettingType == (ESettingType)setting_type);
                if (setting==null)
                {
                    return new ResponseBase
                    {
                        ErrorMessage = "Record not found!"
                    };
                }
                bool updated = true;

                session.BeginTransaction();
                new SettingChangeLog(session)
                {
                    Setting = setting,
                    NewValue = request.Value,
                    OldValue = setting.Value
                }.Save();

                setting.Value= request.Value;
                setting.LastUpdateTime= DateTime.Now;
                setting.Save();
                session.CommitTransaction();
            }


            Initialize();

            return new ResponseBase
            {
                SuccessMessage = "Data changed successfully"
            };
        }

        public SettingListResponse List(IntegrationAppRequestBase request)
        {
            return new SettingListResponse
            {
                DataList = _settings.Values.Select(t => new SettingViewData
                {
                    SettingType = t.SettingType,
                    Value = t.Value,
                    SettingTypeName = t.SettingName
                }).ToList()
            };
        }
    }
}
