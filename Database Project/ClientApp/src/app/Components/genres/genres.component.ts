import { Component, OnInit } from '@angular/core';
import { Genre } from '../../models/genre';
import { GenreService } from '../../services/genre.service';
import { Router } from '@angular/router';
import { UserService } from '../../services/user-service.service';
import { UserGenre } from '../../models/userGenre';
import { AuthService } from '../../services/auth-service.service';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {
  genres: Array<Genre>;

  constructor(private genreService: GenreService,
    private router: Router,
    private userService: UserService,
    private authService: AuthService) { }

  ngOnInit() {
    this.genreService.getAll().subscribe(x =>
      this.genres = x
      );
  }

  updateElement(element: Genre) {
    this.userService.likeGenre(element, this.authService.user$.value.uid).subscribe(x =>
      this.router.navigate([''])
      );
  }
}
