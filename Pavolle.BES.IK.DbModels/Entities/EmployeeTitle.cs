﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.DbModels.Entities
{
    //todo her departman tanımlamasında aynı zamanda bir kullanıcının bu departmanın yöneticisi olacak tanımlamamız lazım.
    //İzin Yönetimi için izin talebinde departman yöneticisinin onayı önemli olacak.
    [Persistent("employee_titles")]
    public class EmployeeTitle : BaseObject
    {
        public EmployeeTitle(Session session) : base(session)
        {
        }

        [Persistent("employee_oid")]
        public Employee Employee { get; set; }

        [Persistent("title_oid")]
        public Title Title { get; set; }

        [Persistent("manager")]
        public bool Manager { get; set; }

        [Persistent("start_date")]
        public DateTime StartDate { get; set; }

        [Persistent("end_date")]
        public DateTime? EndDate { get; set; }

        [Persistent("end_reason")]
        public string EndReason { get; set; }

        [Persistent("is_active")]
        public bool Active { get; set; }
    }
}
