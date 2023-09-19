using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class XpoManagerCreatorManager : Singleton<XpoManagerCreatorManager>, ICreatorManager
    {
        private XpoManagerCreatorManager() { }
        public bool Write(string companyName, string projectName, string projectPath)
        {
            string projectNameRoot=companyName+"."+projectName;
            string xpoManagerClass = "";
            xpoManagerClass += "using DevExpress.Xpo.DB;" + Environment.NewLine;
            xpoManagerClass += "using DevExpress.Xpo.Metadata;" + Environment.NewLine;
            xpoManagerClass += "using DevExpress.Xpo;" + Environment.NewLine;
            xpoManagerClass += "using System.Reflection;" + Environment.NewLine;
            xpoManagerClass += "using System;" + Environment.NewLine;
            xpoManagerClass += "using System.Collections.Generic;" + Environment.NewLine;
            xpoManagerClass += "using System.Linq;" + Environment.NewLine;
            xpoManagerClass += "using System.Text;" + Environment.NewLine;
            xpoManagerClass += "using System.Threading.Tasks;" + Environment.NewLine;
            xpoManagerClass += "using " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + ";" + Environment.NewLine;
            xpoManagerClass += "using Pavolle.Core.Utils;" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + Environment.NewLine;
            xpoManagerClass += "{" + Environment.NewLine;
            xpoManagerClass += "    public class " + AppConsts.DBModelsXpoManagerClassName + " : Singleton<" + AppConsts.DBModelsXpoManagerClassName + ">" + Environment.NewLine;
            xpoManagerClass += "    {" + Environment.NewLine;
            xpoManagerClass += "        private string _connectionString;" + Environment.NewLine;
            xpoManagerClass += "        public string ConnectionString" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            get { return _connectionString; }" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private readonly object LockObject = new object();" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private " + AppConsts.DBModelsXpoManagerClassName + "()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public void InitXpo(String connectionString)" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            _connectionString = connectionString;" + Environment.NewLine;
            xpoManagerClass += "            SetDataLayer();" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public Session GetNewSession()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            var session = new Session(DataLayer);" + Environment.NewLine;
            xpoManagerClass += "            return session;" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private volatile IDataLayer _fDataLayer;" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private IDataLayer DataLayer" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            get" + Environment.NewLine;
            xpoManagerClass += "            {" + Environment.NewLine;
            xpoManagerClass += "                SetDataLayer();" + Environment.NewLine;
            xpoManagerClass += "                return _fDataLayer;" + Environment.NewLine;
            xpoManagerClass += "            }" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public XPClassInfo GetClassInfo(Type t)" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            return DataLayer.Dictionary.GetClassInfo(t);" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private void SetDataLayer()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            if (_fDataLayer == null)" + Environment.NewLine;
            xpoManagerClass += "            {" + Environment.NewLine;
            xpoManagerClass += "                lock (LockObject)" + Environment.NewLine;
            xpoManagerClass += "                {" + Environment.NewLine;
            xpoManagerClass += "                    if (_fDataLayer == null)" + Environment.NewLine;
            xpoManagerClass += "                    {" + Environment.NewLine;
            xpoManagerClass += "                        _fDataLayer = GetDataLayer();" + Environment.NewLine;
            xpoManagerClass += "                    }" + Environment.NewLine;
            xpoManagerClass += "                }" + Environment.NewLine;
            xpoManagerClass += "            }" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        public void SetDataLayer(IDataLayer dataLayer)" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            _fDataLayer = dataLayer;" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "        private IDataLayer GetDataLayer()" + Environment.NewLine;
            xpoManagerClass += "        {" + Environment.NewLine;
            xpoManagerClass += "            IDataLayer dl = null;" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "            if (!string.IsNullOrEmpty(_connectionString))" + Environment.NewLine;
            xpoManagerClass += "            {" + Environment.NewLine;
            xpoManagerClass += "                XpoDefault.Session = null;" + Environment.NewLine;
            xpoManagerClass += "                XPDictionary dict = new ReflectionDictionary();" + Environment.NewLine;
            xpoManagerClass += "                string connectionPoolString = XpoDefault.GetConnectionPoolString(_connectionString, 30, 500);" + Environment.NewLine;
            xpoManagerClass += "                IDataStore store = XpoDefault.GetConnectionProvider(connectionPoolString, AutoCreateOption.DatabaseAndSchema);" + Environment.NewLine;
            xpoManagerClass += "                dict.GetDataStoreSchema(typeof(BaseObject).Assembly);" + Environment.NewLine;
            xpoManagerClass += "                dl = new ThreadSafeDataLayer(dict, store);" + Environment.NewLine;
            xpoManagerClass += "                Session newSession = new Session(dl);" + Environment.NewLine;
            xpoManagerClass += "                Assembly executingAssembly = Assembly.GetExecutingAssembly();" + Environment.NewLine;
            xpoManagerClass += "                Type[] array = executingAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseObject))).ToArray();" + Environment.NewLine;
            xpoManagerClass += "                newSession.UpdateSchema(array);" + Environment.NewLine;
            xpoManagerClass += "            }" + Environment.NewLine;
            xpoManagerClass += "" + Environment.NewLine;
            xpoManagerClass += "            return dl;" + Environment.NewLine;
            xpoManagerClass += "        }" + Environment.NewLine;
            xpoManagerClass += "    }" + Environment.NewLine;
            xpoManagerClass += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName, AppConsts.DBModelsXpoManagerClassFileName, xpoManagerClass);
        }
    }
}
