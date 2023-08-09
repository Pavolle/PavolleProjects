using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("user_projects_auth")]
    public class ProjectAuth : BaseObject
    {
        public ProjectAuth(Session session) : base(session)
        {
        }

        [Persistent("user_oid")]
        public User User { get; set; }

        [Persistent("app_oid")]
        public App App { get; set; }

        [Persistent("is_project_manager")]
        public bool IsProjectManager { get; set; }

        [Persistent("start_date")]
        public DateTime StartDate { get; set; }

        [Persistent("end_date")]
        public DateTime? EndDate { get; set; }
    }
}
