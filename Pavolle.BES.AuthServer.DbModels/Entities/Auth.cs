using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    public class Auth : BaseObject
    {
        public Auth(Session session) : base(session)
        {
        }

        public ApiService ApiService { get; set; }
        public UserGroup UserGroup { get; set; }
        public bool IsAuthority { get; set; }
    }
}
