using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class OrganizationDetailViewDataCreatorManager : Singleton<OrganizationDetailViewDataCreatorManager>
    {
        private OrganizationDetailViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Code { get; set; }" + Environment.NewLine;
            properties += "        public string Address { get; set; }" + Environment.NewLine;
            properties += "        public double? Langitude { get; set; }" + Environment.NewLine;
            properties += "        public double? Latitude { get; set; }" + Environment.NewLine;
            properties += "        public long? UpperOrganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public string UpperOrganizationName { get; set; }" + Environment.NewLine;
            properties += "        public long? CountryOid { get; set; }" + Environment.NewLine;
            properties += "        public string CountryName { get; set; }" + Environment.NewLine;
            properties += "        public long? CityOid { get; set; }" + Environment.NewLine;
            properties += "        public string CityName { get; set; }" + Environment.NewLine;
            properties += "        public string ZipCode { get; set; }" + Environment.NewLine;
            properties += "        public string LogoBase64 { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "OrganizationDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
