import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticate:boolean= false;
  constructor() { }

  isUserAuthenticate(){
    return this.isAuthenticate;
  }
}
