import { Component, Input, OnInit } from '@angular/core';
import { Movie } from '../../../interfaces/Movie';

@Component({
  selector: 'app-single-movie',
  template: `
    <div class="card">
      <h4>{{ movie.name }}</h4>
      <small> {{ movie.year }} </small>
      <div class="button-gr">
        <button class="btn btn-lg btn-outline-primary">✎</button>
        <button class="btn btn-lg btn-outline-danger p-danger ">🗑</button>
      </div>
    </div>
  `,
  styleUrls: ['./single-movie.component.css'],
})
export class SingleMovieComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
  @Input() movie!: Movie;
}
