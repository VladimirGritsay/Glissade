 
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserRegisterDto } from '../models/user-register-dto.model';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private httpClient: HttpClient) { }

  URL: string = "https://localhost:7777/api/Account/Register"
  URLForToken: string = "https://localhost:7777/Token"

 
  username: string;
  password: string;
  grant_type: string = 'password';

  sendUserRegData(obj: UserRegisterDto): Observable<any> {
    this.username = obj.Email;
    this.password = obj.Password;

    return this.httpClient.post<UserRegisterDto>(this.URL, obj)
  }

  RequestToken(): Observable<any> {

    return this.httpClient.post(this.URLForToken, 'username=' + this.username + '&' + 'password=' + this.password + '&' + 'grant_type=' + this.grant_type);
  }




 
 

 
}
