using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.Business.Manager;
using Pavolle.BES.AuthServer.Common.Utils;
using Pavolle.BES.AuthServer.ViewModels.Criteria;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.AuthServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.AuthServer.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(AuthServerApiUrlConsts.ApiServiceUrlConsts.BaseRoute)]
    public class ApiServiceController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ApiServiceController));

        [HttpGet(AuthServerApiUrlConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery]ApiServiceCriteria request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new ApiServiceListResponse
                    {
                        ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                        StatusCode = 400
                    });
                }
                var response = ApiServiceManager.Instance.List(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ApiServiceListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(AuthServerApiUrlConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid,  IntegrationAppRequestBase request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new ApiServiceDetailResponse
                    {
                        ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                        StatusCode = 400
                    });
                }
                if (oid == null)
                {
                    return BadRequest(new ApiServiceDetailResponse
                    {
                        ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, SettingServiceManager.Instance.GetSystemLanguage()),
                        StatusCode = 400
                    });
                }
                var response = ApiServiceManager.Instance.Detail(oid, request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ApiServiceDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(AuthServerApiUrlConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, EditApiServiceRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new ResponseBase
                    {
                        ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                        StatusCode = 400
                    });
                }
                if (oid == null)
                {
                    return BadRequest(new ResponseBase
                    {
                        ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RecordNotFoundException, SettingServiceManager.Instance.GetSystemLanguage()),
                        StatusCode = 400
                    });
                }
                var response = ApiServiceManager.Instance.Edit(oid, request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetSystemLanguage()),
                    StatusCode = 500
                });
            }
        }
    }
}
