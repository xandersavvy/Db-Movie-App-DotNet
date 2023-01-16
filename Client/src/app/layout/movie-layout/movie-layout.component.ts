import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/interfaces/Movie';

@Component({
  selector: 'app-movie-layout',
  template: ` <div>
    <app-single-movie
      *ngFor="let movie of movies"
      [movie]="movie"
    ></app-single-movie>
  </div>`,
  styleUrls: ['./movie-layout.component.css'],
})
export class MovieLayoutComponent implements OnInit {
  movies: Movie[] = [
    {
      id: 1,
      name: 'RRR',
      year: 2018,
    },
    {
      id: 1,
      name: 'RRR',
      year: 2018,
    },
    {
      id: 1,
      name: 'RRR',
      year: 2018,
    },
    {
      id: 1,
      name: 'RRR',
      year: 2018,
    },
    {
      id: 1,
      name: 'RRR',
      year: 2018,
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
