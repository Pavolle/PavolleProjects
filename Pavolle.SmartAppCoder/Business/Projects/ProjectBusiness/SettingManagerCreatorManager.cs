using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ProjectBusiness
{
    public class SettingManagerCreatorManager : Singleton<SettingManagerCreatorManager>
    {
        private SettingManagerCreatorManager() { }

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
            classString += "    public class SettingManager : Singleton<SettingManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        static readonly ILog _log = LogManager.GetLogger(typeof(SettingManager));" + Environment.NewLine;
            classString += "        private ConcurrentDictionary<ESettingType, SettingCacheModel> _settings;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private SettingManager()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            _log.Debug(\"Initialize \"+nameof(SettingManager));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public void Intialize()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            _settings = new ConcurrentDictionary<ESettingType, SettingCacheModel>();" + Environment.NewLine;
            classString += "            using (Session session = XpoManager.Instance.GetNewSession())" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                var settingList = session.Query<Setting>().Select(t => new SettingCacheModel" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    Oid = t.Oid," + Environment.NewLine;
            classString += "                    SettingType = t.SettingType," + Environment.NewLine;
            classString += "                    Value = t.Value" + Environment.NewLine;
            classString += "                });" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private void UpdateSetting(SettingCacheModel item)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (_settings.ContainsKey(item.SettingType))" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    _settings[item.SettingType] = item;" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "                else" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    _settings.TryAdd(item.SettingType, item);" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Unexpected error occured! Error: \" + ex);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public ELanguage GetDefaultLanguage()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (_settings.ContainsKey(ESettingType.DefaultLanguage))" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    return (ELanguage)Convert.ToInt32(_settings[ESettingType.DefaultLanguage].Value);" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "                return ELanguage.English;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Fetch Deufault Setting error: \" + ex);" + Environment.NewLine;
            classString += "                return ELanguage.English;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public ESecurityLevel GetSecurityLevel()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (_settings.ContainsKey(ESettingType.SecurityLevel))" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    return (ESecurityLevel)Convert.ToInt32(_settings[ESettingType.SecurityLevel].Value);" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "                return ESecurityLevel.Master;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Fetch Security Level setting error: \" + ex);" + Environment.NewLine;
            classString += "                return ESecurityLevel.Master;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetSetting(ESettingType settingType)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (_settings.ContainsKey(settingType))" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    return _settings[settingType].Value;" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Fetch setting error: \" + ex);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return \"\";" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        List<SettingCacheModel> GetSettings()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            if (_settings != null) return _settings.Select(t => t.Value).ToList();" + Environment.NewLine;
            classString += "            return new List<SettingCacheModel>();" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;


            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".Business/Manager", "SettingManager.cs", classString);
        }
    }
}
