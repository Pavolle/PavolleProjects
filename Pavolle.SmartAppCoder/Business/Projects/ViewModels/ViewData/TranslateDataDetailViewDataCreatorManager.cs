using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class TranslateDataDetailViewDataCreatorManager : Singleton<TranslateDataDetailViewDataCreatorManager>
    {
        private TranslateDataDetailViewDataCreatorManager()
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
                properties += "        public string " + item.Replace(" ", "").ToUpper() + " { get; set; }" + Environment.NewLine;
            }
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "TranslateDataDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
