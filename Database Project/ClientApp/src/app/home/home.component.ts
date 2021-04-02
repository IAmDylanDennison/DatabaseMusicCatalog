import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../models/user';
import { AuthService } from '../services/auth-service.service';
import { Router } from '@angular/router';
import { MusicService } from '../services/music.service';
import { Music } from '../models/music';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  currentUser = new User();
  $authSubscription: Subscription;

  elements: Array<Music>;

  constructor(private authService: AuthService,
    private router: Router,
    private musicService: MusicService) {}

  ngOnInit() {
    this.$authSubscription = this.authService.user$.subscribe(u => {
      this.currentUser = u;
      console.log("current user: ", this.currentUser);
    }
    );

    this.musicService.getAllMusic().subscribe(music => {
      console.log("elements: ", music);
      this.elements = music;
    });
  }

  addMusic(music: Music) {
    this.router.navigateByUrl('song/' + music.musicId);
  }
}
