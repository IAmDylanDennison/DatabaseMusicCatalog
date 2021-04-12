import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service.service';
import { Router } from '@angular/router';
import { HomeComponent } from '../home/home.component';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  email: string;
  password: string;

  loading: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  // this does not work
  // error 400 invalid scope
  loginWithGoogle() { 
    this.authService.doGoogleSignIn().then(_ => {
      this.router.navigate(['']);
    });
  }

  login() {
    this.loading = true;
    this.authService.signIn(this.email, this.password).then(user => {
      this.loading = false;
      this.router.navigate(['']);
    })
  }
}
