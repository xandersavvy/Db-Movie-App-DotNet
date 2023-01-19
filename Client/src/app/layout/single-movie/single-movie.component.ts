import { Component, Input, OnInit } from '@angular/core';
import { catchError, EMPTY } from 'rxjs';
import { MovieService } from 'src/app/services/movie.service';
import { Movie } from '../../../interfaces/Movie';

@Component({
  selector: 'app-single-movie',
  template: `
    <div class="card">
      <h4>{{ movie.name }}</h4>
      <small> {{ movie.year }} </small>
      <div class="button-gr">
        <button
          class="btn btn-lg btn-outline-danger p-danger "
          (click)="delete(movie.id)"
        >
          🗑
        </button>
      </div>
    </div>
  `,
  styleUrls: ['./single-movie.component.css'],
})
export class SingleMovieComponent implements OnInit {
  constructor(private _movieService: MovieService) {}

  ngOnInit(): void {}
  @Input() movie!: Movie;
  delete(id: any) {
    this._movieService
      .deleteMovie(id)
      .pipe(
        catchError((error) => {
          console.error(error);
          return EMPTY;
        })
      )
      .subscribe((data) => data);
    window.location.reload();
  }
}
