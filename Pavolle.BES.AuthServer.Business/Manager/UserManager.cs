using DevExpress.Xpo;
using log4net;
using Pavolle.BES.AuthServer.DbModels;
using Pavolle.BES.AuthServer.DbModels.Entities;
using Pavolle.BES.AuthServer.ViewModels.Model;
using Pavolle.Core.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.Business.Manager
{
    public class UserManager : Singleton<UserManager>
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(UserManager));
        ConcurrentDictionary<long, UserCacheModel> _users;
        private UserManager() { }

        public void LoadCacheData()
        {
            using(Session session = AuthServerXpoManager.Instance.GetNewSession())
            {
                var users = session.Query<User>().Select(t => new UserCacheModel
                {
                    Oid = t.Oid,
                    Username = t.Username,
                    Name = t.Person.Name,
                    Surname = t.Person.Surname
                });

                _users = new ConcurrentDictionary<long, UserCacheModel>();
                foreach (var user in users)
                {
                    _users.TryAdd(user.Oid, user);
                }
            }
        }
    }
}
