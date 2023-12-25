import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { LoginModule } from './login/login.module';
import { PasswordManagerModule } from './password-manager/password-manager.module';

import { AppComponent } from './app.component';
import { SignInComponent } from './login/sign-in/sign-in.component';
import { ListPasswordComponent } from './password-manager/list-password/list-password.component';
import { HeaderComponent } from './include/header/header.component';
import { FooterComponent } from './include/footer/footer.component';
import { AuthService } from './auth.service';
import { AuthorizationGuard } from './authorization.guard';
import { NotFoundComponent } from './include/not-found/not-found.component';
import { NavMenuComponent } from './include/nav-menu/nav-menu.component';
import { SignOutComponent } from './login/sign-out/sign-out.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ListPasswordComponent, canActivate: [AuthorizationGuard] },
      { path: 'signin', component: SignInComponent},
      { path: 'signout', component: SignOutComponent, canActivate: [AuthorizationGuard] },
      { path: 'main', component: ListPasswordComponent, canActivate: [AuthorizationGuard] },
      { path: 'not-found', component: NotFoundComponent},
      { path: '**', redirectTo: '/not-found' } 
      //{ path: 'counter', component: CounterComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
