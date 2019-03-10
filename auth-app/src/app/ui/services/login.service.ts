import { Injectable } from '@angular/core';
import { UserRegisterDto } from '../models/user-register-dto.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }
  URL: string = "https://localhost:7777/api/Account/Register"
  URLForToken: string = "https://localhost:7777/Token"
  username: string;
  password: string;
  grant_type: string = 'password';

  RequestToken2(obj1: UserRegisterDto): Observable<any> {
    this.username = obj1.Email;
    this.password = obj1.Password;
    return this.httpClient.post(this.URLForToken, 'username=' + this.username + '&' + 'password=' + this.password + '&' + 'grant_type=' + this.grant_type);
  }
}
