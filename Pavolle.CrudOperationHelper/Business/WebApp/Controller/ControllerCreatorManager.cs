using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.WebApp.Controller
{
    public class ControllerCreatorManager
    {
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectNameRoot { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string Path { get; set; }
        public string ClassString { get; set; }

        public ControllerCreatorManager(string companyName, string projectName, string projectPath, string properties, string className)
        {
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ClassName = className;

            ProjectNameRoot = CompanyName + "." + ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".WebApp.Controllers" + Environment.NewLine;
            Path = ProjectNameRoot + ".WebApp/Controllers";

            ClassString = "";
            ClassString += "using log4net;" + Environment.NewLine;
            ClassString += "using Microsoft.AspNetCore.Mvc;" + Environment.NewLine;
            ClassString += "using System.Text.Json;" + Environment.NewLine;
            ClassString += "using " + CompanyName + ".Core.Enums;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".Business.Manager;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".Common.Utils;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".ViewModels.Criteria;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".ViewModels.Request;" + Environment.NewLine;
            ClassString += "using " + ProjectNameRoot + ".ViewModels.Response;" + Environment.NewLine;
            ClassString += "" + Environment.NewLine;
            ClassString += Namespace;
            ClassString += "    [Produces(\"application/json\")]" + Environment.NewLine;
            ClassString += "    [Route(" + projectName + "ApiUrlConsts." + ClassName + "RouteConsts.Route)]" + Environment.NewLine;
            ClassString += "{" + Environment.NewLine;
            ClassString += "    public class " + ClassName + "Controller : Controller" + Environment.NewLine;
            ClassString += "    {" + Environment.NewLine;
            ClassString += "        static readonly ILog _log = LogManager.GetLogger(typeof(" + ClassName + "Controller));" + Environment.NewLine;
            ClassString += properties;
            ClassString += "    }" + Environment.NewLine;
            ClassString += "}" + Environment.NewLine;
        }

        public string GenerateGenericService(bool list, bool lookup, bool detail, bool add, bool edit, bool delete)
        {
            string result = "";

            if (list)
            {
                result += "" + Environment.NewLine;
                result += "        [HttpGet(" + ProjectName + "ApiUrlConsts.ListRoutePrefix)]" + Environment.NewLine;
                result += "        public ActionResult List([FromQuery] List" + ClassName + "Criteria criteria)" + Environment.NewLine;
                result += "        {" + Environment.NewLine;
                result += "            try" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                var response = " + ClassName + "Manager.Instance.List(criteria);" + Environment.NewLine;
                result += "                _log.Debug(\"Request IP: \" + criteria.RequestIp + \" Criteria: \" + JsonSerializer.Serialize(criteria) + \" Response: \" + JsonSerializer.Serialize(response));" + Environment.NewLine;
                result += "                return Ok(response);" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "            catch (Exception ex)" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                _log.Error(\"Unexpected exception occured! Ex: \" + ex);" + Environment.NewLine;
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.Ingilizce) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            if (lookup)
            {
                result += "" + Environment.NewLine;
                result += "        [HttpGet(" + ProjectName + "ApiUrlConsts.LookupRoutePrefix)]" + Environment.NewLine;
                result += "        public ActionResult Lookup([FromQuery] Lookup" + ClassName + "Criteria criteria)" + Environment.NewLine;
                result += "        {" + Environment.NewLine;
                result += "            try" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                var response = " + ClassName + "Manager.Instance.Lookup(criteria);" + Environment.NewLine;
                result += "                _log.Debug(\"Request IP: \" + criteria.RequestIp + \" Criteria: \" + JsonSerializer.Serialize(criteria) + \" Response: \" + JsonSerializer.Serialize(response));" + Environment.NewLine;
                result += "                return Ok(response);" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "            catch (Exception ex)" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                _log.Error(\"Unexpected exception occured! Ex: \" + ex);" + Environment.NewLine;
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.Ingilizce) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            if (detail)
            {
                result += "" + Environment.NewLine;
                result += "        [HttpGet(" + ProjectName + "ApiUrlConsts.DetailRoutePrefix)]" + Environment.NewLine;
                result += "        public ActionResult Detail(long? oid, " + ProjectName + "RequestBase request)" + Environment.NewLine;
                result += "        {" + Environment.NewLine;
                result += "            try" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                var response = "+ClassName+"Manager.Instance.Detail(oid, request);" + Environment.NewLine;
                result += "                _log.Debug(\"Request IP: \" + request.RequestIp + \" Request: \" + JsonSerializer.Serialize(request) + \" Response: \" + JsonSerializer.Serialize(response));" + Environment.NewLine;
                result += "                return Ok(response);" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "            catch (Exception ex)" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                _log.Error(\"Unexpected exception occured! Ex: \" + ex);" + Environment.NewLine;
                result += "                return Ok(new "+ProjectName+"ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.Ingilizce) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            if (add)
            {
                result += "" + Environment.NewLine;
                result += "        [HttpPost(" + ProjectName + "ApiUrlConsts.AddRoutePrefix)]" + Environment.NewLine;
                result += "        public ActionResult Add([FromBody] Add" + ClassName + "Request request)" + Environment.NewLine;
                result += "        {" + Environment.NewLine;
                result += "            try" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                var response = " + ClassName + "Manager.Instance.Add(request);" + Environment.NewLine;
                result += "                _log.Debug(\"Request IP: \" + request.RequestIp + \" Request: \" + JsonSerializer.Serialize(request) + \" Response: \" + JsonSerializer.Serialize(response));" + Environment.NewLine;
                result += "                return Ok(response);" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "            catch (Exception ex)" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                _log.Error(\"Unexpected exception occured! Ex: \" + ex);" + Environment.NewLine;
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.Ingilizce) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            if (edit)
            {
                result += "" + Environment.NewLine;
                result += "        [HttpPost(" + ProjectName + "ApiUrlConsts.EditRoutePrefix)]" + Environment.NewLine;
                result += "        public ActionResult Add([FromBody] Edit" + ClassName + "Request request)" + Environment.NewLine;
                result += "        {" + Environment.NewLine;
                result += "            try" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                var response = " + ClassName + "Manager.Instance.Edit(request);" + Environment.NewLine;
                result += "                _log.Debug(\"Request IP: \" + request.RequestIp + \" Request: \" + JsonSerializer.Serialize(request) + \" Response: \" + JsonSerializer.Serialize(response));" + Environment.NewLine;
                result += "                return Ok(response);" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "            catch (Exception ex)" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                _log.Error(\"Unexpected exception occured! Ex: \" + ex);" + Environment.NewLine;
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.Ingilizce) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            if (delete)
            {
                result += "" + Environment.NewLine;
                result += "        [HttpGet(" + ProjectName + "ApiUrlConsts.DeleteRoutePrefix)]" + Environment.NewLine;
                result += "        public ActionResult List([FromQuery] Delete" + ClassName + "Criteria criteria)" + Environment.NewLine;
                result += "        {" + Environment.NewLine;
                result += "            try" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                var response = " + ClassName + "Manager.Instance.Delete(criteria);" + Environment.NewLine;
                result += "                _log.Debug(\"Request IP: \" + criteria.RequestIp + \" Criteria: \" + JsonSerializer.Serialize(criteria) + \" Response: \" + JsonSerializer.Serialize(response));" + Environment.NewLine;
                result += "                return Ok(response);" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "            catch (Exception ex)" + Environment.NewLine;
                result += "            {" + Environment.NewLine;
                result += "                _log.Error(\"Unexpected exception occured! Ex: \" + ex);" + Environment.NewLine;
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.Ingilizce) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            return result;
        }
    }
}
