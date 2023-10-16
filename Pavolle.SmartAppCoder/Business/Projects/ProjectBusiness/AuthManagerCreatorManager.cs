using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ProjectBusiness
{
    public class AuthManagerCreatorManager : Singleton<AuthManagerCreatorManager>
    {
        private AuthManagerCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath, string language)
        {
            if (language == null) language = "en, tr";
            string[] _languages = language.Split(',');
            string projectNameRoot = organizationName + "." + projectName;
            string classString = "";
            classString += "using DevExpress.Xpo;" + Environment.NewLine;
            classString += "using log4net;" + Environment.NewLine;
            classString += "using " + organizationName + ".Core.Enums;" + Environment.NewLine;
            classString += "using " + organizationName + ".Core.Utils;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".Common.Enums;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels.Entities;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels.Manager;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Criteria;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Model;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Request;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Response;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.ViewData;" + Environment.NewLine;
            classString += "using System.Linq;" + Environment.NewLine;
            classString += "using System;" + Environment.NewLine;
            classString += "using System.Collections.Concurrent;" + Environment.NewLine;
            classString += "using System.Collections.Generic;" + Environment.NewLine;
            classString += "using System.Text;" + Environment.NewLine;
            classString += "using System.Threading.Tasks;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".Business.Manager" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class AuthManager : Singleton<AuthManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        static readonly ILog _log = LogManager.GetLogger(typeof(AuthManager));" + Environment.NewLine;
            classString += "        ConcurrentDictionary<string, AuhtorizationCacheModel> _cacheData;" + Environment.NewLine;
            classString += "        private AuthManager()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            _log.Debug(\"Initialize \" + nameof(AuthManager));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public void Initialize()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            LoadCacheData();" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private void LoadCacheData()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                using (Session session = XpoManager.Instance.GetNewSession())" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    var services = session.Query<Auth>().Select(t => new AuhtorizationCacheModel" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        Oid = t.Oid," + Environment.NewLine;
            classString += "                        ApiKey = t.ApiService.ApiKey," + Environment.NewLine;
            classString += "                        ApiServiceOid = t.ApiService.Oid," + Environment.NewLine;
            classString += "                        IsAuthority = t.IsAuhtority," + Environment.NewLine;
            classString += "                        UserGroupOid = t.UserGroup.Oid," + Environment.NewLine;
            classString += "                        UserGroupName = t.UserGroup.Name," + Environment.NewLine;
            classString += "                        MethodType = t.ApiService.MethodType," + Environment.NewLine;
            classString += "                        Anonymous = t.ApiService.Anonymous" + Environment.NewLine;
            classString += "                    }).ToList();" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "                    _cacheData = new ConcurrentDictionary<string, AuhtorizationCacheModel>();" + Environment.NewLine;
            classString += "                    foreach (var item in services)" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        _cacheData.TryAdd(item.ApiKey.Replace(\"/{oid}\",\"\"), item);" + Environment.NewLine;
            classString += "                    }" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch(Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Unexpected error occured! Error: \" + ex);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        internal List<UserAuthViewData> GetAuthList(long userGroupOid)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return _cacheData.ToList().Where(t => t.Value.UserGroupOid == userGroupOid).Select(t => new UserAuthViewData" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                ApiKey = t.Key," + Environment.NewLine;
            classString += "                IsAuthority = t.Value.IsAuthority" + Environment.NewLine;
            classString += "            }).ToList();" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public bool IsAuthority(string apiKey, long userGroupOid)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                var data = _cacheData.FirstOrDefault(t => apiKey.StartsWith(t.Key) && t.Value.UserGroupOid==userGroupOid);" + Environment.NewLine;
            classString += "                if(data.Value.Anonymous) { return true; }" + Environment.NewLine;
            classString += "                return data.Value.IsAuthority;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch(Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Unexpected error occured! Error: \" + ex);" + Environment.NewLine;
            classString += "                return false;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        internal List<ApiServiceAuthViewData> GetAuthListForApi(long apiServiceOid)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return _cacheData.ToList().Where(t => t.Value.UserGroupOid == apiServiceOid).Select(t => new ApiServiceAuthViewData" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                UserGroupOid = t.Value.UserGroupOid," + Environment.NewLine;
            classString += "                UserGroupName = t.Value.UserGroupName," + Environment.NewLine;
            classString += "                IsAuthority = t.Value.IsAuthority" + Environment.NewLine;
            classString += "            }).ToList();" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;


            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".Business/Manager", "AuthManager.cs", classString);
        }
    }
}
