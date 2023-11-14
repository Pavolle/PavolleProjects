using DevExpress.Xpo;
using Pavolle.BES.AuthServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("apps")]
    public class App : BaseObject
    {
        public App(Session session) : base(session)
        {
        }

        [Persistent("app_type")]
        public EBesAppType AppType { get; set; }

        [Persistent("name")]
        public string Name { get; set; }

        [Persistent("app_id")]
        public string AppId { get; set; }

        [Persistent("activated")]
        public bool Activated { get; set; }
    }
}
