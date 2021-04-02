import { Component, OnInit, Input } from '@angular/core';
import { Music } from '../models/music';
import { MusicService } from '../services/music.service';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from '@angular/compiler/src/util';
import { GenreService } from '../services/genre.service';
import { ArtistService } from '../services/artist.service';
import { Genre } from '../models/genre';
import { Artist } from '../models/artist';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit {
  id: number;
  song: Music = new Music;
  adding: boolean;
  loading: boolean = false;
  genres: Array<Genre>;
  artists: Array<Artist>;

  constructor(private musicService: MusicService,
    private router: Router,
    private route: ActivatedRoute,
    private genreService: GenreService,
    private artistService: ArtistService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.id = parseInt(params.get('id'));
      console.log("id: ", this.id);
    });
    this.adding = this.id === -1;
    

    if (!this.adding)
      this.musicService.getById(this.id).subscribe(s => {
        this.song = s;
      });
    else
      this.song = new Music();

    this.genreService.getAll().subscribe(x => this.genres = x);
    this.artistService.getAll().subscribe(x => this.artists = x);
  }

  addOrUpdateSong() {
    this.loading = true;
    var subscription = this.adding ?
      this.musicService.addMusic(this.song) :
      this.musicService.updateMusic(this.song);
    console.log("song: ", this.song);
    subscription.subscribe(x => {
      this.loading = false;
      this.router.navigateByUrl('');
    },
    err => this.loading = false);
  }
}
