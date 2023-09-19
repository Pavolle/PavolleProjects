using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Criteria
{
    public class ListTranslateDataCriteriaCreatorManager : Singleton<ListTranslateDataCriteriaCreatorManager>, ICreatorManager
    {
        private ListTranslateDataCriteriaCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += Environment.NewLine;
            var creator = new CriteriaCreatorManager(companyName, projectName, projectPath, properties, "ListTranslateDataCriteria");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
