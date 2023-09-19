using DevExpress.Xpo;
using log4net;
using Pavolle.Core.Utils;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.Common.Utils;
using Pavolle.MessageService.DbModels;
using Pavolle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class SetupManager:Singleton<SetupManager>
    {
        private SetupManager()
        {

        }

        public void Setup(string managerCompany, string code, string adminusername, string adminpassword, int setupLanguage)
        {
           
        }

        private void YetkiYoksaYaz(Session session, string apiKey, string apiDefintion, 
            bool admin, 
            bool companyAdmin, 
            bool projectPanager,
            bool developer,
            bool tecnicalSupportSpecialist,
            bool liveSupportSpecialist,
            bool editable, 
            bool anonymous)
        {
            
        }
    }
}
