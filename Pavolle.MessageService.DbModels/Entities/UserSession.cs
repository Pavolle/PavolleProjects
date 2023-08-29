using DevExpress.Xpo;

namespace Pavolle.MessageService.DbModels.Entities
{
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
