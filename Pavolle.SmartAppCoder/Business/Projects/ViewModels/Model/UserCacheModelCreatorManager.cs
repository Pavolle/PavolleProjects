using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Model
{
    public class UserCacheModelCreatorManager : Singleton<UserCacheModelCreatorManager>
    {
        private UserCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string Username { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneNumber { get; set; }" + Environment.NewLine;
            properties += "        public string Email { get; set; }" + Environment.NewLine;
            properties += "        public int IsLocked { get; set; }" + Environment.NewLine;
            properties += "        public bool Code { get; set; }" + Environment.NewLine;
            properties += "        public bool Password { get; set; }" + Environment.NewLine;
            properties += "        public long UserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public EUserType UserType { get; set; }" + Environment.NewLine;
            properties += "        public bool Name { get; set; }" + Environment.NewLine;
            properties += "        public bool Surname { get; set; }" + Environment.NewLine;
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "UserCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
