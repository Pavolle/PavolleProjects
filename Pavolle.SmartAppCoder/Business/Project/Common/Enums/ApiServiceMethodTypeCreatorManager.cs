using Pavolle.SmartAppCoder.Business;
using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.Common.Enums
{
    public class ApiServiceMethodTypeCreatorManager : Singleton<ApiServiceMethodTypeCreatorManager>
    {
        CommonEnumCreatorManager _creator;
        private ApiServiceMethodTypeCreatorManager()
        {

        }
        public bool Create(string companyName, string projectName, string projectPath)
        {
            _creator = new CommonEnumCreatorManager(companyName, projectName, projectPath, "EApiServiceMethodType");
            string icerik = "";
            icerik += "        Get = 1," + Environment.NewLine;
            icerik += "        Post = 2," + Environment.NewLine;
            icerik += "        Put = 3," + Environment.NewLine;
            icerik += "        Delete = 4" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs",_creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}
