﻿using Pavolle.SmartAppCoder.Common.Utils;

namespace Pavolle.SmartAppCoder.Business.Projects.ViewModels.ViewData
{
    public class ViewDataBaseCreatorManager : Singleton<ViewDataBaseCreatorManager>
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
