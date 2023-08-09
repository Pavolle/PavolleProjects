using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.ViewModels.ViewData
{
    public class LookupViewData
    {
        public long Key { get; set; }
        public string Value { get; set; }
        public bool IsDefault { get; set; }
    }
}
