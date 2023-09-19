using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Common.Utils;
using Pavolle.SmartAppCoder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Business
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

        internal Project? GetProject(long projectOid)
        {
            using (Session session = XpoManager.Instance.GetNewSession())
            {
                var response= session.Query<Project>().FirstOrDefault(t => t.Oid == projectOid);
                if(response == null)
                {
                    return null;
                }
                return response;
            }
        }
    }
}
