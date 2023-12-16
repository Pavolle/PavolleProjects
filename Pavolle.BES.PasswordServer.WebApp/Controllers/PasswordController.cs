using log4net;
using Microsoft.AspNetCore.Mvc;
using Pavolle.BES.AuthServer.ClientLib;
using Pavolle.BES.AuthServer.ViewModels.Request;
using Pavolle.BES.PasswordServer.Common.Utils;
using Pavolle.BES.SettingServer.ClientLib;
using Pavolle.BES.TranslateServer.ClientLib;
using Pavolle.BES.TranslateServer.Common.Enums;
using Pavolle.BES.ViewModels.Request;
using Pavolle.Core.ViewModels.Response;

namespace Pavolle.BES.PasswordServer.WebApp.Controllers
{
    [Produces("application/json")]
    [Route(PasswordServerUrlConsts.PasswordConsts.BaseRoute)]
    public class PasswordController : Controller
    {
       
    }
}
