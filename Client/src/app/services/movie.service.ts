import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from 'src/interfaces/Movie';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private url = 'https://localhost:7053/';
  // url = 'https://api.randomuser.me/';
  constructor(private httpClient: HttpClient) {}

  public getAllMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(this.url);
  }
  public addMovie(name: string, year: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };
    return this.httpClient.post(
      `${this.url}?name=${name}&year=${year}`,
      { name, year },
      httpOptions
    );
  }
  public deleteMovie(id: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };
    return this.httpClient.delete(`${this.url}/${id}`, httpOptions);
  }
}
