import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor() {}
  loginSection = new FormGroup({
    email: new FormControl('example@email.com'),
    password: new FormControl(''),
  });

  ngOnInit(): void {}
}
