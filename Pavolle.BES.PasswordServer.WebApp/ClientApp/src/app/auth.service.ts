import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticate:boolean= false;
  constructor() { }

  setIsAuthenticate(status:boolean){
    this.isAuthenticate=status;
  }
  isUserAuthenticate(){
    return this.isAuthenticate;
  }
}
