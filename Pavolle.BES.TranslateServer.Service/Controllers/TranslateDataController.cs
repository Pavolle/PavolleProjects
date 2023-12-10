using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.TranslateServer.Business.Manager;
using Pavolle.BES.TranslateServer.Common.Utils;
using Pavolle.BES.TranslateServer.ViewModels.Request;
using Pavolle.BES.TranslateServer.ViewModels.Response;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.TranslateServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(TranslateServerConsts.TranslateDataUrlConst.BaseRoute)]
    public class TranslateDataController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(TranslateDataController));

        [HttpGet(TranslateServerConsts.TranslateDataUrlConst.GetAllDataRoutePrefix)]
        public ActionResult GetAllData(IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new TranslateDataListResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateDataManager.Instance.GetAllData(request);

                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new TranslateDataListResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }


        [HttpGet(TranslateServerConsts.TranslateDataUrlConst.GetRoutePrefix)]
        public ActionResult GetData(string variable, IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new TranslateDataResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateDataManager.Instance.GetData(variable, request);

                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new TranslateDataResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }


        [HttpGet(TranslateServerConsts.TranslateDataUrlConst.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new TranslateDataResponse { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateDataManager.Instance.Detail(oid, request);

                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new TranslateDataDetailResponse { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }
        

        [HttpPost(TranslateServerConsts.TranslateDataUrlConst.AddRoutePrefix)]
        public ActionResult AddTranslateData([FromBody]AddTranslateDataRequest request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateDataManager.Instance.AddTranslateData(request);

                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }



        [HttpPost(TranslateServerConsts.TranslateDataUrlConst.EditRoutePrefix)]
        public ActionResult EditTranslateData(long? oid, [FromBody] EditTranslateDataRequest request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase { ErrorMessage = "Request format error!", StatusCode = 400 });
            }
            try
            {
                var response = TranslateDataManager.Instance.EditTranslateData(oid, request);

                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase { ErrorMessage = "Unexpected error occured!", StatusCode = 500 });
            }
        }
    }
}
