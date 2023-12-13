using DevExpress.Xpo;
using Pavolle.BES.AuthServer.DbModels;
using Pavolle.BES.AuthServer.DbModels.Entities;
using Pavolle.BES.AuthServer.ViewModels.Criteria;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.BES.AuthServer.ViewModels.ViewData;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class ApiServiceManager : Singleton<ApiServiceManager>
    {
        private ApiServiceManager() { }

        public ApiServiceListResponse List(ApiServiceCriteria request)
        {
            var response= new ApiServiceListResponse();
            using(Session session = AuthServerXpoManager.Instance.GetNewSession())
            {
                IQueryable<ApiService> query = session.Query<ApiService>();
                if (request.AppType != null)
                {
                    query = query.Where(t => t.BesAppType == request.AppType);
                }

                response.DataList=query.Select(t=> new ApiServiceViewData
                {
                    Oid=t.Oid,
                    CreatedTime=t.CreatedTime,
                    LastUpdateTime=t.LastUpdateTime,
                    Key=t.ApiKey,
                    Definition = t.ApiDefinition,
                    Anonymous=t.Anonymous,
                    EditableForAdmin=t.EditableForAdmin,
                    EditableForOrganization = t.EditableForOrganization,
                    MethodType=t.MethodType.ToString(),
                }).ToList();
            }
            return response;
        }

        public ApiServiceDetailResponse Detail(long? oid, IntegrationAppRequestBase request)
        {
            var response = new ApiServiceDetailResponse();
            using (Session session = AuthServerXpoManager.Instance.GetNewSession())
            {
                //Api service detayını sorgula.
                //Değişiklik tarihini yaz
                //Role verilerini sorgula. Bu role verilerinden hangisi için yetki verildiği bilgisini oluştur.


            }
            return response;
        }

        public ResponseBase Edit(long? oid, EditApiServiceRequest request)
        {
            var response = new ResponseBase();
            using (Session session = AuthServerXpoManager.Instance.GetNewSession())
            {

            }
            return response;
        }
    }
}
