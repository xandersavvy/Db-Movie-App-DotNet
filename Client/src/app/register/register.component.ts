import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  reg = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*#?&^_-]).{6,16}/;
  wrongPass = true;
  constructor() {}
  regSec = new FormGroup({
    email: new FormControl(''),
    name: new FormControl(''),
    password: new FormControl(
      '',
      Validators.compose([Validators.required, Validators.pattern(this.reg)])
    ),
  });
  ngOnInit(): void {}
}
