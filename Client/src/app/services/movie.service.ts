import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from 'src/interfaces/Movie';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  url = 'https://localhost:7053/api';
  // url = 'https://api.randomuser.me/';
  constructor(private httpClient: HttpClient) {}

  public getAllMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(this.url);
  }
  public addMovie(name: string, year: number, body: any) {
    return this.httpClient.post(`${this.url}?name=${name}&year=${year}`, body);
  }
}
