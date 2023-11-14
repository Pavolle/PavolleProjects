using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.SettingServer.WebSecurity;

namespace Pavolle.BES.SettingServer.Service.Filter
{
    public sealed class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(CustomAuthorizeAttribute));
        //TODO Exception Ayarlanacak
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            Thread.CurrentPrincipal = new SettingsServerPrincipal(new SettingsServerIdentity(null, null), ip);
        }
    }
}
