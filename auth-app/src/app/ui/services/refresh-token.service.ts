import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserRegisterDto } from '../models/user-register-dto.model';

@Injectable({
  providedIn: 'root'
})
export class RefreshTokenService {

  constructor( private httpClient:HttpClient) { }
  URL: string = "https://localhost:7777/api/Account/Register"
  URLForToken: string = "https://localhost:7777/Token"
  username: string;
  password: string;
  grant_type: string = 'password';


  SendUserData4(): Observable<any> {
    let url: string = 'https://localhost:7777/authentication/gety';
    return this.httpClient.get<any>(url);
  }

  GetRefreshToken(test: UserRegisterDto) { 
    this.username = test.Email;
    this.password = test.Password;
    return this.httpClient.post(this.URLForToken, 'username=' + this.username + '&' + 'password=' + this.password + '&' + 'grant_type=' + "refresh_token");
  }
}  
 