using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.ViewModels.Request;
using Pavolle.BES.WebSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.WebFilter
{
    public class IntegrationAppFillRequestBaseActionFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var principal = Thread.CurrentPrincipal as BesIntegrationPrincipal;
            var keyList = context.ActionArguments.Keys.ToList();

            foreach (string keyy in keyList)
            {
                if (context.ActionArguments[keyy] != null &&
                    (context.ActionArguments[keyy].GetType().IsSubclassOf(typeof(IntegrationAppRequestBase)) ||
                     context.ActionArguments[keyy].GetType() == typeof(IntegrationAppRequestBase)))
                {
                    var requestBase = context.ActionArguments[keyy] as IntegrationAppRequestBase;

                    if (principal != null && requestBase != null)
                    {
                        requestBase = SetRequestBaseParameter(requestBase, principal);
                    }
                }
                else if (context.ActionArguments[keyy] == null && new List<string> { "criteria", "request" }.Contains(keyy))
                {
                    var requestBase = new IntegrationAppRequestBase();

                    requestBase = SetRequestBaseParameter(requestBase, principal);

                    context.ActionArguments[keyy] = requestBase;
                }
            }
        }

        private IntegrationAppRequestBase SetRequestBaseParameter(IntegrationAppRequestBase requestBase, BesIntegrationPrincipal principal)
        {
            requestBase.RequestIp = principal.Ip;
            requestBase.AppCode=principal.AppCode;
            requestBase.LogBase = requestBase.AppCode + " Request IP: " + requestBase.RequestIp + " => ";
            requestBase.AppId = principal.AppId;
            return requestBase;
        }
    }
}
