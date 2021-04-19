import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { UserMusic } from '../models/userMusic';
import { UserGenre } from '../models/userGenre';
import { UserArtist } from '../models/userArtist';
import { AuthService } from './auth-service.service';
import { Music } from '../models/music';
import { Genre } from '../models/genre';
import { Artist } from '../models/artist';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {
  }

  ngOnInit() {
  }

  createUser(user: User): Observable<User> {
    return this.http.post<User>('/api/user/new', user);
  }

  getUser(email: string): Observable<User> {
    return this.http.get<User>('/api/user/' + email);
  }

  likeMusic(music: Music, uid: number): Observable<void> {
    var userMusic = new UserMusic;
    userMusic.musicId = music.musicId;
    userMusic.userUID = uid;
    return this.http.post<void>('/api/user/like/music', userMusic);
  }

  likeGenre(genre: Genre, uid: number): Observable<void> {
    var userGenre = new UserGenre;
    userGenre.genreID = genre.genreID;
    userGenre.userUID = uid;
    return this.http.post<void>('/api/user/like/genre', userGenre);
  }

  likeArtist(artist: Artist, uid: number): Observable<void> {
    var userArtist = new UserArtist;
    userArtist.artistID = artist.artistID;
    userArtist.userUID = uid;
    return this.http.post<void>('/api/user/like/artist', userArtist);
  }

  dislikeMusic(music: Music, uid: number) {
    var userMusic = new UserMusic;
    userMusic.musicId = music.musicId;
    userMusic.userUID = uid;
    return this.http.post<void>('/api/user/dislike/music', userMusic);
  }

  dislikeGenre(genre: Genre, uid: number): Observable<void> {
    var userGenre = new UserGenre;
    userGenre.genreID = genre.genreID;
    userGenre.userUID = uid;
    return this.http.post<void>('/api/user/dislike/genre', userGenre);
  }

  dislikeArtist(artist: Artist, uid: number): Observable<void> {
    var userArtist = new UserArtist;
    userArtist.artistID = artist.artistID;
    userArtist.userUID = uid;
    return this.http.post<void>('/api/user/dislike/artist', userArtist);
  }
}
