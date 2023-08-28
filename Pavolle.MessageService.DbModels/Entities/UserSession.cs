using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    //Bunu mevcut token'ın bizim tarafımızdan üretilen bir token olduğunu kontrol etmek için oluşturuyoruz.
    [Persistent("user_sessions")]
    public class UserSession : BaseObject
    {
        public UserSession(Session session) : base(session)
        {
        }

        [Persistent("token")]
        [Size(1000)]
        public string Token { get; set; }

        [Persistent("request_ip")]
        [Size(20)]
        public string RequestIp { get; set; }
    }
}
