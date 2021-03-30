import { Artist } from "./artist";
import { Genre } from "./genre";

export class Music {
  public musicId: number;
  public name: string;
  public yearReleased: string;
  public length: number;
  public artist: Artist;
  public genreId: number;
  public genre: Genre;
}
