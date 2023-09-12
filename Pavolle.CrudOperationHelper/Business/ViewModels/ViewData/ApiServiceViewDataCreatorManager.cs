﻿using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.ViewData
{
    public class ApiServiceViewDataCreatorManager : Singleton<ApiServiceViewDataCreatorManager>, ICreatorManager
    {
        private ApiServiceViewDataCreatorManager()
        {

        }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string properties = "";
            properties += "        public string ApiKey { get; set; }" + Environment.NewLine;
            properties += "        public string ApiDefinition { get; set; }" + Environment.NewLine;
            properties += "        public EApiServiceMethodType MethodType { get; set; }" + Environment.NewLine;
            properties += "        public bool EditableForAdmin { get; set; }" + Environment.NewLine;
            properties += "        public bool EditableForOrganization { get; set; }" + Environment.NewLine;
            properties += "        public bool Anonymous { get; set; }" + Environment.NewLine;
            var creator = new ViewDataCreatorManager(companyName, projectName, projectPath, properties, "ApiServiceViewData", projectName + "ViewDataBase");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
