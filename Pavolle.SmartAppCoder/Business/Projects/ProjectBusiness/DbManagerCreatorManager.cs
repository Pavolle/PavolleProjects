using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Projects.ProjectBusiness
{
    public class DbManagerCreatorManager : Singleton<DbManagerCreatorManager>
    {
        private DbManagerCreatorManager() { }

        public bool Create(string organizationName, string projectName, string projectPath, string language)
        {
            if (language == null) language = "en, tr";
            string[] _languages = language.Split(',');
            string projectNameRoot = organizationName + "." + projectName;
            string classString = "";
            classString += "using DevExpress.Xpo;" + Environment.NewLine;
            classString += "using log4net;" + Environment.NewLine;
            classString += "using " + organizationName + ".Core.Enums;" + Environment.NewLine;
            classString += "using " + organizationName + ".Core.Utils;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".Common.Enums;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels.Entities;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".DbModels.Manager;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Criteria;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Model;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Request;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.Response;" + Environment.NewLine;
            classString += "using " + projectNameRoot + ".ViewModels.ViewData;" + Environment.NewLine;
            classString += "using System.Linq;" + Environment.NewLine;
            classString += "using System;" + Environment.NewLine;
            classString += "using System.Collections.Concurrent;" + Environment.NewLine;
            classString += "using System.Collections.Generic;" + Environment.NewLine;
            classString += "using System.Text;" + Environment.NewLine;
            classString += "using System.Threading.Tasks;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + projectNameRoot + ".Business.Manager" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public class DbManager : Singleton<DbManager>" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        static readonly ILog _log = LogManager.GetLogger(typeof(DbManager));" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private DbManager()" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            _log.Debug(\"Initialize \"+nameof(DbManager));" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public bool Initialize(string connectionString)" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            try" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                XpoManager.Instance.InitXpo(connectionString);" + Environment.NewLine;
            classString += "                _log.Info(\"Database connection etablish.\");" + Environment.NewLine;
            classString += "                return true;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "            catch (Exception ex)" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                _log.Error(\"Database connection error: \" + ex);" + Environment.NewLine;
            classString += "                return false;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;


            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".Business/Manager", "DbManager.cs", classString);
        }
    }
}

