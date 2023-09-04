using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.Business.Manager
{
    public class SettingManager:Singleton<SettingManager>
    {
        private SettingManager()
        {

        }

        internal ESecurityLevel GetSecurityLevel()
        {
            throw new NotImplementedException();
        }
    }
}
