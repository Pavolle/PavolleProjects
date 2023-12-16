using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AppServer.DbModels.Entities
{
    [Persistent("applicatation_license")]
    public class ApplicationLicense : BaseObject
    {
        public ApplicationLicense(Session session) : base(session)
        {
        }

        [Persistent("organization_oid")]
        public long OrganizationOid { get; set; }

        [Persistent("application_oid")]
        public Application Application { get; set; }

        [Persistent("app_license_type")]
        public EAppLicenseType AppLicenseType { get; set; }

        [Persistent("start_time")]
        public DateTime StartTime { get; set; }

        [Persistent("end_time")]
        public DateTime EndTime { get; set; }
    }
}
