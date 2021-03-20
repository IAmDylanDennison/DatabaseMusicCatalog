import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../models/user';
import { AuthService } from '../services/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  currentUser = new User();
  $authSubscription: Subscription;

  constructor(private authService: AuthService, private router: Router) {
    this.$authSubscription = this.authService.user$.subscribe(u =>
      this.currentUser = u
      );
  }


}
