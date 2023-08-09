using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.Common.Enums
{
    public enum ESecureChannelCommand
    {
        HELLO=0x01, //Burada cihaz kendi idsini ve yazılım versiyonunu  ve keyini gönderecek.
        ANSWER_TO_HELLO=0X02, //Bu cihazla seçim yapılabilirlik kontrol edilecek.
        WAIT_FOR_UPDATE_DEVICE_SOFTWARE=0X03, //Bunu sunucu gönderecek.
        UPDATE_DEVICE_SOFTWARE =0x04, //Bu cihaza yeni yazılımı gönderecek. Uygulama kendini yeniden başlatacak.
        SEND_KEC_STATUS_TO_DEVICE=0x05, //string açiklama ve bool seçim için hazır komutları gönderilecek. Status kod gönderilecek, yazılım bunu anlamlandıracak //Örnek kart takıldı, Kart çıkartıldı, kimlik doğrulama başarılı, kişisel mesaj onayı, parmak izi seçimi tarzında


    }
}
