import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Genre } from '../models/genre';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Array<Genre>> {
    return this.http.get<Array<Genre>>('/api/genre');
  }

  get(id: number): Observable<Genre> {
    return this.http.get<Genre>('/api/genre/' + id);
  }

  update(genre: Genre): Observable<void> {
    return this.http.post<void>('/api/genre/update', genre);
  }

  add(genre: Genre): Observable<void> {
    return this.http.post<void>('/api/genre/add', genre);
  }
}
