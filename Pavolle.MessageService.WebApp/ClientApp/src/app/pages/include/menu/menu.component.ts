import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor() { }
  isShowYonetim = true;
  isShowUygulamaYonetim = true;
  isShowUygulamaRaporlar = true;
  ngOnInit() {
  }
  toggleDisplayYonetim() {
    this.isShowYonetim = !this.isShowYonetim;
    this.isShowUygulamaYonetim=true;
    this.isShowUygulamaRaporlar=true;
  }
  toggleDisplayUygulamaYonetim() {
    this.isShowYonetim=true;
    this.isShowUygulamaYonetim = !this.isShowUygulamaYonetim;
    this.isShowUygulamaRaporlar=true;
  }
  toggleDisplayUygulamaRaporlar() {
    this.isShowYonetim=true;
    this.isShowUygulamaYonetim=true;
    this.isShowUygulamaRaporlar = !this.isShowUygulamaRaporlar;
  }

}
