using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class UserDetailViewDataCreatorManager : Singleton<UserDetailViewDataCreatorManager>
    {
        private UserDetailViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public long UserGroupOid { get; set; }" + Environment.NewLine;
            properties += "        public string UserGroupName { get; set; }" + Environment.NewLine;
            properties += "        public string Username { get; set; }" + Environment.NewLine;
            properties += "        public EUserType UserType { get; set; }" + Environment.NewLine;
            properties += "        public string Name { get; set; }" + Environment.NewLine;
            properties += "        public string Surname { get; set; }" + Environment.NewLine;
            properties += "        public string Email { get; set; }" + Environment.NewLine;
            properties += "        public bool EmailVerify { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneNumber { get; set; }" + Environment.NewLine;
            properties += "        public bool PhoneNumberVerify { get; set; }" + Environment.NewLine;
            properties += "        public string Password { get; set; }" + Environment.NewLine;
            properties += "        public int WrongTryCount { get; set; }" + Environment.NewLine;
            properties += "        public bool IsLocked { get; set; }" + Environment.NewLine;
            properties += "        public string Code { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "UserDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
