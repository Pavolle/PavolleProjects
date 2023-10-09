using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.Criteria
{
    internal class LookupCountryCriteriaCreatorManager : Singleton<LookupCountryCriteriaCreatorManager>
    {
        private LookupCountryCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "LookupCountryCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
