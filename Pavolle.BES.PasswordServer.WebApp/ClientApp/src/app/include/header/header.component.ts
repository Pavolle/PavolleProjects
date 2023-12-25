import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth.service';
import { SingInUserDetailViewData } from 'src/app/viewmodels/viewdata/sign-in-user-detail-view-data';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

    currentUser : SingInUserDetailViewData | undefined | null;
  constructor(private authServie:AuthService) {
    this.currentUser = authServie.getUserInfo();
   }

  ngOnInit() {
  }

  menuOpen = false;

  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }

  logout(){
    
  }
}
