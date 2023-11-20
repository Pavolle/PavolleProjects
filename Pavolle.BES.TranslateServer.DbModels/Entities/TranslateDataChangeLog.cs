using DevExpress.Xpo;
using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.TranslateServer.DbModels.Entities
{
    [Persistent("translate_data_change_logs")]
    public class TranslateDataChangeLog : BaseObject
    {
        public TranslateDataChangeLog(Session session) : base(session)
        {
        }

        [Persistent("translate_data_oid")]
        public TranslateData TranslateData { get; set; }

        [Persistent("changed_language")]
        public ELanguage ChangedLanguage { get; set; }

        [Persistent("old_data")]
        public string OldData { get; set; }

        [Persistent("new_data")]
        public string NewData { get; set; }
    }
}
