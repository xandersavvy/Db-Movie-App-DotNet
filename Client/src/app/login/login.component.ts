import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import validator from 'validator';
import { catchError, EMPTY, of } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  error = '';
  constructor(private _authService: AuthService) {}
  loginSection = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  ngOnInit(): void {}
  login() {
    let { email, password } = this.loginSection.value;
    if (
      validator.isEmail(email as string) &&
      validator.isStrongPassword(password as string)
    ) {
      this._authService
        .login(email as string, password as string)
        .pipe(
          catchError((err) => {
            this.error = 'Login Failed';
            console.log(err);
            return EMPTY;
          })
        )
        .subscribe(({ token, email, name }) => {
          if (token) {
            localStorage.setItem('name', name);
            localStorage.setItem('email', email);
            localStorage.setItem('token', token);
          }
          console.log(email);
          return (window.location.href = '');
        });
    } else {
      this.error = 'Unauthorized';
    }
    this.loginSection.reset();
  }
}
