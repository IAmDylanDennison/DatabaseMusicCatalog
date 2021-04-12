import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { AuthService } from '../../services/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  email: string;
  username: string;
  password: string;
  firstName: string;
  lastName: string;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }


  signUp() {
    let user = new User();
    user.email = this.email;
    user.username = this.username;
    user.lastName = this.lastName;
    user.firstName = this.firstName;

    this.authService.signUp(user, this.password);
    this.router.navigateByUrl('');
  }
}
