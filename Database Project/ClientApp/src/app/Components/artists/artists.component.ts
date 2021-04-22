import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../../services/artist.service';
import { Artist } from '../../models/artist';
import { Router } from '@angular/router';
import { UserService } from '../../services/user-service.service';
import { AuthService } from '../../services/auth-service.service';
import { UserArtist } from '../../models/userArtist';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {
  artists: Array<Artist>;

  constructor(private artistService: ArtistService,
    private router: Router,
    private userService: UserService,
    private auth: AuthService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.artistService.getAll().subscribe(x => {
      this.artists = x;
    })
  }

  updateElement(element: Artist) {
    this.userService.likeArtist(element, this.auth.user$.value.uid).subscribe(x =>
      this.toastr.success("Success", "Artist Liked!")
    );
  }
}
