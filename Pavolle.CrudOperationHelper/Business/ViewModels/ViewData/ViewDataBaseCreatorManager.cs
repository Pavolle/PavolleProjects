using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class ViewDataBaseCreatorManager : Singleton<ViewDataBaseCreatorManager>, ICreatorManager
    {
        private ViewDataBaseCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, projectName + "ViewDataBase", "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
