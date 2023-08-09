import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserTransferStateModule } from '@angular/platform-browser';

import {DxButtonModule } from 'devextreme-angular';
import { FooterComponent } from './pages/include/footer/footer.component';
import { HeaderComponent } from './pages/include/header/header.component';
import { MenuComponent } from './pages/include/menu/menu.component';
@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    MenuComponent,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DxButtonModule,
    BrowserTransferStateModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
