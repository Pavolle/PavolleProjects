using Pavolle.PassCross.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Models
{
    public class Soru
    {
        public ELevel Zorluk { get; set; }
        public string Parola { get; set; }
        public List<Ipucu> IpucuListesi { get; set; }
    }
}
