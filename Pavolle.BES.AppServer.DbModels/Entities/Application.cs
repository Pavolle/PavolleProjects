using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AppServer.DbModels.Entities
{
    [Persistent("applications")]
    public class Application : BaseObject
    {
        public Application(Session session) : base(session)
        {
        }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("about")]
        public string About { get; set; }

        [Persistent("application_type")]
        public EApplicationType ApplicationType { get; set; }

        [Persistent("application_type")]
        public EBesAppType? BesAppType { get; set; }

        [Persistent("mobile_app_platform")]
        public EMobileAppPlatform? MobileAppPlatform { get; set; }
    }
}
