import { Component, OnInit } from '@angular/core';
import { Genre } from '../../models/genre';
import { GenreService } from '../../services/genre.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-individual-genre',
  templateUrl: './individual-genre.component.html',
  styleUrls: ['./individual-genre.component.css']
})
export class IndividualGenreComponent implements OnInit {
  id: number;
  genre: Genre;
  adding: boolean;
  loading: boolean = false;


  constructor(private genreService: GenreService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params =>
      this.id = parseInt(params.get('id'))
    );

    this.adding = this.id === -1;
    if (!this.adding)
      this.genreService.get(this.id).subscribe(x =>
        this.genre = x
      );
    else
      this.genre = new Genre();
  }


  addOrUpdateGenre() {
    this.loading = true;
    var subscription = this.adding ?
      this.genreService.add(this.genre) :
      this.genreService.update(this.genre);

    subscription.subscribe(x => {
      this.loading = false;
      this.router.navigateByUrl('genres');
    },
    err => this.loading = false)
  }
}
