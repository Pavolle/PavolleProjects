using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.LogServer.WebSecurity;

namespace Pavolle.BES.LogServer.Service.Filter
{
    public sealed class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(CustomAuthorizeAttribute));
        //TODO Exception Ayarlanacak
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            Thread.CurrentPrincipal = new LogServerPrincipal(new LogServerIdentity(null, null), ip);
        }
    }
}
