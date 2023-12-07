using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.ViewModels.Model
{
    public class UserCacheModel
    {
        public long Oid { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
