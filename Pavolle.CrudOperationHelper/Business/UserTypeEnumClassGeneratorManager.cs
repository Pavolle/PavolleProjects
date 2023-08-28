using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business
{
    public class UserTypeEnumClassGeneratorManager:Singleton<UserTypeEnumClassGeneratorManager>
    {
        private UserTypeEnumClassGeneratorManager()
        {

        }

        public bool Generate(string projectNameRoot, string projectPath, string userType)
        {
            string[] userTypes = userType.Split(',');
            int enumBaslangicSayisi = 1;
            string userTypeClass = "";
            userTypeClass += "namespace " + projectNameRoot + "." + AppConsts.CommonProjectName + "." + AppConsts.CommonEnumFolderName + "" + Environment.NewLine;
            userTypeClass += "{" + Environment.NewLine;
            userTypeClass += "    public enum EUserType" + Environment.NewLine;
            userTypeClass += "    {" + Environment.NewLine;
            foreach (var item in userTypes)
            {
                var type = item.Trim();
                userTypeClass += "        "+item.Replace(" ","") +" = "+enumBaslangicSayisi+"," + Environment.NewLine;

                enumBaslangicSayisi++;
            }
            userTypeClass += "    }" + Environment.NewLine;
            userTypeClass += "}" + Environment.NewLine;

             return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.CommonProjectName + "/" + AppConsts.CommonEnumFolderName, AppConsts.UserTypeEnumClassName, userTypeClass);
        }
    }
}
