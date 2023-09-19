using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PDKS.Common.Enums
{
    public enum ECommandType
    {
        HELLO = 0x01, //Device Id => KEY =>Bizim ürettiğimiz cihaz mı? Bunun için de bir algoritma oluşturacağız
        ANSWER_TO_HELLO =0x02, //Kurulum yapılmış ve bu cihaza yetki verilmişse o zaman aktif yap. Token ver
       
        CHECK_UPDATE = 0x10,
        ANSWER_TO_UPDATE = 0x11,

        CHECK_IDENTITY= 0x20, //Identity Info //Token //Identity info type Cihaz kimlik doğrulama başlatırken kimlik doğrulama ile birlikte gelecekler
        ANSWER_TO_CHECK_IDENTITY=0x21,


        PING=0x30,
        ANSWER_TO_PING=0x31

    }
}
