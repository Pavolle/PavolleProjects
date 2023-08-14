using Pavolle.Core.Enums;
using Pavolle.PassCross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business.Seviyeler
{
    public interface ISoruManager
    {
        Soru SoruOlustur(ELanguage dil);
    }
}
