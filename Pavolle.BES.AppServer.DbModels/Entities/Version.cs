using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AppServer.DbModels.Entities
{
    public class Version : BaseObject
    {
        public Version(Session session) : base(session)
        {
        }

        public Application Application { get; set; }
        public bool IsCurrentVersion { get; set; }
    }
}
