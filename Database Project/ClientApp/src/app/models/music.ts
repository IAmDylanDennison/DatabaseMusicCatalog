import { Artist } from "./artist";
import { Genre } from "./genre";

export class Music {
  public musicId: number;
  public name: string;
  public yearReleased: string;
  public length: number;
  public artistID: number;
  public genreID: number;
  public artist: Artist;
  public genre: Genre;
}
