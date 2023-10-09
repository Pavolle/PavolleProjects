using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Request
{
    internal class EditOrganizationRequestCreatorManager : Singleton<EditOrganizationRequestCreatorManager>
    {
        private EditOrganizationRequestCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Address { get; set; }" + Environment.NewLine;
            properties += "        public double? Langitude { get; set; }" + Environment.NewLine;
            properties += "        public double? Latitude { get; set; }" + Environment.NewLine;
            properties += "        public long? UpperOrganizationOid { get; set; }" + Environment.NewLine;
            properties += "        public long? CountryOid { get; set; }" + Environment.NewLine;
            properties += "        public long? CityOid { get; set; }" + Environment.NewLine;
            properties += "        public string ZipCode { get; set; }" + Environment.NewLine;
            properties += "        public string LogoBase64 { get; set; }" + Environment.NewLine;
            var creator = new RequestCreatorManager(companyName, projectName, projectPath, properties, "EditOrganizationRequest", projectName + "RequestBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
