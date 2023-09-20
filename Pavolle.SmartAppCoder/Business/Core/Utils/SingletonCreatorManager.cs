using Pavolle.SmartAppCoder.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business.Core.Utils
{
    public class SingletonCreatorManager : Singleton<SingletonCreatorManager>
    {
        private SingletonCreatorManager() { }


        public bool Create(string projectPath, string organizationName)
        {
            string classString = "";
            classString += "using System.Globalization;" + Environment.NewLine;
            classString += "using System.Reflection;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "namespace " + organizationName + ".Core.Utils" + Environment.NewLine;
            classString += "{" + Environment.NewLine;
            classString += "    public abstract class Singleton<T> where T : class" + Environment.NewLine;
            classString += "    {" + Environment.NewLine;
            classString += "        protected static readonly object SyncRoot = new Object();" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        private static volatile T _instance;" + Environment.NewLine;
            classString += "" + Environment.NewLine;
            classString += "        public static T Instance" + Environment.NewLine;
            classString += "        {" + Environment.NewLine;
            classString += "            get" + Environment.NewLine;
            classString += "            {" + Environment.NewLine;
            classString += "                if (_instance == null)" + Environment.NewLine;
            classString += "                {" + Environment.NewLine;
            classString += "                    if (_instance == null)" + Environment.NewLine;
            classString += "                    {" + Environment.NewLine;
            classString += "                        Type theType = typeof(T);" + Environment.NewLine;
            classString += "                        try" + Environment.NewLine;
            classString += "                        {" + Environment.NewLine;
            classString += "                            _instance = (T)theType.InvokeMember(theType.Name, BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic, null, null, null, CultureInfo.InvariantCulture);" + Environment.NewLine;
            classString += "                        }" + Environment.NewLine;
            classString += "                        catch (MissingMethodException ex)" + Environment.NewLine;
            classString += "                        {" + Environment.NewLine;
            classString += "                            throw new TypeLoadException(string.Format(CultureInfo.CurrentCulture, \"The type '{0}' singleton tasarım örüntüsünde private constructor kullanılmalıdır.\", theType.FullName), ex);" + Environment.NewLine;
            classString += "                        }" + Environment.NewLine;
            classString += "                    }" + Environment.NewLine;
            classString += "                }" + Environment.NewLine;
            classString += "                return _instance;" + Environment.NewLine;
            classString += "            }" + Environment.NewLine;
            classString += "        }" + Environment.NewLine;
            classString += "    }" + Environment.NewLine;
            classString += "}" + Environment.NewLine;
            return FileHelperManager.Instance.WriteFile(projectPath + "\\" + organizationName + ".Core", "Utils", "Singleton.cs", classString);

        }
    }
}
