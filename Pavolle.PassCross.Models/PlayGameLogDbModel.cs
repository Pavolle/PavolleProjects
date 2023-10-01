using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pavolle.MobileCore.Models;
using Pavolle.PassCross.Common.Enums;

namespace Pavolle.PassCross.Models
{
    public class PlayGameLogDbModel : BaseDbObject
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public EGameLevel Level { get; set; }
    }
}
