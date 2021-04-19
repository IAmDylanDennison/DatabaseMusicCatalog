import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service.service';
import { UserMusic } from '../../models/userMusic';
import { UserGenre } from '../../models/userGenre';
import { UserArtist } from '../../models/userArtist';
import { Music } from '../../models/music';
import { Genre } from '../../models/genre';
import { Artist } from '../../models/artist';
import { UserService } from '../../services/user-service.service';
import { User } from '../../models/user';

@Component({
  selector: 'app-user-like-page',
  templateUrl: './user-like-page.component.html',
  styleUrls: ['./user-like-page.component.css']
})
export class UserLikePageComponent implements OnInit {
  userMusic: Array<Music>;
  userGenre: Array<Genre>;
  userArtists: Array<Artist>;

  currentUser: User;

  constructor(private auth: AuthService,
              private userService: UserService) { }

  ngOnInit() {
    this.auth.refreshUser();
    this.refreshUser();
  }

  refreshUser() {
    this.auth.refreshUser();
    this.auth.user$.subscribe(user => {
      if (user) {
        if (user.userMusic && user.userMusic.length > 0)
          this.userMusic = user.userMusic.map(x => x.music);
        if (user.userGenres && user.userGenres.length > 0)
          this.userGenre = user.userGenres.map(x => x.genre);
        if (user.userArtists && user.userArtists.length > 0)
          this.userArtists = user.userArtists.map(x => x.artist);

        this.currentUser = user;
      }
    })
  }

  deleteMusic(song: Music) {
    this.userService.dislikeMusic(song, this.auth.user$.value.uid).subscribe(x => {
      this.refreshUser();
    });
  }

  deleteArtist(artist: Artist) {
    this.userService.dislikeArtist(artist, this.auth.user$.value.uid).subscribe(x => {
      this.refreshUser();
    })
  }

  deleteGenre(genre: Genre) {
    this.userService.dislikeGenre(genre, this.auth.user$.value.uid).subscribe(x => {
      this.refreshUser();
    })
  }
}
