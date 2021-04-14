import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Artist } from '../models/artist';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<Array<Artist>> {
    return this.http.get<Array<Artist>>('/api/artist');
  }

  getById(id: number): Observable<Artist> {
    return this.http.get<Artist>('/api/artist/artist/' + id)
  }

  addArtist(artist: Artist): Observable<void> {
    return this.http.post<void>('/api/artist', artist);
  }

  updateArtist(artist: Artist): Observable<void> {
    return this.http.post<void>('/api/artist/update', artist);
  }

  deleteArtist(artist: Artist): Observable<void> {
    return this.http.post<void>('/api/artist/delete', artist);
  }
}
