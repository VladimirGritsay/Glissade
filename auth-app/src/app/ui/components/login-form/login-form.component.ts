import { Component, OnInit } from '@angular/core';
import { UserRegisterDto } from '../../models/user-register-dto.model';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {

  constructor(private loginService :LoginService) { }

  emailLog: string;
  passwordLog: string;

  ngOnInit() {
  }
  SendLoginData() {
    const obj1: UserRegisterDto = new UserRegisterDto();
    obj1.Email = this.emailLog;
    obj1.Password = this.passwordLog;
    this.TaketToken2(obj1);
  }

  TaketToken2(obj1: UserRegisterDto) {
    let reqToken = this.loginService.RequestToken2(obj1);
    reqToken.subscribe((responseToken) => {

      localStorage.setItem('access_token', JSON.stringify(responseToken.access_token));
      localStorage.setItem('token_type', JSON.stringify(responseToken.token_type));
      localStorage.setItem('refresh_token', JSON.stringify(responseToken.refresh_token));
      alert(responseToken.access_token);
      alert(responseToken.refresh_token);
    });
  } 
}
