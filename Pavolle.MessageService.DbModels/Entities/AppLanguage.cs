using DevExpress.Xpo;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("app_language")]
    public class AppLanguage : BaseObject
    {
        public AppLanguage(Session session) : base(session)
        {
        }

        [Persistent("app_oid")]
        public App App { get; set; }

        [Persistent("language")]
        public ELanguage Language { get; set; }

        [Persistent("is_active")]
        public bool IsActive { get; set; }
    }
}
