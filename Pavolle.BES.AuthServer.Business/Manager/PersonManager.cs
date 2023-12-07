using log4net;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class PersonManager : Singleton<PersonManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(PersonManager));
        private PersonManager() { }
    }
}
