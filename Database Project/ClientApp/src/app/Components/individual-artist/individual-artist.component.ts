import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../../services/artist.service';
import { Router, ActivatedRoute } from '@angular/router';
import { GenreService } from '../../services/genre.service';
import { Artist } from '../../models/artist';
import { Genre } from '../../models/genre';

@Component({
  selector: 'app-individual-artist',
  templateUrl: './individual-artist.component.html',
  styleUrls: ['./individual-artist.component.css']
})
export class IndividualArtistComponent implements OnInit {
  id: number;
  artist: Artist = new Artist;
  adding: boolean;
  loading: boolean = false;
  genres: Array<Genre>;

  constructor(private artistService: ArtistService,
    private router: Router,
    private route: ActivatedRoute,
    private genreService: GenreService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.id = parseInt(params.get('id'));
    })
    this.adding = this.id === -1;

    if (!this.adding)
      this.artistService.getById(this.id).subscribe(a => {
        this.artist = a;
      }
      );
    else
      this.artist = new Artist();

    this.genreService.getAll().subscribe(x => this.genres = x);
  }

  addOrUpdateArtist() {
    this.loading = true;
    var subscription = this.adding ?
      this.artistService.addArtist(this.artist) :
      this.artistService.updateArtist(this.artist);
    subscription.subscribe(x => {
      this.loading = false;
      this.router.navigateByUrl('artists');
    },
    err => this.loading = false)
  }

  delete() {
    this.artistService.deleteArtist(this.artist).subscribe(x => this.router.navigateByUrl('artists'));
  }
}
