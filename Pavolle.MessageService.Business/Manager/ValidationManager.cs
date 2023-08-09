using Pavolle.Core.Utils;
using Pavolle.Core.ViewModels.Response;
using Pavolle.Multilanguage;
using Pavolle.MessageService.Common.Enums;
using Pavolle.MessageService.ViewModels.Request;
using Pavolle.MessageService.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Pavolle.MessageService.Business.Manager
{
    public class ValidationManager:Singleton<ValidationManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(ValidationManager));
        private ValidationManager()
        {

        }

        public MessageServiceResponseBase CheckRequestBaseParameter(MessageServiceRequestBase request)
        {
            var response = new MessageServiceResponseBase
            {
                Success = true
            };

            if (request == null)
            {
                response.Success = false;
                response.ErrorMessage = "";
            }

            return response;
        }

        internal MessageServiceResponseBase CheckNull(object x, EMessageCode messageCode)
        {
            throw new NotImplementedException();
        }

        internal MessageServiceResponseBase CheckString(string name1, bool v1, int v2, int v3, EMessageCode name2)
        {
            //Metin olduğu için herzaman XSS kontrolü yapacağız.
            throw new NotImplementedException();
        }

        internal MessageServiceResponseBase GetIslemYapmaYetkinizYokturMessage()
        {
            throw new NotImplementedException();
        }
    }
}
