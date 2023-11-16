using Pavolle.BES.DYS.ViewModels.Integration.Request;
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

        public ResponseBase Edit(SuppleraIntegrationBomFileRequest request)
        {
            bool success = false;
            try
            {
                //Get base folder name
                //Check Organization folder if not create
                //Check supplera folder if not create
                //Check product folder if not create
                //Check version folder if not create
                //Encrypt and save file 
            }
            catch (Exception)
            {

                throw;
            }
            return new ResponseBase
            {
                Success = success
            };
        }
    }
}
