using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.WebSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.WebFilter
{
    public class IntegrationAppAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(IntegrationAppAuthorizeAttribute));
        //TODO Exception Ayarlanacak
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var appCode = context.HttpContext.Request.Headers["AppCode"];
            var appId = context.HttpContext.Request.Headers["AppId"];
            Thread.CurrentPrincipal = new SystemIntegrationPrincipal(new BesIdentity(null, null), ip, appCode, appId);
        }
    }
}
