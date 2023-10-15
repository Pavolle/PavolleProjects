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
    public class CountryManager:Singleton<CountryManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        private CountryManager() { }

        public CountryListResponse List(ListCountryCriteria criteria)
        {
            var response = new CountryListResponse();

            try
            {
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

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    List<Country> query = session.Query<Country>().ToList();
                    response.DataList = new List<CountryViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new CountryViewData
                        {
                            Oid = item.Oid,
                            CreatedTime = item.CreatedTime,
                            LastUpdateTime = item.LastUpdateTime,
                            Name = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public LookupResponse Lookup(LookupCountryCriteria criteria)
        {
            var response = new LookupResponse();

            try
            {
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

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    List<Country> query = session.Query<Country>().ToList();
                    response.DataList = new List<LookupViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new LookupViewData
                        {
                            Key = item.Oid,
                            Value = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value),
                            IsDefault = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public ImageLookupResponse ImageLookup(LookupCountryCriteria criteria)
        {
            var response = new ImageLookupResponse();

            try
            {
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

                using (Session session = XpoManager.Instance.GetNewSession())
                {
                    List<Country> query = session.Query<Country>().ToList();
                    response.DataList = new List<ImageLookupViewData>();
                    foreach (var item in query.ToList())
                    {
                        response.DataList.Add(new ImageLookupViewData
                        {
                            Key = item.Oid,
                            Value = TranslateManager.Instance.GetMessage(item.Name.Variable, criteria.Language.Value),
                            ImageBase64=item.FlagBase64,
                            IsDefault = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = TranslateManager.Instance.GetMessage(EMessageCode.UnexpectedError, criteria.Language.Value);
                _log.Debug("Unexpected error occured!!! Error: " + ex);
            }

            return response;
        }

        public CountryDetailResponse Detail(long? oid, MessageServiceRequestBase request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Add(AddCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Edit(long? oid, EditCountryRequest request)
        {
            throw new NotImplementedException();
        }

        public MessageServiceResponseBase Delete(long? oid, DeleteCountryCriteria request)
        {
            throw new NotImplementedException();
        }
    }
}
