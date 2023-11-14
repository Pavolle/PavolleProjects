using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.SettingServer.ViewModels.Request;
using Pavolle.BES.SettingServer.WebSecurity;
using Pavolle.Core.ViewModels.Request;

namespace Pavolle.BES.SettingServer.Service.Filter
{
    public class FillRequestBaseActionFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var principal = Thread.CurrentPrincipal as SettingsServerPrincipal;
            var keyList = context.ActionArguments.Keys.ToList();

            foreach (string keyy in keyList)
            {
                if (context.ActionArguments[keyy] != null &&
                    (context.ActionArguments[keyy].GetType().IsSubclassOf(typeof(SettingsServerRequestBase)) ||
                     context.ActionArguments[keyy].GetType() == typeof(SettingsServerRequestBase)))
                {
                    var requestBase = context.ActionArguments[keyy] as SettingsServerRequestBase;

                    if (principal != null && requestBase != null)
                    {
                        requestBase = SetRequestBaseParameter(requestBase, principal);
                    }
                }
                else if (context.ActionArguments[keyy] == null && new List<string> { "criteria", "request" }.Contains(keyy))
                {
                    var requestBase = new SettingsServerRequestBase();

                    requestBase = SetRequestBaseParameter(requestBase, principal);

                    context.ActionArguments[keyy] = requestBase;
                }
            }
        }

        private SettingsServerRequestBase SetRequestBaseParameter(SettingsServerRequestBase requestBase, SettingsServerPrincipal principal)
        {
            requestBase.RequestIp = principal.Ip;
            return requestBase;
        }
    }
}
