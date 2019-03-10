import { Component, OnInit } from '@angular/core';
import { RefreshTokenService } from '../../services/refresh-token.service';
import { UserRegisterDto } from '../../models/user-register-dto.model';

@Component({
  selector: 'app-refresh-token-form',
  templateUrl: './refresh-token-form.component.html',
  styleUrls: ['./refresh-token-form.component.scss']
})
export class RefreshTokenFormComponent implements OnInit {

  constructor(private refreshToken : RefreshTokenService) { }

  ngOnInit() {
  }

  CheckToken(): void {
    let a = this.refreshToken.SendUserData4();
    a.subscribe(
      (resp) => {
        alert(resp);
      }, (resp) => {
        // this.CleanStorage();
        alert('error');
      });
  }

  Test(test: UserRegisterDto){
    this.refreshToken.GetRefreshToken(test);
   }
}
