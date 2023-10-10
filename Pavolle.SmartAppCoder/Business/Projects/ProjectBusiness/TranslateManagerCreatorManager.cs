using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ProjectBusiness
{
    public class TranslateManagerCreatorManager : Singleton<TranslateManagerCreatorManager>
    {
        private TranslateManagerCreatorManager() { }

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
            classString += "namespace "+projectNameRoot+".Business.Manager" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class TranslateManager : Singleton<TranslateManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        static readonly ILog _log = LogManager.GetLogger(typeof(TranslateManager));" + Environment.NewLine;
            classString += "        private ConcurrentDictionary<string, TranslateDataCacheModel> _translateData;" + Environment.NewLine;
            classString += "        private TranslateManager()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            _log.Debug(\"Initialize \" + nameof(TranslateManager));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public void Initialize()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            LoadTranslateData();" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private void LoadTranslateData()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                using (Session session = XpoManager.Instance.GetNewSession())" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    var datas = session.Query<TranslateData>().Select(t => new TranslateDataCacheModel" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        Oid = t.Oid," + Environment.NewLine;
            classString += "                        Variable = t.Variable," + Environment.NewLine;
            foreach (var item in _languages)
            {
                classString += "                        "+ item.Replace(" ", "").ToUpper() + " = t."+ item.Replace(" ", "").ToUpper() + "," + Environment.NewLine;
            }
            classString += "                    }).ToList();" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "                    _translateData = new ConcurrentDictionary<string, TranslateDataCacheModel>();" + Environment.NewLine;
            classString += "                    foreach (var item in datas)" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        _translateData.TryAdd(item.Variable, item);" + Environment.NewLine;
            classString += "                    }" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Unexpected error occured! Error: \" + ex);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private void AddTranslateData(TranslateDataCacheModel item)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _translateData.TryAdd(item.Variable, item);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Unexpected error occured! Error: \" + ex);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private void UpdateTranslateData(TranslateDataCacheModel item)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (_translateData.ContainsKey(item.Variable))" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    _translateData[item.Variable] = item;" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "                else" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    _translateData.TryAdd(item.Variable, item);" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Unexpected error occured! Error: \" + ex);" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetMessage(EMessageCode messageCode, ELanguage language)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return GetMessage(messageCode.ToString(), language);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetMessage(string messageCode, ELanguage language)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            string message = messageCode;" + Environment.NewLine;
            classString += "            TranslateDataCacheModel data;" + Environment.NewLine;
            classString += "            if (_translateData.ContainsKey(messageCode.ToString()))" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                data = _translateData[messageCode.ToString()];" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            else" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                return message;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "            switch (language)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            foreach(var item in _languages)
            {
                string name = item.Replace(" ", "");
                if(name == "en")
                {
                    classString += "                case ELanguage.English:" + Environment.NewLine;
                    classString += "                    message = data.EN;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
                else if (name == "de")
                {
                    classString += "                case ELanguage.German:" + Environment.NewLine;
                    classString += "                    message = data.DE;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
                else if (name == "es")
                {
                    classString += "                case ELanguage.Spanish:" + Environment.NewLine;
                    classString += "                    message = data.ES;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
                else if (name == "fr")
                {
                    classString += "                case ELanguage.French:" + Environment.NewLine;
                    classString += "                    message = data.FR;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
                else if (name == "ru")
                {
                    classString += "                case ELanguage.Russian:" + Environment.NewLine;
                    classString += "                    message = data.RU;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
                else if (name == "tr")
                {
                    classString += "                case ELanguage.Turkish:" + Environment.NewLine;
                    classString += "                    message = data.TR;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
                else if (name == "az")
                {
                    classString += "                case ELanguage.Azerbaijani:" + Environment.NewLine;
                    classString += "                    message = data.AZ;" + Environment.NewLine;
                    classString += "                    break;" + Environment.NewLine;
                }
            }
            classString += "                default:" + Environment.NewLine;
            classString += "                    message = data.EN;" + Environment.NewLine;
            classString += "                    break;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            return message;" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string GetXNotFoundMessage(ELanguage language, EMessageCode messageCode)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return string.Format(GetMessage(EMessageCode.XNotFound, language), messageCode);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string? GetXSavedMessage(ELanguage language, EMessageCode messageCode)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return string.Format(GetMessage(EMessageCode.XSaved, language), messageCode);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public string? GetXCannotBeDeletedessage(ELanguage language, EMessageCode messageCode)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return string.Format(GetMessage(EMessageCode.XCannotBeDeleted, language), messageCode);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        internal string? GetXDeletedMessage(ELanguage language, EMessageCode messageCode)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            return string.Format(GetMessage(EMessageCode.XDeleted, language), messageCode);" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;


            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".Business/Manager", "TranslateManager.cs", classString);
        }
    }
}
