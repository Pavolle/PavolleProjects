using DevExpress.Xpo;
using log4net;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.GeoServer.DbModels;
using Pavolle.BES.GeoServer.DbModels.Entities;
using Pavolle.BES.GeoServer.ViewModels.Model;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class CountryManager : Singleton<CountryManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        ConcurrentDictionary<long, CountryCacheModel> _countries;
        private CountryManager() { }

        public void Initilaize()
        {
            using(Session session = GeoServerXpoManager.Instance.GetNewSession())
            {
                var countryList=session.Query<Country>().ToList();

                foreach (var country in countryList)
                {
                    var cacheData = new CountryCacheModel
                    {
                        Oid = country.Oid,
                        IsoCode2 = country.IsoCode2,
                        IsoCode3 = country.IsoCode3,
                        PhoneCode = country.PhoneCode,
                        FlagPath = country.FlagPath
                    };

                    _countries.TryAdd(cacheData.Oid, cacheData);
                }
            }
        }

        public BesAddRecordResponseBase AddCountry(AddCountryRequest request)
        {
            var response = new BesAddRecordResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    if(session.Query<Country>().Any(t=>t.IsoCode2== request.IsoCode2))
                    {
                        response.ErrorMessage= TranslateServiceManager.Instance.GetMessage(EMessageCode.DataCreatedBefore, request.Language.Value);
                        response.StatusCode = 400;
                        return response;
                    }

                    var addCountryNameResponse = TranslateServiceManager.Instance.SaveNewData(request.Name, request.Language, EBesAppType.GeolocationServer);
                    if(addCountryNameResponse == null || !addCountryNameResponse.Success)
                    {
                        _log.Error("Translate Server ERROR");
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    //resmi sadece dosyaya kaydetme kararı verdik. Şuanda DYS tarafına kaydetmeye gerek yok. O yüzden dosyaya kaydetip devam edeceğiz.
                    string directory = SettingServiceManager.Instance.GetSetting(ESettingType.GeolocationCountryFlagBaseUrl);
                    string filePath = directory + request.IsoCode2.ToLower() + ".png";
                    if (Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    if (!string.IsNullOrWhiteSpace(request.Base64Flag))
                    {
                        File.WriteAllText(filePath, request.Base64Flag);
                    }

                    new Country(session)
                    {
                        NameTranslateDataOid = addCountryNameResponse.RecordOid.Value,
                        IsoCode2 = request.IsoCode2,
                        IsoCode3 = request.IsoCode3,
                        FlagPath = filePath,
                        PhoneCode = request.PhoneCode
                    }.Save();

                    _log.Info("Country saved to DB. Country => " + request.Name);
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

        public ResponseBase Delete(long? oid, IntegrationAppRequestBase request)
        {
            var response = new BesAddRecordResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {

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

        public CityDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            var response = new CityDetailResponse();

            return response;
        }

        public ResponseBase Edit(long? oid, EditCountryRequest request)
        {
            var response = new BesAddRecordResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {

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

        public ImageLookupResponse ImageLookup(IntegrationAppRequestBase criteria)
        {
            var response = new ImageLookupResponse();

            return response;
        }

        public CountryListResponse List(IntegrationAppRequestBase criteria)
        {
            var response = new CountryListResponse();

            return response;
        }

        public LookupResponse Lookup(IntegrationAppRequestBase criteria)
        {
            var response = new LookupResponse();

            return response;
        }
    }
}
