using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("user_groups")]
    public class ApiService : BaseObject
    {

        public ApiService(Session session) : base(session)
        {
        }

        [Persistent("api_key")]
        [Size(255)]
        public string ApiKey { get; set; }

        [Persistent("api_definition_td_oid")]
        [Size(255)]
        public TranslateData ApiDefinition { get; set; }

        [Persistent("method_type")]
        public EApiServiceMethodType MethodType { get; set; }

        [Persistent("editable_for_admin")]
        public bool EditableForAdmin { get; set; }

        [Persistent("editable_for_organization")]
        public bool EditableForOrganization { get; set; }

        [Persistent("Anonymous")]
        public bool Anonymous { get; set; }
    }
}
