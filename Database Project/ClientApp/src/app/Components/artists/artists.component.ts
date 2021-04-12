import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../../services/artist.service';
import { Artist } from '../../models/artist';
import { Router } from '@angular/router';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {
  artists: Array<Artist>;

  constructor(private artistService: ArtistService, private router: Router) { }

  ngOnInit() {
    this.artistService.getAll().subscribe(x => {
      this.artists = x;
    })
  }

  updateElement(element: Artist) {
    this.router.navigateByUrl('artist/' + element.artistID);
  }

}
