using DevExpress.Xpo;
using log4net;
using Pavolle.BES.AuthServer.DbModels;
using Pavolle.BES.AuthServer.DbModels.Entities;
using Pavolle.BES.AuthServer.ViewModels.Model;
using Pavolle.Core.Utils;
using Pavolle.Security;
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
        ConcurrentDictionary<string, UserCacheModel> _users;
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
                    Surname = t.Person.Surname,
                    Password = t.Password
                });

                _users = new ConcurrentDictionary<string, UserCacheModel>();
                foreach (var user in users)
                {
                    _users.TryAdd(user.Username, user);
                }
            }
        }

        public UserCacheModel? GetUserCacheDataByOid(long oid)
        {
            if (_users.ContainsKey(oid)) { return _users[oid]; }
            return null;
        }

        public bool ValidateUser(string username, string password)
        {
            bool success=false;
            success=_users.ContainsKey(username);
            if (!success) { return success; }
            var user = _users[username];
            if (user == null) { return false; }
            success= SecurityHelperManager.Instance.GetEncryptedPassword(password,username)==user.Password;
            return success;
        }
    }
}
