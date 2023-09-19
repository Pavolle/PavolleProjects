using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.ESecim.Common.Enums
{
    public enum EKullaniciTipi
    {
        SistemYoneticisi=1,
        KurulumEkibi=2, //Bu bir seçim için cihaz id tanımlayacak.
        FirmaYoneticisi, //Herşeyi yapabilir
        FirmaCalisani, //Seçim oluşturabilir // Seçime katılım oranlarını görüntüleyebilir.
        FirmaIzleyici //Sadece seçim sonuçlarını görüntüleyebilir.
    }
}
