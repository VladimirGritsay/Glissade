import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegistrationFormComponent } from './components/registration-form/registration-form.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegistrationService } from './services/registration.service';
import { AuthInterceptor } from './interceptors/auth-interceptor';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RefreshTokenFormComponent } from './components/refresh-token-form/refresh-token-form.component';



@NgModule({
  exports: [RegistrationFormComponent,LoginFormComponent,RefreshTokenFormComponent],
  declarations: [RegistrationFormComponent, LoginFormComponent, RefreshTokenFormComponent],
  providers: [RegistrationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule

  ]
})
export class UiModuleModule { }
