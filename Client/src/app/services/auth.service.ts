import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/interfaces/User';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  url = 'https://localhost:7053/api/';
  constructor(private http: HttpClient) {}
  public login(email: string, password: string): Observable<User> {
    return this.http.get<User>(
      `${this.url}login?email=${email}&&password=${password}`
    );
  }
  public register(email: string, password: string, name: string) {
    return this.http.post(
      `${this.url}register?email=${email}&name=${name}&password=${password}`,
      email
    );
  }
}
