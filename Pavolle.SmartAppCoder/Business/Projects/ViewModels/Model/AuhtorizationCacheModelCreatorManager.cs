using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Model
{
    public class AuhtorizationCacheModelCreatorManager : Singleton<AuhtorizationCacheModelCreatorManager>
    {
        private AuhtorizationCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long Oid { get; set; }" + Environment.NewLine;
            properties += "        public long UserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public EApiServiceMethodType MethodType { get; set; }" + Environment.NewLine;
            properties += "        public string ApiKey { get; set; }" + Environment.NewLine;
            properties += "        public bool IsAuthority { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "AuhtorizationCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
