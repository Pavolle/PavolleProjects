using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
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

        [Persistent("api_definition_td_oid")]
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
