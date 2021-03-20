import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  createUser(user: User): Observable<void> {
    return this.http.post<void>('/api/user/new', user);
  }

  getUser(email: string): Observable<User> {
    return this.http.get<User>('/api/user/' + email);
  }
}
