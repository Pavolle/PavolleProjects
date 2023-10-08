using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;

namespace Pavolle.SmartAppCoder.Business.Projects.DbModels
{
    public class TranslateDataCreatorManager : Singleton<TranslateDataCreatorManager>
    {
        DbModelCreatorManager creator;

        private TranslateDataCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath, string language)
        {
            if (language == null) language = "en, tr";
            string projectNameRoot = companyName + "."  +projectName;
            string[] _languages = language.Split(',');
            string translateDataClass = "";
            translateDataClass += "using DevExpress.Xpo;" + Environment.NewLine;
            translateDataClass += "" + Environment.NewLine;
            translateDataClass += "namespace " + projectNameRoot + ".DbModels.Entities" + Environment.NewLine;
            translateDataClass += "{" + Environment.NewLine;
            translateDataClass += "    [Persistent(\"translate_datas\")]" + Environment.NewLine;
            translateDataClass += "    public class TranslateData : BaseObject" + Environment.NewLine;
            translateDataClass += "    {" + Environment.NewLine;
            translateDataClass += "        public TranslateData(Session session) : base(session)" + Environment.NewLine;
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

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + ".DbModels/Entities", "TranslateData.cs", translateDataClass);
        }
    }
}
