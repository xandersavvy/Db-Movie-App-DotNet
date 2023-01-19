import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { catchError, EMPTY } from 'rxjs';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [NgbModal, NgbModalConfig],
})
export class DashboardComponent implements OnInit {
  ver = false;
  userNotLoggedIn: Boolean = false;
  userName: string | null | undefined;
  error = '';
  movieSec = new FormGroup({
    name: new FormControl(''),
    year: new FormControl(0),
  });
  constructor(
    config: NgbModalConfig,
    private modalService: NgbModal,
    private _movieService: MovieService
  ) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }
  open(content: any) {
    this.modalService.open(content);
  }
  ngOnInit(): void {
    this.userNotLoggedIn = localStorage.getItem('token') ? false : true;

    if (localStorage.getItem('name'))
      this.userName = localStorage.getItem('name');
  }
  addMovie() {
    const { year, name } = this.movieSec.value;
    if (name == null || year == null || year < 1700 || year > 2100)
      this.error = ' Something is not right';
    else
      this._movieService
        .addMovie(name, year)
        .pipe(
          catchError((err) => {
            console.log(err);
            return EMPTY;
          })
        )
        .subscribe((data) => window.location.reload());
  }
  logOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    localStorage.removeItem('name');
    window.location.href = '';
  }
}
