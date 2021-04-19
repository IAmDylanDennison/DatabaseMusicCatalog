import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './Components/home/home.component';
import { CounterComponent } from './Components/counter/counter.component';
import { FetchDataComponent } from './Components/fetch-data/fetch-data.component';
import { LoginPageComponent } from './Components/login-page/login-page.component';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { AngularFireModule } from '@angular/fire';
import { environment } from '../environments/environment';
import { AuthInterceptor } from './security/auth-interceptor';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { TableComponent } from './Components/table/table.component';
import { SongComponent } from './Components/song/song.component';
import { ArtistsComponent } from './Components/artists/artists.component';
import { GenresComponent } from './Components/genres/genres.component';
import { IndividualArtistComponent } from './Components/individual-artist/individual-artist.component';
import { IndividualGenreComponent } from './Components/individual-genre/individual-genre.component';
import { UserLikePageComponent } from './Components/user-like-page/user-like-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginPageComponent,
    SignUpComponent,
    TableComponent,
    SongComponent,
    ArtistsComponent,
    GenresComponent,
    IndividualArtistComponent,
    IndividualGenreComponent,
    UserLikePageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginPageComponent },
      { path: 'signup', component: SignUpComponent },
      { path: 'song/:id', component: SongComponent },
      { path: 'artists', component: ArtistsComponent },
      { path: 'artist/:id', component: IndividualArtistComponent },
      { path: 'genres', component: GenresComponent },
      { path: 'genre/:id', component: IndividualGenreComponent },
      { path: 'likes', component: UserLikePageComponent }
    ]),
    AngularFireAuthModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    NgxPaginationModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
