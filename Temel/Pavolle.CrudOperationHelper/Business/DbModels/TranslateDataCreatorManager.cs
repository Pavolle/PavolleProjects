using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class TranslateDataCreatorManager : Singleton<TranslateDataCreatorManager>
    {
        DbModelCreatorManager creator;

        private TranslateDataCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath, string language)
        {
            string projectNameRoot = companyName + "."  +projectName;
            string[] _languages = language.Split(',');
            string translateDataClass = "";
            translateDataClass += "using DevExpress.Xpo;" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;
            translateDataClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            translateDataClass += "{" + Environment.NewLine;
            translateDataClass += "    [Persistent(\"translate_datas\")]" + Environment.NewLine;
            translateDataClass += "    public class " + AppConsts.DBModelsTranslateDataClassName + " : " + AppConsts.DBModelsBaseObjectClassName + Environment.NewLine;
            translateDataClass += "    {" + Environment.NewLine;
            translateDataClass += "        public " + AppConsts.DBModelsTranslateDataClassName + "(Session session) : base(session)" + Environment.NewLine;
            translateDataClass += "        {" + Environment.NewLine;
            translateDataClass += "        }" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;
            translateDataClass += "        [Persistent(\"variable\")]" + Environment.NewLine;
            translateDataClass += "        [Size(1000)]" + Environment.NewLine;
            translateDataClass += "        public string Variable { get; set; }" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;

            foreach (var item in _languages)
            {
                translateDataClass += "        [Persistent(\"" + item.Replace(" ","").ToLower() + "\")]" + Environment.NewLine;
                translateDataClass += "        [Size(1000)]" + Environment.NewLine;
                translateDataClass += "        public string " + item.Replace(" ", "").ToUpper() + " { get; set; }" + Environment.NewLine;
                translateDataClass += "" + Environment.NewLine;
            }
            translateDataClass += "    }" + Environment.NewLine;
            translateDataClass += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsTranslateDataClassFileName, translateDataClass);
        }
    }
}
