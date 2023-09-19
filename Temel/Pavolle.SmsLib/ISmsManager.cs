using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmsLib
{
    public interface ISmsManager
    {
        bool SendSms(string content, string number);
    }
}
