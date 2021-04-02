import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Music } from '../models/music';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MusicService {

  constructor(private http: HttpClient) { }

  addMusic(music: Music): Observable<void> {
    return this.http.post<void>('/api/music/add', music);
  }

  updateMusic(music: Music): Observable<void> {
    return this.http.post<void>('/api/music/update', music);
  }

  getAllMusic(): Observable<Array<Music>> {
    return this.http.get<Array<Music>>('/api/music');
  }

  getById(id: number): Observable<Music> {
    return this.http.get<Music>('/api/music/song/' + id);
  }
}
