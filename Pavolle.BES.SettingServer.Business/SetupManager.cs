using DevExpress.Xpo;
using log4net;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.SettingServer.DbModels;
using Pavolle.BES.SettingServer.DbModels.Entities;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Business
{
    public class SetupManager : Singleton<SetupManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(SetupManager));
        private SetupManager()
        {

        }

        public void Initialize()
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var settings = session.Query<Setting>().ToList();

                var settingTypes = Enum.GetValues(typeof(ESettingType)).Cast<ESettingType>().ToList();

                foreach (var item in settingTypes)
                {
                    if (!settings.Any(t => t.SettingType == item))
                    {
                        switch (item)
                        {
                            case ESettingType.DbConnection:
                                break;
                            case ESettingType.LogServerUrl:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "https:localhost:1212",
                                }.Save();

                                _log.Info("LogServerUrl değeri https:localhost:1212 olarak ayarlandı.");
                                break;
                            case ESettingType.RabbitMQUsername:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                }.Save();

                                _log.Info("RabbitMQUsername değeri guest olarak ayarlandı.");
                                break;
                            case ESettingType.RabbitMQPassword:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "guest",
                                }.Save();

                                _log.Info("RabbitMQPassword değeri guest olarak ayarlandı.");
                                break;
                            case ESettingType.RabbitMQVHost:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "/",
                                }.Save();

                                _log.Info("RabbitMQVHost değeri \"/\" olarak ayarlandı.");
                                break;
                            case ESettingType.RabbitMQHostname:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "localhost",
                                }.Save();

                                _log.Info("RabbitMQHostname değeri localhost olarak ayarlandı.");
                                break;
                            case ESettingType.RabbitMQPort:
                                new Setting(session)
                                {
                                    SettingType = item,
                                    Value = "5672",
                                }.Save();

                                _log.Info("RabbitMQPort değeri 5672 olarak ayarlandı.");
                                break;

                        }
                    }
                }
            }
        }
    }
}
