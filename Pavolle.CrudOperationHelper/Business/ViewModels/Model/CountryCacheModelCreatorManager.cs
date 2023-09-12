using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class CountryCacheModelCreatorManager : Singleton<CountryCacheModelCreatorManager>
    {
        private CountryCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath, string language)
        {
            string[] _languages = language.Split(',');
            string properties = "";
            properties += "        public string ISOCode2 { get; set; }" + Environment.NewLine;
            properties += "        public string ISOCode3 { get; set; }" + Environment.NewLine;
            properties += "        public string PhoneCode { get; set; }" + Environment.NewLine;

            foreach (var item in _languages)
            {
                properties += "        public string " + item.Replace(" ", "").ToUpper() + "Name { get; set; }" + Environment.NewLine;
            }
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "CountryCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
