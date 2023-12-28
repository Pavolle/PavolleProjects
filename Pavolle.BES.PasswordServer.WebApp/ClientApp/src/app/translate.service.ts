import { Injectable } from '@angular/core';
import { EMessageCode } from './viewmodels/enums/e-message-code.enum';
import { ELanguage } from './viewmodels/enums/e-language.enum';

@Injectable({
  providedIn: 'root'
})
export class TranslateService {

currentLanguage: ELanguage ;
constructor() {
  this.currentLanguage=ELanguage.Turkish;
}

getMessage(messageCode:EMessageCode){
  if(this.currentLanguage==ELanguage.Turkish){
    switch(messageCode){
      case EMessageCode.KullaniciAdiBosBirakilamaz: return "Kullanıcı Adı boş bırakılamaz!";
      case EMessageCode.KullaniciAdiHatali: return "Kullanıcı Adı Hatalı!";
      case EMessageCode.ParolaAlaniBosBirakilamaz: return "Parola Boş Bırakılamaz!";
      case EMessageCode.ParolaHatali: return "Parola Hatalı!";
      case EMessageCode.KullaniciGirisiAciklama: return "Kullanıcı Girişi!";
      case EMessageCode.KullaniciAdi: return "Kullanıcı Adı";
      case EMessageCode.Parola: return "Parola";
      case EMessageCode.KullaniciGirisi: return "Giriş";
      case EMessageCode.MenuAnasayfa: return "Anasayfa";
      case EMessageCode.MenuYonetim: return "Yönetim";
      case EMessageCode.MenuKullaniciGruplari: return "Kullanıcı Grupları";
      case EMessageCode.MenuKullanicilar: return "Kullanıcılar";
      case EMessageCode.MenuYetkiler: return "Yetkiler";
      case EMessageCode.MenuSifreKategorileri: return "Şifre Kategorileri";
      case EMessageCode.MenuCikis: return "Çıkış";
      case EMessageCode.SagUstAcilirMenuBilgilerim: return "Bilgilerim";
      case EMessageCode.SagUstAcilirMenuSifreDegistirme: return "Şifre Değiştirme";
      case EMessageCode.SagUstAcilirMenuCikis: return "Çıkış";
    }
  }
  if(this.currentLanguage==ELanguage.English){
    switch(messageCode){
      case EMessageCode.KullaniciAdiBosBirakilamaz: return "Username is blank!";
      case EMessageCode.KullaniciAdiHatali: return "Username is wrong!";
      case EMessageCode.ParolaAlaniBosBirakilamaz: return "Password is blank!";
      case EMessageCode.ParolaHatali: return "Password is wrong!";
      case EMessageCode.KullaniciGirisiAciklama: return "Login";
      case EMessageCode.KullaniciAdi: return "Username";
      case EMessageCode.Parola: return "Password";
      case EMessageCode.KullaniciGirisi: return "Sing In";
      case EMessageCode.MenuAnasayfa: return "Home";
      case EMessageCode.MenuYonetim: return "Managment";
      case EMessageCode.MenuKullaniciGruplari: return "User Groups";
      case EMessageCode.MenuKullanicilar: return "Users";
      case EMessageCode.MenuYetkiler: return "Authorizations";
      case EMessageCode.MenuSifreKategorileri: return "Password Category";
      case EMessageCode.MenuCikis: return "Sign Out";
      case EMessageCode.SagUstAcilirMenuBilgilerim: return "My Information";
      case EMessageCode.SagUstAcilirMenuSifreDegistirme: return "Change Password";
      case EMessageCode.SagUstAcilirMenuCikis: return "Sign Out";
    }
  }
  return "";
}

}
