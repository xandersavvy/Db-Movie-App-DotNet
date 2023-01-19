import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/interfaces/User';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [NgbModal, NgbModalConfig],
})
export class DashboardComponent implements OnInit {
  name = '';
  year = '';
  ver = false;
  userNotLoggedIn: Boolean = false;
  user!: User;
  userName: string | null | undefined;

  constructor(config: NgbModalConfig, private modalService: NgbModal) {
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
    console.log(this.name, this.year);
  }
  logOut() {
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    localStorage.removeItem('name');
    window.location.href = '';
  }
}
