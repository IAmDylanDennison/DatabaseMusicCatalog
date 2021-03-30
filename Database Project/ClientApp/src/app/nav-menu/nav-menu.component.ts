import { Component } from '@angular/core';
import { AuthService } from '../services/auth-service.service';
import { User } from '../models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  loadingLogout: boolean = false;

  constructor(private authService: AuthService) { }

  signedInUser: User;

  ngOnInit() {
    this.authService.user$.subscribe(user => this.signedInUser = user);
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.loadingLogout = true;
    this.authService.logout().then(x => this.loadingLogout = false);
  }
}
