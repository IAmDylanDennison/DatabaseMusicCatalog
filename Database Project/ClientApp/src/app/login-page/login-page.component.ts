import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth-service.service';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  email: string;
  username: string;
  password: string;
  firstName: string;
  lastName: string;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  loginWithGoogle() {
    this.authService.doGoogleSignIn().then(_ => {
      this.router.navigate(['']);
    });
  }

  signUp() {
    let user = new User();
    user.email = this.email;
    user.username = this.username;
    user.lastName = this.lastName;
    user.firstName = this.firstName;
    
    this.authService.signUp(user, this.password);
    console.log("signed up");
  }

}
