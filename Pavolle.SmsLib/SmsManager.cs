using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmsLib
{
    public class SmsManager:Singleton<SmsManager>, ISmsManager
    {
        private SmsManager()
        {

        }

        public void Initialize(ESmsCompanyType smsCompanyType)
        {

        }

        public bool SendSms(string content, string number)
        {
            throw new NotImplementedException();
        }
    }
}
