using DevExpress.Xpo;
using log4net;
using Pavolle.BES.Common.Enums;
using Pavolle.BES.GeoServer.DbModels.Entities;
using Pavolle.BES.GeoServer.DbModels;
using Pavolle.BES.GeoServer.ViewModels.Criteria;
using Pavolle.BES.GeoServer.ViewModels.Model;
using Pavolle.BES.GeoServer.ViewModels.Request;
using Pavolle.BES.GeoServer.ViewModels.Response;
using Pavolle.BES.TranslateServer.ClientLib;
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
using Pavolle.BES.TranslateServer.Common.Enums;

namespace Pavolle.BES.GeoServer.Business.Manager
{
    public class AddressManager : Singleton<AddressManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(AddressManager));
        ConcurrentDictionary<long?, AddressCacheModel> _cacheData;
        bool _isCacheInitiliaze = false;
        private AddressManager()
        {
            _log.Debug("Initilize " + nameof(AddressManager));
        }

        public void Initilaize()
        {
            _cacheData = new ConcurrentDictionary<long?, AddressCacheModel>();
            using (Session session = GeoServerXpoManager.Instance.GetNewSession())
            {
                var dataList = session.Query<Address>().ToList();

                foreach (var data in dataList)
                {
                    var cacheData = new AddressCacheModel
                    {
                        Oid = data.Oid,
                        CreatedTime = data.CreatedTime,
                        DeletedTime = data.DeletedTime,
                        LastUpdateTime = data.LastUpdateTime,
                        DistrictOid=data.District.Oid,
                        CityOid = data.City.Oid,
                        CountryOid = data.Country.Oid,
                        Latitude=data.Latitude,
                        Longitude=data.Longitude,
                        OpenAddress=data.OpenAddress,
                        StreetName=data.StreetName,
                        ZipCode = data.ZipCode
                    };

                    _cacheData.TryAdd(cacheData.Oid, cacheData);
                }
                _isCacheInitiliaze = true;
            }
        }

        //TODO Burada oid bilgisini geri dönmemiz gerekebilir. Çünkü bu oid bilgisi bir yerlere yazılacak.
        public BesAddRecordResponseBase AddAddress(AddAddressRequest request)
        {
            if (!_isCacheInitiliaze) { Initilaize(); }
            var response = new BesAddRecordResponseBase();
            try
            {
                using (Session session = GeoServerXpoManager.Instance.GetNewSession())
                {
                    var address = new Address(session)
                    {
                        Longitude = request.Longitude,
                        Latitude = request.Latitude,
                        StreetName = request.StreetName,
                        OpenAddress = request.OpenAddress,
                        ZipCode = request.ZipCode
                    };
                    address.Save();
                    
                    if(request.CountryOid != null)
                    {
                        var country = session.Query<Country>().FirstOrDefault(t => t.Oid == request.CountryOid);
                        if (country != null)
                        {
                            address.Country = country;
                            address.Save();
                        }
                    }
                    if (request.CityOid != null)
                    {
                        var city = session.Query<City>().FirstOrDefault(t => t.Oid == request.CityOid);
                        if (city != null)
                        {
                            address.City = city;
                            address.Save();
                        }
                    }
                    if (request.DistrictOid != null)
                    {
                        var district = session.Query<District>().FirstOrDefault(t => t.Oid == request.DistrictOid);
                        if (district != null)
                        {
                            address.District = district;
                            address.Save();
                        }
                    }

                    response.RecordOid = address.Oid;

                    _log.Info("Address saved to DB.");
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
            throw new NotImplementedException();
        }

        public AddressDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Edit(long? oid, EditAddressRequest request)
        {
            throw new NotImplementedException();
        }

        public AddressListResponse List(AddressCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public LookupResponse Lookup(AddressCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
