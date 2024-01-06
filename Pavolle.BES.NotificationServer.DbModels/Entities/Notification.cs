﻿using DevExpress.Xpo;
using Pavolle.BES.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.NotificationServer.DbModels.Entities
{
    [Persistent("notifications")]
    public class Notification : BaseObject
    {
        public Notification(Session session) : base(session)
        {
        }

    }
}
