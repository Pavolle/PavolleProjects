using DevExpress.Xpo;
using Pavolle.B2B.Common.Enums;

namespace Pavolle.B2B.DbModels.Entities
{
    [Persistent("user_groups")]
    public class ApiService.cs : BaseObject
    {

        public ApiService.cs(Session session) : base(session)
        {
        }

        [Persistent("api_key")]
        [Size(255)]
        public string ApiKey { get; set; }

        [Persistent("api_definition")]
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
