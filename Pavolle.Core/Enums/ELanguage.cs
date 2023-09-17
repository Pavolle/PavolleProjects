using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Core.Enums
{
    public enum ELanguage
    {
        [Description("en")]
        English,

        [Description("de")]
        German,

        [Description("es")]
        Spanish,

        [Description("fr")]
        French,

        [Description("ru")]
        Russian,

        [Description("tr")]
        Turkish=1,

        [Description("az")]
        Azerbaijani,
    }
}
