using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pavolle.MobileCore.Models;

namespace Pavolle.PassCross.Models
{
    public class PlayGameLogDbModel : BaseDbObject
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MyProperty { get; set; }
    }
}
