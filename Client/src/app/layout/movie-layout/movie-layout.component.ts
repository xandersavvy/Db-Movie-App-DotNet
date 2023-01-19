import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { Movie } from 'src/interfaces/Movie';

@Component({
  selector: 'app-movie-layout',
  template: `
    <div *ngIf="!loading; else Loading">
      <app-single-movie
        *ngFor="let movie of movies"
        [movie]="movie"
      ></app-single-movie>
    </div>

    <ng-template #Loading><p>Loading....</p></ng-template>
  `,
  styleUrls: ['./movie-layout.component.css'],
})
export class MovieLayoutComponent implements OnInit {
  movies: Movie[] = [];
  loading = true;
  constructor(private _movieService: MovieService) {}

  ngOnInit(): void {
    this._movieService.getAllMovies().subscribe((data) => {
      this.movies = data;
      this.loading = false;
    });
  }
}
