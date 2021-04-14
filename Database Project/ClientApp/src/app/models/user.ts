import { UserMusic } from "./userMusic";
import { UserArtist } from "./userArtist";
import { UserGenre } from "./userGenre";

export class User {
  public uid: number;
  public firstName: string;
  public lastName: string;
  public email: string;
  public username: string;
  public bio: string;
  public userMusic: Array<UserMusic>;
  public userArtists: Array<UserArtist>;
  public userGenres: Array<UserGenre>;
}
