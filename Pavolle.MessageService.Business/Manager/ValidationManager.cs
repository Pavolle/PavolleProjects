using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.DbModels;
using Pavolle.MessageService.DbModels.Entities;
using Pavolle.MessageService.DbModels.Manager;
using Pavolle.MessageService.ViewModels.Criteria;
using Pavolle.MessageService.ViewModels.Model;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using Pavolle.MessageService.ViewModels.ViewData;
using System.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class ValidationManager:Singleton<ValidationManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ValidationManager));
        private ValidationManager() 
        {
            _log.Debug("Initialize "+nameof(ValidationManager));
        }

        public string? CheckString(string? text, bool nullable, int minLength, int maxLength, bool xssControl, EMessageCode messageCode, ELanguage language)
        {
            try
            {
                string? response = null;
                if (!nullable)
                {
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        response = string.Format(TranslateManager.Instance.GetXCannotBeLeftBlankMessage(language, messageCode));
                        return response;
                    }
                    else
                    {
                        if (text.Length < minLength)
                        {
                            response = string.Format(TranslateManager.Instance.GetXNotTheExpectedLengthMessage(language, messageCode));
                            return response;
                        }

                        if (text.Length > maxLength)
                        {
                            response = string.Format(TranslateManager.Instance.GetXNotTheExpectedLengthMessage(language, messageCode));
                            return response;
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        return null;
                    }
                    else
                    {
                        if (text.Length < minLength)
                        {
                            response = string.Format(TranslateManager.Instance.GetXNotTheExpectedLengthMessage(language, messageCode));
                            return response;
                        }

                        if (text.Length > maxLength)
                        {
                            response = string.Format(TranslateManager.Instance.GetXNotTheExpectedLengthMessage(language, messageCode));
                            return response;
                        }

                        if (xssControl && text.Contains("<") && text.Contains(">"))
                        {
                            return TranslateManager.Instance.GetMessage(EMessageCode.SecurityError, language);
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
                return null;
            }
        }

        public string? CheckEnum<T>(int? enumValue, bool nullable, EMessageCode messageCode, ELanguage language)
        {
            try
            {
                string? response = null;
                if (nullable)
                {
                    if (!enumValue.HasValue) { return null; }
                    else
                    {
                        if (!Enum.GetValues(typeof(T)).Cast<T>().Select(t => Convert.ToInt32(t)).ToList().Contains(enumValue.Value))
                        {
                            response = string.Format(TranslateManager.Instance.GetXNotValidMessage(language, messageCode));
                            return response;
                        }
                    }
                }
                else
                {
                    if (enumValue == null)
                    {
                        response = string.Format(TranslateManager.Instance.GetXCannotBeLeftBlankMessage(language, messageCode));
                        return response;
                    }
                    else
                    {
                        if (!Enum.GetValues(typeof(T)).Cast<T>().Select(t => Convert.ToInt32(t)).ToList().Contains(enumValue.Value))
                        {
                            response = string.Format(TranslateManager.Instance.GetXNotValidMessage(language, messageCode));
                            return response;
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
                return null;
            }
        }

        public string? CheckForNull(object objectData, EMessageCode messageCode, ELanguage language)
        {
            try
            {
                string? response = null;
                if (objectData == null)
                {
                    response = TranslateManager.Instance.GetXNotFoundMessage(language, messageCode);
                }
                return response;
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
                return null;
            }
        }

        internal string? CheckForOidNull(long? oid, EMessageCode messageCode, ELanguage language)
        {
            try
            {
                string? response = null;
                if (oid == null)
                {
                    response = TranslateManager.Instance.GetXNotFoundMessage(language, messageCode);
                }
                return response;
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! Error: " + ex);
                return null;
            }
        }
    }
}
