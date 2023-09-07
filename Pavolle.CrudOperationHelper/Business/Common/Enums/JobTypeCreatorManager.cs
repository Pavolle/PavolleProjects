using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.Common.Enums
{
    public class JobTypeCreatorManager : Singleton<JobTypeCreatorManager> , ICreatorManager
    {
        CommonEnumCreatorManager _creator;
        private JobTypeCreatorManager() { }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            _creator = new CommonEnumCreatorManager(companyName, projectName, projectPath, "EJobType");
            string icerik = "        CleanSession=1,"+Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath, _creator.Path, _creator.ClassName + ".cs", _creator.EnumClass.Replace("//<EnumContent>", icerik));
        }
    }
}
