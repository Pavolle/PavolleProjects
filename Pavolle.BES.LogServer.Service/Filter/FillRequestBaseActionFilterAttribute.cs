using Microsoft.AspNetCore.Mvc.Filters;
using Pavolle.BES.LogServer.ViewModels.Request;
using Pavolle.BES.LogServer.WebSecurity;

namespace Pavolle.BES.LogServer.Service.Filter
{
    public class FillRequestBaseActionFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var principal = Thread.CurrentPrincipal as LogServerPrincipal;
            var keyList = context.ActionArguments.Keys.ToList();

            foreach (string keyy in keyList)
            {
                if (context.ActionArguments[keyy] != null &&
                    (context.ActionArguments[keyy].GetType().IsSubclassOf(typeof(LogServerRequestBase)) ||
                     context.ActionArguments[keyy].GetType() == typeof(LogServerRequestBase)))
                {
                    var requestBase = context.ActionArguments[keyy] as LogServerRequestBase;

                    if (principal != null && requestBase != null)
                    {
                        requestBase = SetRequestBaseParameter(requestBase, principal);
                    }
                }
                else if (context.ActionArguments[keyy] == null && new List<string> { "criteria", "request" }.Contains(keyy))
                {
                    var requestBase = new LogServerRequestBase();

                    requestBase = SetRequestBaseParameter(requestBase, principal);

                    context.ActionArguments[keyy] = requestBase;
                }
            }
        }

        private LogServerRequestBase SetRequestBaseParameter(LogServerRequestBase requestBase, LogServerPrincipal principal)
        {
            requestBase.RequestIp = principal.Ip;
            return requestBase;
        }
    }
}
