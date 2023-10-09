using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class CountryViewDataCreatorManager : Singleton<CountryViewDataCreatorManager>
    {
        private CountryViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ISOCode2 { get; set; }" + Environment.NewLine;
            properties += "        public string ISOCode3 { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneCode { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "CountryViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
