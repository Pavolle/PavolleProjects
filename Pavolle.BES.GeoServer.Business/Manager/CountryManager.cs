using DevExpress.Xpo;
using log4net;
using Pavolle.BES.Business.Manager;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.GeoServer.DbModels;
using Pavolle.BES.GeoServer.DbModels.Entities;
using Pavolle.BES.GeoServer.ViewModels.Model;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.GeoServer.ViewModels.ViewData;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.SettingServer.Common.Enums;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.ViewModels.Response;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Core.ViewModels.ViewData;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class CountryManager : Singleton<CountryManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CountryManager));
        ConcurrentDictionary<long?, CountryCacheModel> _countries;
        bool _isCacheInitiliaze = false;
        private CountryManager() 
        { 
            _log.Debug("Initilize " +nameof(CountryManager));
        }

        public void Initilaize()
        {
            _countries = new ConcurrentDictionary<long?, CountryCacheModel>();
            using (Session session = GeoServerXpoManager.Instance.GetNewSession())
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
                        FlagPath = country.FlagPath,
                        CreatedTime=country.CreatedTime,
                        DeletedTime=country.DeletedTime,
                        LastUpdateTime=country.LastUpdateTime,
                        NameTranslateModel = TranslateServiceManager.Instance.GetDataByOid(country.NameTranslateDataOid, EBesAppType.GeolocationServer)
                    };

                    _countries.TryAdd(cacheData.Oid, cacheData);
                }
                _isCacheInitiliaze=true;
            }
        }

        public BesAddRecordResponseBase AddCountry(AddCountryRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
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
                    string filePath = directory + request.IsoCode2.ToLower() + ".txt";
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

            Initilaize();

            return response;
        }

        public ResponseBase Delete(long? oid, IntegrationAppRequestBase request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new BesAddRecordResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var country=session.Query<Country>().FirstOrDefault(t=>t.Oid==oid);
                    if(country==null)
                    {
                        response.ErrorMessage=TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    if (session.Query<City>().Any(t => t.Country.Oid == oid))
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordCannotBeDeleted, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    country.DeletedTime = DateTime.Now;
                    country.Save();

                    country.Delete();
                    _log.Warn("Country deleted succeded. Country Oid => " + country.Oid);
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            Initilaize();

            return response;
        }

        public CountryDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new CountryDetailResponse();
            CountryCacheModel? data = null;
            if (_countries.ContainsKey(oid))
            {
                data = _countries[oid];
            }
            if(data==null)
            {
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                response.StatusCode = 500;
                return response;
            }

            response.Detail = new CountryDetailViewData
            {
                Oid = data.Oid,
                IsoCode2 = data.IsoCode2,
                IsoCode3 = data.IsoCode3,
                CreatedTime = data.CreatedTime,
                Base64Flag = FileDocumentManager.Instance.GetBase64FileFromPath(data.FlagPath),
                Name = TranslateServiceManager.Instance.GetNameFromCacheData(data.NameTranslateModel, request.Language)
            };

            response.CityList = CityManager.Instance.GetCityListForCountry(data.Oid);
            return response;
        }

        public ResponseBase Edit(long? oid, EditCountryRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new BesAddRecordResponseBase();

            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var country = session.Query<Country>().FirstOrDefault(t => t.Oid == oid);
                    if (country == null)
                    {
                        response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, request.Language.Value);
                        response.StatusCode = 500;
                        return response;
                    }

                    var nameTranslateData = TranslateServiceManager.Instance.GetDataByOid(country.NameTranslateDataOid, EBesAppType.GeolocationServer);
                    if (nameTranslateData.Variable != request.Name)
                    {
                        var addCountryNameResponse = TranslateServiceManager.Instance.SaveNewData(request.Name, request.Language, EBesAppType.GeolocationServer);
                        if (addCountryNameResponse == null || !addCountryNameResponse.Success)
                        {
                            _log.Error("Translate Server ERROR");
                            response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                            response.StatusCode = 500;
                            return response;
                        }
                    }

                    string directory = SettingServiceManager.Instance.GetSetting(ESettingType.GeolocationCountryFlagBaseUrl);
                    string filePath = directory + request.IsoCode2.ToLower() + ".txt";
                    if (Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    if (!string.IsNullOrWhiteSpace(request.Base64Flag))
                    {
                        File.WriteAllText(filePath, request.Base64Flag);
                    }

                    country.IsoCode2 = request.IsoCode2;
                    country.IsoCode3 = request.IsoCode3;
                    country.LastUpdateTime = DateTime.Now;
                    country.FlagPath = filePath;
                    country.PhoneCode = request.PhoneCode;

                    country.Save();
                }
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected error occured! " + ex);
                response.ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value);
                response.StatusCode = 500;
            }

            Initilaize();

            return response;
        }

        public ImageLookupResponse ImageLookup(IntegrationAppRequestBase request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new ImageLookupResponse();
            response.DataList = _countries.Values.ToList()
            .Select(t => new ImageLookupViewData
            {
                Key = t.Oid,
                Value = TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, request.Language),
                ImageBase64 = FileDocumentManager.Instance.GetBase64FileFromPath(t.FlagPath),
                IsDefault = false
            }).ToList();
            return response;
        }

        public CountryListResponse List(IntegrationAppRequestBase criteria)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new CountryListResponse();
            response.DataList = _countries.Values.Select(t => new CountryViewData
            {
                Oid = t.Oid,
                CreatedTime = t.CreatedTime,
                LastUpdateTime = t.LastUpdateTime,
                IsoCode2 = t.IsoCode2,
                IsoCode3 = t.IsoCode3,
                Name= TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, criteria.Language),
                PhoneCode = t.PhoneCode
            }).ToList();
            return response;
        }

        public LookupResponse Lookup(IntegrationAppRequestBase criteria)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new LookupResponse();
            response.DataList = _countries.Values.ToList()
                                                .Select(t => new LookupViewData
                                                {
                                                    Key = t.Oid,
                                                    Value = TranslateServiceManager.Instance.GetNameFromCacheData(t.NameTranslateModel, criteria.Language),
                                                    IsDefault = false
                                                }).ToList();
            return response;
        }
    }
}
