using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.MailServer.Business.Manager;
using Pavolle.BES.MailServer.Common.Utils;
using Pavolle.BES.MailServer.ViewModels.Criteria;
using Pavolle.BES.MailServer.ViewModels.Request;
using Pavolle.BES.MailServer.ViewModels.Response;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;
using System.Text.Json;

namespace Pavolle.BES.MailServer.Service.Controllers
{
    [Produces("application/json")]
    [Route(MailServerUrlConsts.MailServiceConsts.BaseRoute)]
    public class MailController : Controller
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ServerStatusController));


        [HttpPost(MailServerUrlConsts.MailServiceConsts.SendMailRoutePrefix)]
        public ActionResult ReloadAllSettings([FromBody] MailRequest request)
        {
            if (request == null)
            {
                return BadRequest(new ResponseBase
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
                var response = RabbitMQManager.Instance.SaveMail(request);
                _log.Debug(request.LogBase + " Request: " + JsonSerializer.Serialize(request) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(new ResponseBase());
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


        [HttpGet(MailServerUrlConsts.MailServiceConsts.ListMailRoutePrefix)]
        public ActionResult List([FromQuery] MailListCriteria criteria)
        {
            if (criteria == null)
            {
                return BadRequest(new MailListResponse
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
                var response = MailManager.Instance.List(criteria);
                _log.Debug(criteria.LogBase + " Request: " + JsonSerializer.Serialize(criteria) + " Response: " + JsonSerializer.Serialize(response));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _log.Error("Unexpected exception occured! Ex: " + ex);
                return Ok(new MailListResponse
                {
                    ErrorMessage = TranslateServiceManager.Instance.GetMessage(EMessageCode.UnexpectedExceptionOccured, criteria.Language.Value),
                    StatusCode = 500
                });
            }
        }
    }
}
