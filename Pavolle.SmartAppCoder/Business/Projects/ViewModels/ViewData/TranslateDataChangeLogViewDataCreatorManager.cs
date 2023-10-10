using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class TranslateDataChangeLogViewDataCreatorManager : Singleton<TranslateDataChangeLogViewDataCreatorManager>
    {
        private TranslateDataChangeLogViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath, string language)
        {
            if (language == null) language = "en, tr";
            string[] _languages = language.Split(',');
            string properties = "";
            properties += "        public string Variable { get; set; }" + Environment.NewLine;
            foreach (var item in _languages)
            {
                properties += "        public string Old" + item.Replace(" ", "").ToUpper() + " { get; set; }" + Environment.NewLine;
                properties += "        public string New" + item.Replace(" ", "").ToUpper() + " { get; set; }" + Environment.NewLine;
            }
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "TranslateDataChangeLogViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
