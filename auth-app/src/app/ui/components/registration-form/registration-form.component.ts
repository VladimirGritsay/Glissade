import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../../services/registration.service';
import { UserRegisterDto } from '../../models/user-register-dto.model';
 

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.scss']
})
export class RegistrationFormComponent implements OnInit {
  constructor(private registrarionService: RegistrationService) { }
  email: string;
  password: string;
  confirmPassword: string;
  welcome: string;

  ngOnInit() {
  }

  SendRegistrData() {
    const obj: UserRegisterDto = new UserRegisterDto();
    obj.Email = this.email;
    obj.Password = this.password;
    obj.ConfirmPassword = this.confirmPassword;
    this.CleanStorage();
    let req = this.registrarionService.sendUserRegData(obj);
    req.subscribe(() => {
      this.TaketToken();
    });
  }

  TaketToken() {
    let reqToken = this.registrarionService.RequestToken();
    reqToken.subscribe((responseToken) => {
      alert(responseToken.access_token);
      localStorage.setItem('access_token', JSON.stringify(responseToken.access_token));
      localStorage.setItem('token_type', JSON.stringify(responseToken.token_type));
      localStorage.setItem('refresh_token', JSON.stringify(responseToken.refresh_token));
    });
  }
  // var a = JSON.parse(localStorage.getItem('access_token'));
  // var token = JSON.parse(localStorage.getItem('token_type'));

 


 

  

  CleanStorage() {
    localStorage.clear();
  }
}
