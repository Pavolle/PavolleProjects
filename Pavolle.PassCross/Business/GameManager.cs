using Pavolle.Core.Enums;
using Pavolle.Core.Helper;
using Pavolle.Core.Utils;
using Pavolle.PassCross.Business.Seviyeler;
using Pavolle.PassCross.Enums;
using Pavolle.PassCross.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.PassCross.Business
{
    public class GameManager:Singleton<GameManager>
    {
        private GameManager()
        {

        }

        int _puan = 0;
        int _canSayisi = 3;
        ELevel _currentLevel = ELevel.Aday;
        int _geriSayimSuresiSaniye = 10;

        public void YeniOyunOlustur()
        {
            _puan = 0;
            _canSayisi = 3;
            _currentLevel= ELevel.Aday;
            _geriSayimSuresiSaniye = 10;
        }

        public void EskiOyunuYukle(int puan, int cansayisi, ELevel currentLevel)
        {
            _puan=puan;
            _canSayisi=cansayisi;   
            _currentLevel=currentLevel;
        }


        public Soru SeviyeIcinSoruOlustur(ELevel zorluk, ELanguage dil)
        {
            switch (zorluk)
            {
                case ELevel.Aday:
                    return Seviye2AdaySoruManager.Instance.SoruOlustur(dil);
                case ELevel.Acemi:
                    return AcemiIcinSoruOlustur(dil);
                case ELevel.Orta:
                    return OrtaIcinSoruOlustur(dil);
                case ELevel.Tecrubeli:
                    return TecrubeliIcinSoruOlustur(dil);
                case ELevel.Uzman:
                    return UzmanIcinSoruOlustur(dil);
                case ELevel.Virtuoz:
                    return VirtuozIcinSoruOlustur(dil);
                case ELevel.Ustat:
                    return UstatIcinSoruOlustur(dil);
                case ELevel.Efsanevi:
                    return EfsaneviIcinSoruOlustur(dil);
                case ELevel.UstunVarlik:
                    return UstunVarlikIcinSoruOlustur(dil);
                default:
                    return AcemiIcinSoruOlustur(dil);
            }
        }

        private Soru UstunVarlikIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru EfsaneviIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru UstatIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru VirtuozIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru UzmanIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru TecrubeliIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru OrtaIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        private Soru AcemiIcinSoruOlustur(ELanguage dil)
        {
            throw new NotImplementedException();
        }

        
    }
}
