using DevExpress.Xpo;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Db
{
    public class DbManager : Singleton<DbManager>
    {
        private DbManager()
        {

        }

        public void Initialize(string connectionString)
        {
            try
            {
                XpoManager.Instance.InitXpo(connectionString);
            }
            catch (Exception ex)
            {
                //TODO Burda info mesajı üretebiliriz. Onu daha sonraya bırakıyoruz.
            }
        }

        public List<string> GetProjectList()
        {
            var response=new List<string>();
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                response= session.Query<Project>().Select(t => t.Name).ToList();
            }
            return response;
        }

        public ProjectViewData GetProjectDetal(string name)
        {
            var response=new ProjectViewData();
            return response;
        }
    }

    public class ProjectViewData
    {

    }
}
