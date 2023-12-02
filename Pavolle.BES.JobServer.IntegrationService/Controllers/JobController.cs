using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.JobServer.Business.Manager;
using Pavolle.BES.JobServer.Common.Utils;
using Pavolle.BES.JobServer.ViewModels.Criteria;
using Pavolle.BES.JobServer.ViewModels.Request;
using Pavolle.BES.JobServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.Enums;
using Pavolle.Core.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.JobServer.IntegrationService.Controllers
{
    [Produces("application/json")]
    [Route(JobServerUrlConsts.JobServiceConsts.BaseRoute)]
    public class JobController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(JobController));

        [HttpGet(JobServerUrlConsts.JobServiceConsts.ListRoutePrefix)]
        public ActionResult List([FromQuery] ListJobCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest(new JobServerStatusResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (criteria.Language == null)
            {
                criteria.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = JobManager.Instance.List(criteria);
                _log.Debug("Request IP: " + criteria.RequestIp + " Criteria: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new JobListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpGet(JobServerUrlConsts.JobServiceConsts.DetailRoutePrefix)]
        public ActionResult Detail(long? oid, IntegrationAppRequestBase request)
        {
            if (request == null)
            {
                return BadRequest(new JobServerStatusResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = JobManager.Instance.Detail(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new JobDetailResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(JobServerUrlConsts.JobServiceConsts.EditRoutePrefix)]
        public ActionResult Edit(long? oid, [FromBody] EditJobRequest request)
        {
            if (request == null)
            {
                return BadRequest(new JobServerStatusResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = JobManager.Instance.Edit(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(JobServerUrlConsts.JobServiceConsts.AddRoutePrefix)]
        public ActionResult Add([FromBody] AddJobRequest request)
        {
            if (request == null)
            {
                return BadRequest(new JobServerStatusResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = JobManager.Instance.Add(request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }

        [HttpPost(JobServerUrlConsts.JobServiceConsts.RunRoutePrefix)]
        public ActionResult Run(long? oid, [FromBody] RunJobRequest request)
        {
            if (request == null)
            {
                return BadRequest(new JobServerStatusResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.RequestDataTypeError, SettingServiceManager.Instance.GetDefaultLanguage()),
                    StatusCode = 400
                });
            }
            if (request.Language == null)
            {
                request.Language = SettingServiceManager.Instance.GetDefaultLanguage();
            }
            try
            {
                var response = JobManager.Instance.Run(oid, request);
                _log.Debug("Request IP: " + request.RequestIp + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new ResponseBase
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, request.Language.Value),
                    StatusCode = 500
                });
            }
        }
    }
}
