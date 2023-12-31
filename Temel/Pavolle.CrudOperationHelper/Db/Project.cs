﻿using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Db
{
    [Persistent("projects")]
    public class Project : BaseObject
    {
        public Project(Session session) : base(session)
        {
        }

        [Persistent("name")]
        [Size(255)]
        public string Name { get; set; }

        [Persistent("organization_name")]
        [Size(255)]
        public string OrganizationName { get; set; }

        [Persistent("path")]
        [Size(255)]
        public string Path { get; set; }

        [Persistent("intitialize")]
        public bool Intialize { get; set; }

        [Persistent("issuer")]
        [Size(255)]
        public string Issuer { get; set; }

        [Persistent("audience")]
        [Size(255)]
        public string Audience { get; set; }

        [Persistent("languages")]
        public string Languages { get; set; }

        [Persistent("token_expire_minute")]
        public int TokenExpireMinute { get; set; }


    }
}
