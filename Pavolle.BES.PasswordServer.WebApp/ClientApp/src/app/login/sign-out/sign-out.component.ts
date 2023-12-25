import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-sign-out',
  templateUrl: './sign-out.component.html',
  styleUrls: ['./sign-out.component.css']
})
export class SignOutComponent implements OnInit {


  constructor(private router: Router, private auhtService:AuthService) { }

  ngOnInit() {
  }

  logout(): void  {
    console.log("logout");
        this.auhtService.logout();
        this.router.navigate([('/signin')]);
    
    }
    gotoMainPage(): void  {
        console.log("logout cancel");
        this.router.navigate([('/main')]);
    
    }

}
