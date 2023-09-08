using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("user_sessions")]
    public class UserSession : BaseObject
    {
        public UserSession(Session session) : base(session) {}

        [Persistent("token")]
        [Size(1000)]
        public string Token { get; set; }

        [Persistent("request_ip")]
        [Size(20)]
        public string RequestIp { get; set; }

        [Persistent("active")]
        public bool Active { get; set; }

        [Persistent("username")]
        [Size(50)]
        public string Username { get; set; }

        [Persistent("session_id")]
        [Size(50)]
        public string SessionId { get; set; }

    }
}
