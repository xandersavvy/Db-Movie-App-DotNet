import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { catchError, EMPTY } from 'rxjs';
import validator from 'validator';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  loggedIn = true;
  emailError = '';
  passwordError = '';
  error = '';
  constructor(private _authService: AuthService) {}
  regSec = new FormGroup({
    email: new FormControl(''),
    name: new FormControl(''),
    password: new FormControl(''),
  });
  ngOnInit(): void {
    if (localStorage.getItem('token')) window.location.href = '';
    else this.loggedIn = false;
  }
  registerFunc() {
    const { email, name, password } = this.regSec.value;
    this.regSec.reset();
    if (!validator.isEmail(email as string))
      return (this.emailError = 'wrong email  type');
    if (!validator.isStrongPassword(password as string))
      return (this.passwordError = 'not a string password');
    if (name == null) return (this.error = 'name is required');
    return this._authService
      .register(email as string, password as string, name as string)
      .pipe(
        catchError((err) => {
          this.error = 'can not register, User Already Exists';
          console.error(err);
          return EMPTY;
        })
      )
      .subscribe((data) => (window.location.href = ''));
  }
}
