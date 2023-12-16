using DevExpress.Xpo;
using Pavolle.BES.DYS.DbModels;
using Pavolle.BES.DYS.DbModels.Entities;
using Pavolle.BES.DYS.ViewModels.Integration.Request;
using Pavolle.BES.DYS.ViewModels.Response;
using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.DYS.Business.Integration
{
    public class SuppleraIntegrationManager : Singleton<SuppleraIntegrationManager>
    {
        private SuppleraIntegrationManager() { }

        public DYSIntegrationResponseBase SaveBomFile(SuppleraIntegrationBomFileRequest request)
        {
            bool success = false;
            try
            {
                using(Session session = DYSXpoManager.Instance.GetNewSession())
                {
                    //root
                    //organization
                    //supplera
                    //product
                    //version
                    var root = session.Query<Folder>().FirstOrDefault(t => t.Name == "root");
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new DYSIntegrationResponseBase
            {
                Success = success
            };
        }
    }
}
