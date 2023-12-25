import { SignInResponse } from 'src/app/viewmodels/response/sign-in-response';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  logout() {
    localStorage.clear();
    this.setAuthenticateStatus();
  }
  hasRole(currentUrl: string) {
    if(currentUrl="/signout" || currentUrl == "/main"){
        return true;
    }
    else{
        return false;
    }
  }
  isAuthenticate:boolean= false;
  signInResponse:SignInResponse | undefined;

  constructor() {
    this.setAuthenticateStatus();
   }

  setAuthenticateStatus(){
    const userString = localStorage.getItem('currentUser');
    this.signInResponse = userString ? JSON.parse(userString) : null;
    if(this.signInResponse!=null){
        this.isAuthenticate=true;
    }
    else{
        this.isAuthenticate=false;
    }
  }
  isUserAuthenticate(){
    return this.isAuthenticate;
  }

  getUserInfo(){
    if(this.isAuthenticate){
        return this.signInResponse?.userDetail;
    }
    return null;
  }
}
