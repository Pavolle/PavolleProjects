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

        public ControllerCreatorManager(string companyName, string projectName, string projectPath, string className)
        {
            CompanyName = companyName;
            ProjectName = projectName;
            ProjectPath = projectPath;
            ClassName = className;

            ProjectNameRoot = CompanyName + "." + ProjectName;
            Namespace = "namespace " + ProjectNameRoot + ".WebApp.Controllers" + Environment.NewLine;
            Path = ProjectNameRoot + ".WebApp/Controllers";
        }

        public string GenerateGenericService(bool list, bool lookup, bool detail, bool add, bool edit, bool delete, string addedProperties)
        {
            string result = "";
            result = "";
            result += "using log4net;" + Environment.NewLine;
            result += "using Microsoft.AspNetCore.Mvc;" + Environment.NewLine;
            result += "using System.Text.Json;" + Environment.NewLine;
            result += "using " + CompanyName + ".Core.Enums;" + Environment.NewLine;
            result += "using " + ProjectNameRoot + ".Business.Manager;" + Environment.NewLine;
            result += "using " + ProjectNameRoot + ".Common.Enums;" + Environment.NewLine;
            result += "using " + ProjectNameRoot + ".Common.Utils;" + Environment.NewLine;
            result += "using " + ProjectNameRoot + ".ViewModels.Criteria;" + Environment.NewLine;
            result += "using " + ProjectNameRoot + ".ViewModels.Request;" + Environment.NewLine;
            result += "using " + ProjectNameRoot + ".ViewModels.Response;" + Environment.NewLine;
            result += "" + Environment.NewLine;
            result += Namespace;
            result += "{" + Environment.NewLine;
            result += "    [Produces(\"application/json\")]" + Environment.NewLine;
            result += "    [Route(" + ProjectName + "ApiUrlConsts." + ClassName + "RouteConsts.Route)]" + Environment.NewLine;
            result += "    public class " + ClassName + "Controller : Controller" + Environment.NewLine;
            result += "    {" + Environment.NewLine;
            result += "        static readonly ILog _log = LogManager.GetLogger(typeof(" + ClassName + "Controller));" + Environment.NewLine;
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
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.English) });" + Environment.NewLine;
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
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.English) });" + Environment.NewLine;
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
                result += "                return Ok(new "+ProjectName+"ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.English) });" + Environment.NewLine;
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
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.English) });" + Environment.NewLine;
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
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.English) });" + Environment.NewLine;
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
                result += "                return Ok(new " + ProjectName + "ResponseBase { ErrorMessage = TranslateManager.Instance.GetMessage(E" + ProjectName + "MessageCode.UnexpectedError, ELanguage.English) });" + Environment.NewLine;
                result += "            }" + Environment.NewLine;
                result += "        }" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(addedProperties))
            {
                result += addedProperties;
            }

            result += "    }" + Environment.NewLine;
            result += "}" + Environment.NewLine;

            return result;
        }
    }
}
