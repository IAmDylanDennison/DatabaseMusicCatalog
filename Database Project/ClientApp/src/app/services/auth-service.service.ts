import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AngularFireAuth } from '@angular/fire/auth';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import * as firebase from 'firebase';
import { UserService } from './user-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user$: BehaviorSubject<User> = new BehaviorSubject<User>(new User());

  constructor(private angularAuth: AngularFireAuth,
    private httpclient: HttpClient,
    private userService: UserService) {
    this.angularAuth.authState.subscribe((firebaseUser) => {
      this.configureAuthState(firebaseUser);
    });
  }


  configureAuthState(firebaseUser: firebase.default.User) {
    if (firebaseUser) {
      firebaseUser.getIdToken().then(theToken => { // get the user from firebase, then from the database
        if (theToken)
          localStorage.setItem("jwt", theToken);

        this.userService.getUser(firebaseUser.email).subscribe(user => {
          this.user$.next(user);
        },
          error => {
            // only happens if there is not a user.
            if (theToken) {
              var newUser: User = new User();
              newUser.email = firebaseUser.email;
              this.userService.createUser(newUser)
                .subscribe(user => this.user$.next(user));
            }
          })
      }, failReason => {
        this.doSignedOutUser();
      })
    }
    else {
      this.doSignedOutUser();
    }
  }

  private doSignedOutUser() {
    let theUser = new User();
    localStorage.removeItem("jwt");
    this.user$.next(theUser);
  }

  logout(): Promise<void> {
    return this.angularAuth.signOut();
  }

  getUserObservable(): Observable<User> {
    return this.user$.asObservable();
  }

  getToken(): string {
    return localStorage.getItem("jwt");
  }

  doGoogleSignIn(): Promise<void> {
    var googleProvider = new firebase.default.auth.GoogleAuthProvider();
    googleProvider.addScope('email');
    googleProvider.addScope('password');
    return this.angularAuth.signInWithPopup(googleProvider).then(auth => { });
  }

  signUp(user: User, password: string): boolean {
    this.angularAuth.createUserWithEmailAndPassword(user.email, password).then(
      signedInUser => {
        this.userService.createUser(user).subscribe(res => {
          console.log("should be created");
          return true;
        },
        error => {
          signedInUser.user.delete();
          this.doSignedOutUser();
          return false;
        })
      }
    )

    return false;
  }
}
