using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.PasswordServer.DbModels.Entities
{
    [Persistent("passwords")]
    public class Pasword : BaseObject
    {
        public Pasword(Session session) : base(session)
        {
        }

        [Persistent("encryted_pasword")]
        [Size(1000)]
        public string EncrytedPasword { get; set; }

        //64 karakter SHA256
    }
}
