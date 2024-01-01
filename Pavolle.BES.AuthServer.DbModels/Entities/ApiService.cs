using DevExpress.Xpo;
using Pavolle.BES.AppServer.Common.Enums;
using Pavolle.BES.AuthServer.Common.Enums;
using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.AuthServer.DbModels.Entities
{
    [Persistent("api_service")]
    public class ApiService : BaseObject
    {

        public ApiService(Session session) : base(session)
        {
        }

        [Persistent("api_key")]
        [Size(255)]
        public string ApiKey { get; set; }


        [Persistent("bes_app_type")]
        public EBesAppType BesAppType { get; set; }


        [Persistent("api_definition")]
        [Size(500)]
        public string ApiDefinition { get; set; }


        [Persistent("method_type")]
        public EApiServiceMethodType MethodType { get; set; }

        [Persistent("editable_for_admin")]
        public bool EditableForAdmin { get; set; }


        [Persistent("editable_for_organization")]
        public bool EditableForOrganization { get; set; }


        [Persistent("anonymous")]
        public bool Anonymous { get; set; }
    }
}
