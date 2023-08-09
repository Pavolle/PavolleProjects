using Microsoft.IdentityModel.Tokens;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pavolle.MessageService.WebSecurity
{
    public class JwtTokenManager:Singleton<JwtTokenManager>
    {
        private JwtTokenManager() { }


        public string TokenOlustur(string kullaniciAdi, string sessionId, string kurumOid, string kullaniciTipi, string dil, string requestIp)
        {
            var subject = new ClaimsIdentity(new[]
            {
                new Claim(SecurityConstsManager.Instance.GetKullaniciAdiKey(), kullaniciAdi),
                new Claim(SecurityConstsManager.Instance.GetSesionIdKey(), sessionId),
                new Claim(SecurityConstsManager.Instance.GetKurumOidKey(), kurumOid),
                new Claim(SecurityConstsManager.Instance.GetKullaniciTipiKey(), kullaniciTipi),
                new Claim(SecurityConstsManager.Instance.GetDilKey(), dil),
                new Claim(SecurityConstsManager.Instance.GetRequestIp(), requestIp)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = SecurityConstsManager.Issuer,
                Audience = SecurityConstsManager.Audience,
                SigningCredentials = new SigningCredentials(SecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;


            //var claimsdata = new List<Claim>();
            //claimsdata.Add(new Claim(SecurityConstsManager.Instance.GetKullaniciAdiKey(), kullaniciAdi));
            //claimsdata.Add(new Claim(SecurityConstsManager.Instance.GetSesionIdKey(), sessionId));
            //claimsdata.Add(new Claim(SecurityConstsManager.Instance.GetKurumOidKey(), kurumOid));
            //claimsdata.Add(new Claim(SecurityConstsManager.Instance.GetKullaniciTipiKey(), kullaniciTipi));
            //claimsdata.Add(new Claim(SecurityConstsManager.Instance.GetKullaniciGrubuOidKey(), kullaniciGrubuOid));
            //claimsdata.Add(new Claim(SecurityConstsManager.Instance.GetDilKey(), dil));

            //var signInCred = new SigningCredentials(SecurityConstsManager.Instance.GetKey(), SecurityAlgorithms.HmacSha512);

            //var tokenBase = new JwtSecurityToken(issuer: "milko_bilisim", audience: "milko_bilisim",
            //    claims: claimsdata, notBefore: DateTime.Now,
            //    expires: DateTime.Now.AddDays(10), signingCredentials: signInCred);
            //token = new JwtSecurityTokenHandler().WriteToken(tokenBase);

            //return token;
        }
    }
}
