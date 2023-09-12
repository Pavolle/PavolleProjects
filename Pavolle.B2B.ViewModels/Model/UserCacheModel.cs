using Pavolle.B2B.Common.Enums;
using Pavolle.Core.Enums;

namespace Pavolle.B2B.ViewModels.Model
{
    public class UserCacheModel
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int IsLocked { get; set; }
        public bool Code { get; set; }
        public bool Password { get; set; }
        public long UserGroupOid { get; set; }
        public EUserType UserType { get; set; }
        public bool Name { get; set; }
        public bool Surname { get; set; }
    }
}
