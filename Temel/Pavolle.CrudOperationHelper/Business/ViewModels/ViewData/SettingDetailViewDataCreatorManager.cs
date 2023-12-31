﻿using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class SettingDetailViewDataCreatorManager : Singleton<SettingDetailViewDataCreatorManager>, ICreatorManager
    {
        private SettingDetailViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public ESettingType SettingType { get; set; }" + Environment.NewLine;
            properties += "        public string SettingName { get; set; }" + Environment.NewLine;
            properties += "        public string Value { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "SettingDetailViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
