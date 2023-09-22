using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.ViewData
{
    public class ImageLookupViewDataCreatorManager : Singleton<ImageLookupViewDataCreatorManager>
    {
        private ImageLookupViewDataCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "namespace " + organizationName + ".Core.ViewModels.ViewData" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class ImageLookupViewData : LookupViewData" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public string ImageBase64 { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\ViewData", "ImageLookupViewData.cs", classString);

        }
    }
}
