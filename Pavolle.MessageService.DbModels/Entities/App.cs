using DevExpress.Xpo;
using Pavolle.MessageService.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MessageService.DbModels.Entities
{
    [Persistent("apps")]
    public class App : BaseObject
    {
        public App(Session session) : base(session)
        {
        }

        [Persistent("company_oid")]
        public Company Company { get; set; }

        [Persistent("app_id")]
        [Indexed(Unique =true, Name = "index_apps_appid")]
        public string AppId { get; set; }


        [Persistent("current_version_number")]
        public string CurrentVersionString { get; set; }

        [Persistent("name")]
        [Size(100)]
        public string Name { get; set; }

        [Persistent("about")]
        [Size(1000)]
        public string About { get; set; }


        [Persistent("platform")]
        public EAppPlatform Platform { get; set; }

        [Persistent("link")]
        [Size(255)]
        public string Link { get; set; }

        [Persistent("base64_image")]
        [Size(3000)]
        public string Base64Image { get; set; }

        [Persistent("project_manager")]
        public ProjectAuth ProjectManager { get; set; }
    }
}
