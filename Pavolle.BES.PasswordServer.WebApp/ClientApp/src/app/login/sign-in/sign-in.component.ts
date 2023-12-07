import { AlertifyService } from './../../alertify.service';
import { ELanguage } from 'src/app/viewmodels/enums/e-language.enum';
import { LoginRequest } from './../../viewmodels/request/login-request';
import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from 'src/main';
import { SignInResponse } from 'src/app/viewmodels/response/sign-in-response';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {

  constructor(@Inject(HttpClient)http: HttpClient, private httpClient: HttpClient, private alertifyService: AlertifyService){

  }
  request: LoginRequest ={
    language:ELanguage.Turkish,
    username:"",
    password:""
  };
  baseApiUrl: String =`${getBaseUrl()}api/passwordserver/login/`;

  login(){
    const path = this.baseApiUrl +"signin";
	  let headers = new HttpHeaders();
	  headers = headers.append("Content-Type","application/json");
    this.httpClient.post<SignInResponse>(path, JSON.stringify(this.request),{headers: headers}).subscribe(result => {
       if(!result.success){
        this.alertifyService.errorCenter(result.errorMessage);
       }
       else{

       }
    }, error => console.error(error));
  }
}
