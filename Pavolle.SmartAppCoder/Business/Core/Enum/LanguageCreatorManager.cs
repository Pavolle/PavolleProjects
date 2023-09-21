using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.Enum
{
    public class LanguageCreatorManager : Singleton<LanguageCreatorManager>
    {
        private LanguageCreatorManager() { }

        public bool Create(string projectPath, string organizationName)
        {
            string content = "";
            content += "        [Description(\"en\")]" + Environment.NewLine;
            content += "        English = 1," + Environment.NewLine;
            content += "" + Environment.NewLine;

            content += "        [Description(\"de\")]" + Environment.NewLine;
            content += "        German = 2," + Environment.NewLine;
            content += "" + Environment.NewLine;

            content += "        [Description(\"es\")]" + Environment.NewLine;
            content += "        Spanish = 3," + Environment.NewLine;
            content += "" + Environment.NewLine;

            content += "        [Description(\"fr\")]" + Environment.NewLine;
            content += "        French = 4," + Environment.NewLine;
            content += "" + Environment.NewLine;

            content += "        [Description(\"ru\")]" + Environment.NewLine;
            content += "        Russian = 5," + Environment.NewLine;
            content += "" + Environment.NewLine;

            content += "        [Description(\"tr\")]" + Environment.NewLine;
            content += "        Turkish = 6," + Environment.NewLine;
            content += "" + Environment.NewLine;

            content += "        [Description(\"az\")]" + Environment.NewLine;
            content += "        Azerbaijani = 7," + Environment.NewLine;
            content += "" + Environment.NewLine;
            string classString = EnumClassGenerator.Instance.Generate(organizationName + ".Core.Enums", "ELanguage", content);
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "Enums", "ELanguage.cs", classString);

        }
    }
}
