using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.ViewModels.Response
{
    internal class ImageLookupResponseCreatorManager : Singleton<ImageLookupResponseCreatorManager>
    {
        private ImageLookupResponseCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {

            string classString = "";
            classString += "using " + organizationName + ".Core.ViewModels.ViewData;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Core.ViewModels.Response" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class ImageLookupResponse : ResponseBase" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        public List<ImageLookupViewData> DataList { get; set; }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "ViewModels\\Response", "ImageLookupResponse.cs", classString);
        }
    }
}
