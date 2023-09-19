using DevExpress.Xpo;
using Pavolle.SmartAppCoder.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.SmartAppCoder.Models
{
    [Persistent("projects")]
    public class Project : BaseObject
    {
        public Project(Session session) : base(session)
        {
        }

        [Persistent("organization")]
        [Size(255)]
        public string OrganizationName { get; set; }

        [Persistent("name")]
        [Size(255)]
        public string ProjectName { get; set; }

        [Persistent("path")]
        [Size(255)]
        public string ProjectPath { get; set; }

        [Persistent("web_technology")]
        public EWebAppTecnology WebAppTecnology { get; set; }

        [Persistent("db_technology")]
        public EDbTechnology DbTechnology { get; set; }

        [Persistent("mobile_technology")]
        public EMobileTechnology MobileTechnology { get; set; }

        [Persistent("security_level")]
        public ESecurityLevel SecurityLevel { get; set; }

        [Persistent("languages")]
        public string Languages { get; set; }

        [Persistent("issuer")]
        [Size(255)]
        public string Issuer { get; set; }

        [Persistent("audience")]
        [Size(255)]
        public string Audience { get; set; }

        [Persistent("token_expire_minute")]
        public int TokenExpireMinute { get; set; }

        [Persistent("initialize")]
        public bool Initlaize { get; set; }
    }
}
