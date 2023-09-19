using Pavolle.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.Multilanguage
{
    public class LanguageViewData
    {
        public ELanguage DilKodu { get; set; }
        public EYaziYonu YaziYonu { get; set; }
        public string Aciklama { get; set; }
    }
}
