﻿using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.TranslateServer.ViewModels.Model;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.ClientLib
{
    public class TranslateServiceManager : Singleton<TranslateServiceManager>
    {
        List<TranslateDataCacheModel> _translateData;
        private TranslateServiceManager() { }
        string _serverUrl;
        public void Initialize(string serverUrl) 
        {
            _serverUrl = serverUrl;
        }

        public string GetMessage(EMessageCode messageCode, ELanguage language)
        {
            return GetMessage(messageCode.ToString(), language);
        }

        public string GetMessage(string messageCode, ELanguage language)
        {
            var data = _translateData.FirstOrDefault(t => t.Variable == messageCode);
            if(data == null)
            {
                return messageCode;
            }
            switch (language)
            {
                case ELanguage.English:
                    return string.IsNullOrWhiteSpace( data.EN) ? string.Empty : data.EN;
                case ELanguage.Russian:
                    return string.IsNullOrWhiteSpace(data.RU) ? string.Empty : data.RU;
                case ELanguage.Turkish:
                    return string.IsNullOrWhiteSpace(data.TR) ? string.Empty : data.TR;
                case ELanguage.Azerbaijani:
                    return string.IsNullOrWhiteSpace(data.AZ) ? string.Empty : data.AZ;
                case ELanguage.Spanish:
                    return string.IsNullOrWhiteSpace(data.ES) ? string.Empty : data.ES;
                case ELanguage.French:
                    return string.IsNullOrWhiteSpace(data.FR) ? string.Empty : data.FR;
                case ELanguage.German:
                    return string.IsNullOrWhiteSpace(data.DE) ? string.Empty : data.DE;
                    default: return messageCode;
            }
        }
    }
}