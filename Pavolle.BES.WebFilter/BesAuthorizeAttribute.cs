using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.WebSecurity;

namespace Pavolle.BES.WebFilter
{
    public class BesAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(BesAuthorizeAttribute));
        //TODO Exception Ayarlanacak
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var appCode = context.HttpContext.Request.Headers["AppCode"];
            //Thread.CurrentPrincipal = new BesIntegrationPrincipal(new BesIdentity(null, null), ip, appCode);
        }
    }
}
