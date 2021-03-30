import { Component, OnInit, Input } from '@angular/core';
import { Music } from '../models/music';
import { MusicService } from '../services/music.service';
import { Router } from '@angular/router';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit {
  @Input() song: Music;
  adding: boolean;
  loading: boolean = false;

  constructor(private musicService: MusicService, private router: Router ) { }

  ngOnInit() {
    this.adding = this.song == null;
  }

  addOrUpdateSong() {
    this.loading = true;
    var subscription = this.adding ?
      this.musicService.addMusic(this.song) :
      this.musicService.updateMusic(this.song);

    subscription.subscribe(x => {
      this.loading = false;
      this.router.navigateByUrl('');
    });
  }
}
