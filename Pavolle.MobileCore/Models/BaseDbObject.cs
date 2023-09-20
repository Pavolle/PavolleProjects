using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.MobileCore.Models
{
    public class BaseDbObject
    {
        [PrimaryKey]
        public long Oid { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool Deleted { get; set; }
    }
}
