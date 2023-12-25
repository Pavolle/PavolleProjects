import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {

    constructor(private auhtService : AuthService, private router: Router)
    {
        
    }
    canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const currentUrl = state.url; // Mevcut URL bilgisi
        if(!this.auhtService.isUserAuthenticate()){
            return this.router.parseUrl('/signin');
        }
        else if(this.auhtService.hasRole(currentUrl))
        {
            return true;
        }
        else{
            return true;
        }
    }
  
}
