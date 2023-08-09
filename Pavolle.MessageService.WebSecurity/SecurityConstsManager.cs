using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pavolle.MessageService.WebSecurity
{
    public class SecurityConstsManager : Singleton<SecurityConstsManager>
    {
        public const string SymmetricSecurityKeyString = "734df+5gdgaq@@&&www-3421-3-ff!dsfwwwdMilkoBilişimfb34g7ugfdsfvfv--34sdewwe3er34rwwefd34ffssd5ww4545zss";
        public const string Issuer = "milko_bilisim";
        public const string Audience = "milko_bilisim";

        private readonly string KullaniciAdiKey;
        private readonly string SesionIdKey;
        private readonly string KurumOidKey;
        private readonly string KullaniciTipiKey;
        private readonly string DilKey;
        private readonly SymmetricSecurityKey key;
        private readonly string RequestIpKey;

        private SecurityConstsManager()
        {
            KullaniciAdiKey = "KullaniciAdi";
            DilKey = "Dil";
            SesionIdKey = "SessionId";
            KullaniciTipiKey = "KullaniciTipi";
            KurumOidKey = "KurumOid";
            RequestIpKey = "RequestIP";
            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SymmetricSecurityKeyString)) { KeyId = "1000" };
        }

        public string GetRequestIp()
        {
            return RequestIpKey;
        }

        public string GetDilKey()
        {
            return DilKey;
        }

        public string GetKullaniciAdiKey()
        {
            return KullaniciAdiKey;
        }

        public string GetSesionIdKey()
        {
            return SesionIdKey;
        }

        public string GetSymmetricSecurityKeyString()
        {
            return SymmetricSecurityKeyString;
        }

        public SymmetricSecurityKey GetKey()
        {
            return key;
        }

        public string GetKurumOidKey()
        {
            return KurumOidKey;
        }

        public string GetKullaniciTipiKey()
        {
            return KullaniciTipiKey;
        }

        public string GetKeyString()
        {
            return SymmetricSecurityKeyString;
        }
    }
}
