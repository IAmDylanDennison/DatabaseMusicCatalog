import { Component, OnInit } from '@angular/core';
import { Genre } from '../../models/genre';
import { GenreService } from '../../services/genre.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  genres: Array<Genre>;

  constructor(private genreService: GenreService, private router: Router) { }

  ngOnInit() {
    this.genreService.getAll().subscribe(x =>
      this.genres = x
      );
  }

  updateElement(element: Genre) {
    this.router.navigateByUrl('genre/' + element.genreID);
  }
}
