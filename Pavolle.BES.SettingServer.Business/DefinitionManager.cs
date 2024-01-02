using log4net;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.SettingServer.Business
{
    public class DefinitionManager : Singleton<DefinitionManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(DefinitionManager));
        private DefinitionManager()
        {
            _log.Debug("Initialize " + nameof(DefinitionManager));
        }

        public object GetSettingsCategoriesList()
        {
            var response = new LookupResponse();
            try
            {
                response.DataList = Enum.GetValues(typeof(ESettingCategory)).Cast<ESettingCategory>().ToList().Select(t => new LookupViewData
                {
                    Key = (int)t,
                    Value = t.Description(),
                    IsDefault = false
                }).ToList();
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured: " + ex);
                response.ErrorMessage = "Unexpected Error Occured!";
                response.StatusCode = 500;
            }
            return response;
        }

        public LookupResponse GetSettingsTypeList()
        {
            var response = new LookupResponse();
            try
            {
                response.DataList = Enum.GetValues(typeof(ESettingType)).Cast<ESettingType>().ToList().Select(t => new LookupViewData
                {
                    Key = (int)t,
                    Value = t.Description(),
                    IsDefault = false
                }).ToList();
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured: " + ex);
                response.ErrorMessage = "Unexpected Error Occured!";
                response.StatusCode = 500;
            }
            return response;
        }
    }
}
