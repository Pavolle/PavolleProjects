using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.ViewModels.Model
{
    public class CityCacheModelCreatorManager : Singleton<CityCacheModelCreatorManager>
    {
        private CityCacheModelCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath, string language)
        {
            string[] _languages = language.Split(',');
            string properties = "";
            properties += "        public long Oid { get; set; }" + Environment.NewLine;
            properties += "        public string Code { get; set; }" + Environment.NewLine;
            foreach (var item in _languages)
            {
                properties += "        public string " + item.Replace(" ", "").ToUpper() + "Name { get; set; }" + Environment.NewLine;
            }
            var creator = new ModelCreatorManager(companyName, projectName, projectPath, properties, "CityCacheModel");
            return FileHelperManager.Instance.WriteFile(projectPath, creator.Path, creator.ClassName + ".cs", creator.ClassString);
        }
    }
}
