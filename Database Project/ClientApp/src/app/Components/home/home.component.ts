import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from '../../models/user';
import { AuthService } from '../../services/auth-service.service';
import { Router } from '@angular/router';
import { MusicService } from '../../services/music.service';
import { Music } from '../../models/music';
import { UserService } from '../../services/user-service.service';
import { ToastrService } from 'ngx-toastr';

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
    private musicService: MusicService,
    private userservice: UserService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.$authSubscription = this.authService.user$.subscribe(u => {
      this.currentUser = u;
    }
    );

    this.musicService.getAllMusic().subscribe(music => {
      this.elements = music;
    });
  }
  updateElement(element: Music) {
    this.userservice.likeMusic(element, this.currentUser.uid).subscribe(x => {
      this.toastr.success("Success!", "Music Liked!")
    })
  }
}
