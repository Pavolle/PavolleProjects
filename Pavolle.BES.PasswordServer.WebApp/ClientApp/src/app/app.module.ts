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

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: SignInComponent, pathMatch: 'full' },
      { path: 'signin', component: SignInComponent, pathMatch: 'full' },
      { path: 'main', component: ListPasswordComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
