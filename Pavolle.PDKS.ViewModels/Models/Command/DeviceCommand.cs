using Pavolle.PDKS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.ViewModels.Models.Command
{
    public class DeviceCommand
    {
        public ECommandType CommandCode { get; set; }
        public long DeviceId { get; set; }
        public string JsonProperty { get; set; }
    }


    /*Komut yapısı
     * 109099 | komut uzunluğu => 8 rakamlı integer | komut kodu | device id: 8 rakamlı integer | komut icerigi | 990901
    */
}
