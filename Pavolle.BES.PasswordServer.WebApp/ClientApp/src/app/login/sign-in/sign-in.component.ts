import { TranslateService } from './../../translate.service';
import { AlertifyService } from './../../alertify.service';
import { ELanguage } from 'src/app/viewmodels/enums/e-language.enum';
import { LoginRequest } from './../../viewmodels/request/login-request';
import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from 'src/main';
import { SignInResponse } from 'src/app/viewmodels/response/sign-in-response';
import { EMessageCode } from 'src/app/viewmodels/enums/e-message-code.enum';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {

  baseApiUrl: String =`${getBaseUrl()}api/passwordserver/login/`;
  kullaniciGirisiString:String;
  parolaString:String;
  kullaniciGirisiAciklamaString:String;
  kullaniciAdiString:String;
EMessageCode: any;
  constructor(@Inject(HttpClient)http: HttpClient, private httpClient: HttpClient,
  private router: Router,
  private authService: AuthService,
  private alertifyService: AlertifyService,
  private translateService: TranslateService){
    this.kullaniciGirisiAciklamaString=translateService.getMessage(EMessageCode.KullaniciGirisiAciklama);
    this.kullaniciGirisiString=translateService.getMessage(EMessageCode.KullaniciGirisi);
    this.parolaString=translateService.getMessage(EMessageCode.Parola);
    this.kullaniciAdiString=translateService.getMessage(EMessageCode.KullaniciAdi);
  }
  request: LoginRequest ={
    language:ELanguage.Turkish,
    username:"",
    password:""
  };


  login(){
    if(this.request.username==null || this.request.username.length==0){
      this.alertifyService.errorCenter(this.translateService.getMessage(EMessageCode.KullaniciAdiBosBirakilamaz));
      return;
    }
    if(this.request.username.length<5)
    {
      this.alertifyService.errorCenter(this.translateService.getMessage(EMessageCode.KullaniciAdiHatali));
      return;
    }
    if(this.request.password==null || this.request.password.length==0){
      this.alertifyService.errorCenter(this.translateService.getMessage(EMessageCode.ParolaAlaniBosBirakilamaz));
      return;
    }
    if(this.request.password.length<6){
      this.alertifyService.errorCenter(this.translateService.getMessage(EMessageCode.ParolaHatali));
      return;
    }
    const path = this.baseApiUrl +"signin";
	  let headers = new HttpHeaders();
	  headers = headers.append("Content-Type","application/json");
    this.httpClient.post<SignInResponse>(path, JSON.stringify(this.request),{headers: headers}).subscribe(result => {
       if(!result.success){
        this.alertifyService.errorCenter(result.errorMessage);
        console.log("Kullanıcı Adı veya Şifre hatalı!");
       }
       else{
        sessionStorage.setItem("token", result.token);
        this.authService.setIsAuthenticate(true);
        this.router.navigate([('/main')]);
        console.log("Kullanıcı Girişi Başarılı.");
       }
    }, error => console.error(error));
  }
}
