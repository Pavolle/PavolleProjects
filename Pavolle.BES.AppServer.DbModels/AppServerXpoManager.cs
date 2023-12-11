using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Pavolle.Core.Utils;
using System.Reflection;
using Pavolle.BES.AppServer.DbModels.Entities;

namespace Pavolle.BES.AppServer.DbModels
{
    public class AppServerXpoManager : Singleton<AppServerXpoManager>
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        private readonly object LockObject = new object();

        private AppServerXpoManager()
        {
        }

        public void InitXpo(String connectionString)
        {
            _connectionString = connectionString;
            SetDataLayer();
        }

        public Session GetNewSession()
        {
            var session = new Session(DataLayer);
            return session;
        }


        private volatile IDataLayer _fDataLayer;

        private IDataLayer DataLayer
        {
            get
            {
                SetDataLayer();

                return _fDataLayer;
            }
        }

        public XPClassInfo GetClassInfo(Type t)
        {
            return DataLayer.Dictionary.GetClassInfo(t);
        }

        private void SetDataLayer()
        {
            if (_fDataLayer == null)
            {
                lock (LockObject)
                {
                    if (_fDataLayer == null)
                    {
                        _fDataLayer = GetDataLayer();
                    }
                }
            }
        }

        public void SetDataLayer(IDataLayer dataLayer)
        {
            _fDataLayer = dataLayer;
        }

        private IDataLayer GetDataLayer()
        {
            IDataLayer dl = null;

            if (!string.IsNullOrEmpty(_connectionString))
            {
                XpoDefault.Session = null;
                XPDictionary dict = new ReflectionDictionary();

                string connectionPoolString = XpoDefault.GetConnectionPoolString(_connectionString, 30, 500);

                IDataStore store = XpoDefault.GetConnectionProvider(connectionPoolString, AutoCreateOption.DatabaseAndSchema);
                dict.GetDataStoreSchema(typeof(BaseObject).Assembly);
                dl = new ThreadSafeDataLayer(dict, store);

                Session newSession = new Session(dl);
                Assembly executingAssembly = Assembly.GetExecutingAssembly();

                Type[] array = executingAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseObject))).ToArray();

                newSession.UpdateSchema(array);
            }

            return dl;
        }
    }
}